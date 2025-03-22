<script setup>
import Logo from "@/components/Logo.vue";
import API from "@/api";
import {ref} from "vue";
import LoginPage from "@/views/LoginPage.vue";
import ContentView from "@/views/ContentView.vue";

let isDark = ref(localStorage.getItem('tyalo-theme') === 'dark' );
let isLoggedIn = ref(API.IsLoggedIn());

let toggleTheme = () => {
  isDark.value = !isDark.value;
  if (typeof localStorage !== 'undefined') {
    localStorage.setItem('tyalo-theme', isDark.value ? 'dark' : 'light');
  }
};

</script>

<template>
  <div class="min-h-flex flex-col w-full" :class="isDark ? 'dark' : ''">
    <div
      class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden"
    >
      <!-- Dot pattern background -->
      <div class="absolute inset-0 dot-pattern opacity-10 dark:opacity-20"></div>

      <div class="container mx-auto px-4 py-8 relative z-10">


        <ContentView v-if="isLoggedIn" />
        <LoginPage v-else/>
      </div>
    </div>
  </div>
</template>

<style scoped>
.dark {
  color-scheme: dark;
}

.dot-pattern {
  --dotSize: 0.25rem;
  --bgSize: 1.35rem;
  --bgPosition: calc(var(--bgSize) / 2);

  background-image: radial-gradient(
    circle at center,
    var(--color-gray-600) var(--dotSize),
    transparent 0
  ), radial-gradient(circle at center, black var(--dotSize), transparent 0);
  background-size: var(--bgSize) var(--bgSize);
  background-position: 0 0, var(--bgPosition) var(--bgPosition);
}
</style>
