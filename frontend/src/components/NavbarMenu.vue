<template>
    <div class="card">
        <MenuBar class="w-full flex justify-content-between px-4 border-none border-noround fixed" :model="items">
            <template #start>
                    <router-link to="/">
                        <img class="align-items-start justify-content-start w-2 h-2" src="@/assets/images/logo.jpeg" alt="logo" />
                    </router-link>
            </template>
        </MenuBar>
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
        command: () => {
            router.push('/despre-noi');
        }
    },
    {
        label: 'Intrebari frecvente',
        icon: 'pi pi-question-circle',
        command: () => {
            router.push('/intrebari-frecvente');
        }
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
