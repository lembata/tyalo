<template>
  <div class="max-w-md mx-auto bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden">
    <div class="p-8">
      <h2 class="text-2xl font-bold text-gray-800 dark:text-white mb-6">Welcome to <span class="font-koho font-small-caps" >Tyalo</span></h2>
      <p class="text-gray-600 dark:text-gray-300 mb-8">Track your body measurements and progress</p>

      <form class="space-y-6">
<!--        <form @submit.prevent="handleLogin" class="space-y-6">-->
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
          <label v-if="!!emailError" class="block text-right text-red-600 dark:text-red-500 text-xs">{{emailError}}</label>
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
          <label v-if="!!passwordError" class="block text-right text-red-600 dark:text-red-500 text-xs">{{passwordError}}</label>
        </div>

        <div>
          <button
            type="submit"
            @click.prevent="handleLogin"
            class="w-full py-2 px-4 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-teal-600 dark:focus:ring-orange-700"
          >
            Sign In
          </button>
        </div>
      </form>

      <div class="mt-6 text-center">
        <p class="text-sm text-gray-600 dark:text-gray-400">
          Don't have an account?
          <a href="#" @click.prevent="handleOnSignUp" class="font-medium text-teal-600 hover:text-teal-500 dark:text-orange-600 dark:hover:text-orange-500">Sign up</a>
        </p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useToast } from "vue-toastification";
import API from "@/api.js";
import {useRoute, useRouter} from "vue-router";

const route = useRoute();
const router = useRouter();

// Form data
const email = ref('');
const password = ref('');
//const remember = ref(false);
const toast = useToast();
const emailError = ref(null);
const passwordError = ref(null);

const props = defineProps({
  onSignUp: Function,
});

const handleOnSignUp = () => {
  if(props.onSignUp) {
    props.onSignUp();
  }
};

// Login handler
const handleLogin = async () => {
  let hasError = false;

  if(!email.value) {
    emailError.value = "Email is required";
    hasError = true;
  }

  if(!password.value) {
    passwordError.value = "Password is required";
    hasError = true;
  }

  if(hasError) {
    toast.error("Please fill in all required fields");
    return;
  }

  console.log('Login attempt:', { email: email.value, password: password.value });
  const result = await API.LogIn(email.value, password.value);

  if(result.success) {
    toast.success("Logged in", {
      timeout: 1000
    });
    if(route.params.redirect) {
      await router.push(route.params.redirect);
    } else {
      await router.push('/dashboard')
    }
  } else {
    toast.error(result.message)
  }
};

</script>
