<script setup>
import { ref } from 'vue'
import MyRouterLink from '@/components/MyRouterLink.vue'
import LightModeIcon from '@/assets/icons/LightModeIcon.vue'
import DarkModeIcon from '@/assets/icons/DarkModeIcon.vue'
import LogoutIcon from '@/assets/icons/LogoutIcon.vue'
import HamburgerIcon from '@/assets/icons/HamburgerIcon.vue'
import Logo from '@/assets/Logo.vue'

import API from '@/api.js'
import { useRouter } from 'vue-router'

const props = defineProps({
  hideRoutes: Boolean,
})

const isDark = ref(localStorage.getItem('tyalo-theme') === 'dark')
const mobileMenuOpen = ref(false)
const router = useRouter()

let toggleTheme = () => {
  isDark.value = !isDark.value
  if (typeof localStorage !== 'undefined') {
    localStorage.setItem('tyalo-theme', isDark.value ? 'dark' : 'light')
  }
}

let onLogout = async () => {
  await API.LogOut()
  await router.push('/login')
}

let toggleMobileMenu = () => {
  mobileMenuOpen.value = !mobileMenuOpen.value
}

console.warn('ContentHeader.vue called', props.hideRoutes)
</script>

<template>
  <!-- Header with navigation -->
  <header class="flex justify-between items-center mb-8">
    <div class="flex items-center">
      <!-- Abstract body logo - woman with hourglass figure in active pose -->
      <div class="w-10 h-10 relative">
        <Logo/>
      </div>

      <!-- Tyalo text with per-letter gradient using KoHo font and small caps -->
      <div class="ml-3 flex items-center">
        <span
          class="text-2xl font-bold font-koho"
          style="
            background: linear-gradient(to right, #0d9488, #15803d);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            font-variant: small-caps;
          "
          >T</span
        >
        <span
          class="text-2xl font-bold font-koho"
          style="
            background: linear-gradient(to right, #15803d, #0e7490);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            font-variant: small-caps;
          "
          >y</span
        >
        <span
          class="text-2xl font-bold font-koho"
          style="
            background: linear-gradient(to right, #0e7490, #0369a1);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            font-variant: small-caps;
          "
          >a</span
        >
        <span
          class="text-2xl font-bold font-koho"
          style="
            background: linear-gradient(to right, #0369a1, #c2410c);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            font-variant: small-caps;
          "
          >l</span
        >
        <span
          class="text-2xl font-bold font-koho"
          style="
            background: linear-gradient(to right, #c2410c, #9a3412);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            font-variant: small-caps;
          "
          >o</span
        >
      </div>
    </div>

    <div class="flex items-center space-x-4">
      <nav v-if="!props.hideRoutes" class="hidden md:flex space-x-4">
        <MyRouterLink to="/" text="Dashboard" />
        <MyRouterLink to="/add-measurement" text="Add Measurement" />
        <MyRouterLink to="/data-table" text="Data Table" />
        <MyRouterLink to="/graphs" text="Graphs" />
        <MyRouterLink to="/settings" text="Settings" />
      </nav>

      <button @click="toggleTheme" class="p-2 rounded-full bg-white dark:bg-gray-800 shadow-md hover:bg-gray-200 dark:hover:bg-gray-600">
        <LightModeIcon v-if="isDark" class="text-orange-700" />
        <DarkModeIcon v-else class="text-teal-600" />
      </button>

      <button @click="toggleTheme" class="p-2 rounded-full bg-white dark:bg-gray-800 shadow-md hover:bg-gray-200 dark:hover:bg-gray-600">
        <LogoutIcon @click="onLogout" class="text-teal-600 dark:text-orange-700" />
      </button>

      <button class="md:hidden p-2 text-gray-700 dark:text-gray-300" @click="toggleMobileMenu">
        <HamburgerIcon />
      </button>
    </div>
  </header>

  <!-- Mobile menu -->
  <div
    v-if="mobileMenuOpen && !props.hideRoutes"
    class="md:hidden bg-white dark:bg-gray-800 rounded-lg shadow-lg p-4 mb-6"
  >
    <nav class="flex flex-col space-y-3">
      <MyRouterLink to="/" class="py-2" text="Dashboard" />
      <MyRouterLink to="/add-measurement" class="py-2" text="Add Measurement" />
      <MyRouterLink to="/data-table" class="py-2" text="Data Table" />
      <MyRouterLink to="/graphs" class="py-2" text="Graphs" />
      <MyRouterLink to="/settings" class="py-2" text="Settings" />
    </nav>
  </div>
</template>

<style scoped lang="postcss"></style>
