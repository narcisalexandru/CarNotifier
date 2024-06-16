<template>
    <div class="flex justify-content-center align-items-center p-8">
        <div class="flex flex-column gap-3 blur-box p-8 border border-round ">
            <h1 class=" text-center text-3xl text-white">Contacteaza-ne</h1>
            <div class="flex flex-column text-white gap-1">
                <label for="username">Nume Prenume</label>
                <InputText id="username" v-model="username" />
            </div>
            <div class="flex flex-column text-white gap-1">
                <label for="email">Email</label>
                <InputText id="email" v-model="email" />
            </div>
            <div class="flex flex-column text-white gap-1">
                <label for="subject">Subiect</label>
                <InputText id="subject" v-model="subject" />
            </div>
            <div class="flex flex-column text-white gap-1">
                <label for="message">Ajutor si suport</label>
                <CustomTextarea v-model="message" rows="5" cols="30" />
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const username = ref(null);
const email = ref(null);
const message = ref('');
const subject = ref('');

</script>

<style>
.blur-box {
  background-color:rgba(106, 117, 130, 0.2);
  backdrop-filter: blur(10px);
}
</style>