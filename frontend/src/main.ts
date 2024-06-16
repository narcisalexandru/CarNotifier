import './assets/main.css'
import 'primevue/resources/themes/aura-light-green/theme.css'
import '/node_modules/primeflex/primeflex.css'
import 'primeicons/primeicons.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config';
import Dropdown from 'primevue/dropdown';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import Menubar from 'primevue/menubar';
import CustomCalendar from 'primevue/calendar';
import RadioButton from 'primevue/radiobutton';
import CustomTextarea from 'primevue/textarea';

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(PrimeVue)

app.component('DropdownInputs', Dropdown);
app.component('InputText', InputText);
app.component('ButtonInputs', Button);
app.component('MenuBar', Menubar);
app.component('RadioButton', RadioButton);
app.component('CustomCalendar', CustomCalendar);
app.component('CustomTextarea', CustomTextarea);


app.mount('#app')
