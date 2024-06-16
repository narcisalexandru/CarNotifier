<template>
    <div class="card">
        <MenuBar class="w-full flex justify-content-end border-none border-noround" :model="items" />
    </div>
</template>

<script setup lang='ts'>
import { ref } from "vue";
import { useRouter } from 'vue-router';

const router = useRouter();

const items = ref([
    // {
    //     label: 'Home',
    //     icon: 'pi pi-home'
    // },
    {
        label: 'Despre noi',
        icon: 'pi pi-users',
    },
    {
        label: 'Intrebari frecvente',
        icon: 'pi pi-question-circle',
    },
    {
        label: 'Contact',
        icon: 'pi pi-envelope',
        command: () => {
            router.push('/contact');
        }
    }
]);
</script>

<style>
.p-menubar {
    background-color: #031227;
}
</style>
