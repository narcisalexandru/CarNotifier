using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRegistrationApi.Data;
using CarRegistrationApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarRegistrationApi.Services
{
    public class NotificationService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IServiceScopeFactory scopeFactory, ILogger<NotificationService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(24));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();

                var now = DateTime.UtcNow;
                var registrations = await context.Registrations
                    .Where(r => r.ExpiryDate != null &&
                                r.ExpiryDate.Date == now.Date.AddDays(1) &&
                                !r.IsNotificationSent)
                    .ToListAsync();

                foreach (var registration in registrations)
                {
                    emailService.SendReminderEmail(registration.Email, registration.FullName, registration.Service);
                    registration.IsNotificationSent = true;
                }

                await context.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
