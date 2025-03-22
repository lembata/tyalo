<script setup>
import { ref } from 'vue'
import MyRouterLink from "@/components/MyRouterLink.vue";

const props = defineProps({
  hideRoutes: Boolean
});
// const props = defineProps({
//   hideRoutes: {
//     type: Boolean,
//     default: false
//   }
// });

let isDark = ref(localStorage.getItem('tyalo-theme') === 'dark')
let mobileMenuOpen = ref(false)

let toggleTheme = () => {
  isDark.value = !isDark.value
  if (typeof localStorage !== 'undefined') {
    localStorage.setItem('tyalo-theme', isDark.value ? 'dark' : 'light')
  }
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
        <svg viewBox="0 0 100 100" xmlns="http://www.w3.org/2000/svg" class="w-full h-full">
          <!-- Hourglass figure in active pose -->
          <path
            d="M50,10 C55,10 60,15 60,20 C60,25 58,30 55,35
                         C65,40 65,50 60,55 C55,60 50,60 45,55
                         C40,60 35,60 30,55 C25,50 25,40 35,35
                         C32,30 30,25 30,20 C30,15 35,10 50,10 Z"
            fill="url(#bodyGradient)"
          />

          <!-- Head -->
          <circle cx="50" cy="15" r="5" fill="url(#bodyGradient)" />

          <!-- Arms in active pose -->
          <path
            d="M55,35 C65,30 75,35 80,40"
            stroke="url(#bodyGradient)"
            stroke-width="4"
            stroke-linecap="round"
            fill="none"
          />
          <path
            d="M35,35 C25,30 15,35 10,40"
            stroke="url(#bodyGradient)"
            stroke-width="4"
            stroke-linecap="round"
            fill="none"
          />

          <!-- Legs in active pose -->
          <path
            d="M45,55 C40,65 40,80 35,90"
            stroke="url(#bodyGradient)"
            stroke-width="4"
            stroke-linecap="round"
            fill="none"
          />
          <path
            d="M55,55 C60,65 60,80 65,90"
            stroke="url(#bodyGradient)"
            stroke-width="4"
            stroke-linecap="round"
            fill="none"
          />

          <!-- Gradient for the body -->
          <defs>
            <linearGradient id="bodyGradient" x1="0%" y1="0%" x2="100%" y2="100%">
              <stop offset="0%" stop-color="#0d9488" />
              <!-- teal-600 -->
              <stop offset="100%" stop-color="#c2410c" />
              <!-- orange-700 -->
            </linearGradient>
          </defs>
        </svg>
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

      <button @click="toggleTheme" class="p-2 rounded-full bg-white dark:bg-gray-800 shadow-md">
        <svg
          v-if="isDark"
          xmlns="http://www.w3.org/2000/svg"
          width="20"
          height="20"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="text-orange-700"
        >
          <circle cx="12" cy="12" r="5"></circle>
          <line x1="12" y1="1" x2="12" y2="3"></line>
          <line x1="12" y1="21" x2="12" y2="23"></line>
          <line x1="4.22" y1="4.22" x2="5.64" y2="5.64"></line>
          <line x1="18.36" y1="18.36" x2="19.78" y2="19.78"></line>
          <line x1="1" y1="12" x2="3" y2="12"></line>
          <line x1="21" y1="12" x2="23" y2="12"></line>
          <line x1="4.22" y1="19.78" x2="5.64" y2="18.36"></line>
          <line x1="18.36" y1="5.64" x2="19.78" y2="4.22"></line>
        </svg>
        <svg
          v-else
          xmlns="http://www.w3.org/2000/svg"
          width="20"
          height="20"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="text-teal-600"
        >
          <path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"></path>
        </svg>
      </button>

      <button class="md:hidden p-2 text-gray-700 dark:text-gray-300" @click="toggleMobileMenu">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
        >

          <line x1="3" y1="12" x2="21" y2="12"></line>
          <line x1="3" y1="6" x2="21" y2="6"></line>
          <line x1="3" y1="18" x2="21" y2="18"></line>
        </svg>
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
