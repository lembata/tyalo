<template>
  <div class="min-h-screen flex flex-col" :class="isDark ? 'dark' : ''">
    <div class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden">

      <ContentHeader />

      <div class="container mx-auto px-4 py-8 relative z-10">
        <!-- Login form -->
        <SignupForm v-if="signup" :onSignIn="() => {signup = false}"/>
        <LoginForm v-else :onSignUp="() => {signup = true}"/>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import ContentHeader from "@/components/ContentHeader.vue";
import LoginForm from "@/components/forms/LoginForm.vue";
import SignupForm from "@/components/forms/SignupForm.vue";

// Theme toggle
const isDark = ref(localStorage.getItem('tyalo-theme') === 'dark');
const signup = ref(false);

// Initialize theme on component mount
onMounted(() => {
  if (typeof window !== 'undefined' && typeof localStorage !== 'undefined') {
    const savedTheme = localStorage.getItem('tyalo-theme');
    if (savedTheme === 'dark' || (!savedTheme && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
      isDark.value = true;
    }
  }
});
</script>

<style>
/* Import KoHo font */
@import url('https://fonts.googleapis.com/css2?family=KoHo:wght@700&display=swap');
</style>
