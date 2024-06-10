
<template>
    <div class="card">
        <MenuBar class="w-full flex justify-content-end border-none border-noround fixed" :model="items" />
    </div>
</template>

<script setup lang='ts'>
import { ref } from "vue";

const items = ref([
    // {
    //     label: 'Home',
    //     icon: 'pi pi-home'
    // },
    {
        label: 'Despre noi',
        icon: 'pi pi-users'
    },
    {
        label: 'Intrebari frecvente',
        icon: 'pi pi-question-circle'
    },
    {
        label: 'Contact',
        icon: 'pi pi-envelope'
    }
]);
</script>

<style>
.p-menubar {
    background-color: #031227;
}
</style>
