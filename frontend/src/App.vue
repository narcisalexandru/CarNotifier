<template>
  <NavbarMenu />
  <RouterView />
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavbarMenu from '@/components/NavbarMenu.vue'
</script>
