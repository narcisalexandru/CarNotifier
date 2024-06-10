<template>
    <div class="card flex align-items-center justify-content-center w-full bg-cover image" style="height: 1000px;">
        <HeaderInputs />
    </div>
</template>

<script setup lang="ts">
import HeaderInputs from '@/components/HeaderInputs.vue'
</script>

<style>
.image {
    background-image: url(@/assets/images/header-image.png);
}
</style>