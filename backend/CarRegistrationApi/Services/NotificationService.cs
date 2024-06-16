using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRegistrationApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRegistrationApi.Services
{
    public class NotificationService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly EmailService _emailService;

        public NotificationService(IServiceScopeFactory scopeFactory, EmailService emailService)
        {
            _scopeFactory = scopeFactory;
            _emailService = emailService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Rulează la fiecare oră
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var registrations = dbContext.Registrations
                    .Where(r => r.ExpiryDate.Date == DateTime.UtcNow.AddDays(1).Date && !r.IsNotificationSent)
                    .ToList();

                foreach (var registration in registrations)
                {
                    _emailService.SendReminderEmail(registration.Email, registration.FullName, registration.Service, registration.ExpiryDate);
                    registration.IsNotificationSent = true;
                }

                dbContext.SaveChanges();
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
