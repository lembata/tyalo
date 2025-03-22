import { createRouter, createWebHistory } from 'vue-router'
import GraphsView from "@/views/GraphsView.vue";
import DataTable from "@/components/DataTable.vue";
import MeasurementForm from "@/components/MeasurementForm.vue";
import SettingsPage from "@/components/SettingsPage.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: GraphsView,
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: GraphsView,
    },
    {
      path: '/add-measurement',
      name: 'add-measurement',
      component: MeasurementForm,
    },
    {
      path: '/data-table',
      name: 'data-table',
      component: DataTable,
    },
    {
      path: '/graphs',
      name: 'graphs',
      component: GraphsView,
    },
    {
      path: '/settings',
      name: 'settings',
      component: SettingsPage,
    }
  ],
})

export default router
