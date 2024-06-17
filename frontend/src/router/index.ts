import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ContactView from '@/views/ContactView.vue'
import IntrebariFrecventeView from '@/views/IntrebariFrecventeView.vue';
import DespreNoiView from '@/views/DespreNoiView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/contact',
      name: 'contact',
      component: ContactView

    },
    {
      path: '/despre-noi',
      name: 'despre-noi',
      component: DespreNoiView

    },
    {
      path: '/intrebari-frecvente',
      name: 'intrebari-frecvente',
      component: IntrebariFrecventeView

    },
  ]
})

export default router
