<template>
  <div class="min-h-screen flex flex-col" :class="isDark ? 'dark' : ''">
    <div class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden">
      <!-- Dot pattern background -->
<!--      <div class="absolute inset-0 dot-pattern opacity-10 dark:opacity-20"></div>-->

      <header class="flex justify-between items-center mb-12">
        <Logo/>

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
      </header>

      <div class="container mx-auto px-4 py-8 relative z-10">
        <!-- Login form -->
        <div class="max-w-md mx-auto bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden">
          <div class="p-8">
            <h2 class="text-2xl font-bold text-gray-800 dark:text-white mb-6">Welcome to Tyalo</h2>
            <p class="text-gray-600 dark:text-gray-300 mb-8">Track your body measurements and progress</p>

            <form @submit.prevent="handleLogin" class="space-y-6">
              <div>
                <label for="username" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">Username</label>
                <input
                  type="text"
                  id="username"
                  v-model="username"
                  class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  placeholder="Enter your username"
                  required
                />
              </div>

              <div>
                <label for="email" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">Email</label>
                <input
                  type="email"
                  id="email"
                  v-model="email"
                  class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  placeholder="Enter your email"
                  required
                />
              </div>

              <div>
                <label for="password" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">Password</label>
                <input
                  type="password"
                  id="password"
                  v-model="password"
                  class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  placeholder="Enter your password"
                  required
                />
              </div>

              <div class="flex items-center justify-between">
                <div class="flex items-center">
                  <input
                    type="checkbox"
                    id="remember"
                    v-model="remember"
                    class="h-4 w-4 text-teal-600 focus:ring-teal-600 dark:text-orange-700 dark:focus:ring-orange-700 rounded"
                  />
                  <label for="remember" class="ml-2 block text-sm text-gray-700 dark:text-gray-300">Remember me</label>
                </div>
                <a href="#" class="text-sm text-teal-600 hover:text-teal-500 dark:text-orange-600 dark:hover:text-orange-500">Forgot password?</a>
              </div>

              <div>
                <button
                  type="submit"
                  class="w-full py-2 px-4 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-teal-600 dark:focus:ring-orange-700"
                >
                  Sign In
                </button>
              </div>
            </form>

            <div class="mt-6 text-center">
              <p class="text-sm text-gray-600 dark:text-gray-400">
                Don't have an account?
                <a href="#" class="font-medium text-teal-600 hover:text-teal-500 dark:text-orange-600 dark:hover:text-orange-500">Sign up</a>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import Logo from "@/components/Logo.vue";

// Form data
const username = ref('');
const email = ref('');
const password = ref('');
const remember = ref(false);

// Theme toggle
const isDark = ref(false);

const toggleTheme = () => {
  isDark.value = !isDark.value;
  if (typeof localStorage !== 'undefined') {
    localStorage.setItem('tyalo-theme', isDark.value ? 'dark' : 'light');
  }
};

// Login handler
const handleLogin = () => {
  console.log('Login attempt:', { username: username.value, email: email.value, password: password.value });
  // Here you would typically make an API call to authenticate the user
};

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

.font-koho {
  font-family: 'KoHo', sans-serif;
}

.dot-pattern {
  background-image: radial-gradient(circle, rgba(0,0,0,0.1) 1px, transparent 1px);
  background-size: 20px 20px;
}

</style>

