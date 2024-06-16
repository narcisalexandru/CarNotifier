<template>
  <div class="background-color border-round-3xl flex flex-column align-items-start p-5 w-4">
    <div class="pb-5 w-full flex justify-content-center align-items-center text-white text-3xl">
      ÎNREGISTREAZĂ-ȚI MAȘINA!
    </div>
    <div class="flex justify-content-center w-full pb-5">
      <DropdownInputs 
        v-model="selectedService" 
        :options="services"
        optionLabel="name" 
        placeholder="Selecteaza un serviciu" 
        class="w-full" 
      />
    </div>
    <div class="flex flex-row">
      <div class="flex flex-column">
        <div class="flex pb-5">
          <div class="flex flex-column gap-2">
            <label class="text-white" for="nume">Nume Prenume</label>
            <InputText 
              id="nume" 
              v-model="registration.fullName"
              placeholder="Cazacu Narcis"
            />
          </div>
        </div>
        <div class="flex pb-5">
          <div class="flex flex-column gap-2">
            <label class="text-white" for="email">Email</label>
            <InputText 
              id="email" 
              v-model="registration.email"
              placeholder="car.notifier@gmail.com"
            />
          </div>
        </div>
        <div class="flex pb-5">
          <div class="flex flex-column gap-2">
            <label class="text-white" for="nrInmatriculare">Numar de Înmatriculare </label>
            <InputText 
              id="nrInmatriculare" 
              v-model="registration.licensePlate"
              placeholder="SB05CNT"
            />
          </div>
        </div>
      </div>
      <div class="flex flex-column justify-content-start gap-5">
        <div class="flex ml-8">
          <div class="flex flex-column gap-2">
            <label class="text-white" for="date"> Cand expira ? </label>
            <CustomCalendar v-model="date" @change="updateExpiryDate" />
          </div>
        </div>
      </div>
    </div>
    <div class="flex align-items-end justify-content-end w-full">
      <div class="card flex justify-content-center">
        <ButtonInputs
          class="bg-blue-900 border-transparent"
          type="button" 
          label="ÎNREGISTREAZĂ MASINA" 
          icon="pi pi-bell" 
          :loading="loading" 
          @click="submitRegistration"
        />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from "vue";
import { registerCar as apiRegisterCar } from '@/services/emailService';
import moment from 'moment-timezone';

const selectedService = ref();
const loading = ref(false);

const date = ref<Date | null>(null);

interface Registration {
  fullName: string;
  email: string;
  licensePlate: string;
  service: string;
  expiryDate: string | null; // Change type to string to accommodate ISO string format
}

const registration = ref<Registration>({
  fullName: '',
  email: '',
  licensePlate: '',
  service: '',
  expiryDate: null,
});

const services = ref([
  { name: 'Inspecția Tehnică Periodică (ITP)', code: 'ITP' },
  { name: 'Răspundere Civilă Auto (RCA)', code: 'RCA' },
  { name: 'Rovinieta', code: 'ROV' },
]);

watch(date, (newDate) => {
  if (newDate) {
    updateExpiryDate(newDate);
  }
});

const updateExpiryDate = (value: Date) => {
  console.log("Original Date selected:", value);
  // Convert the date from MM/DD/YYYY format to YYYY-MM-DD format and adjust for Bucharest timezone
  const parsedDate = moment(value).tz("Europe/Bucharest").startOf('day').format('YYYY-MM-DD');
  console.log("Converted to Bucharest timezone and format:", parsedDate);
  registration.value.expiryDate = parsedDate;
  console.log("Expiry Date set in registration object:", registration.value.expiryDate);
};

const submitRegistration = async () => {
  loading.value = true;
  try {
    if (selectedService.value) {
      registration.value.service = selectedService.value.name;
    }
    console.log("Registration data being sent:", registration.value); // Log the data being sent
    await apiRegisterCar(registration.value);
    alert('Registration successful and notification emails sent.');
  } catch (error) {
    console.error('Error registering car:', error);
    alert('Failed to register car. Please try again.');
  } finally {
    loading.value = false;
  }
};
</script>

<style>
.background-color {
  background-color:rgba(106, 117, 130, 0.2);
  backdrop-filter: blur(10px);
}
</style>
