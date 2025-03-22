import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import Toast from "vue-toastification";

import App from './App.vue'
import router from './router'
//
// const options= {
// };

const app = createApp(App)

app.use(Toast);
app.use(createPinia())
app.use(router)

app.mount('#app')
