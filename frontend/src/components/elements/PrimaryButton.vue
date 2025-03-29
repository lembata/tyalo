<template>
  <BaseButton
    :class="
      twMerge(
        'py-2 px-4 ' +
          'bg-gradient-to-r from-teal-600 to-teal-700 ' +
          'text-white font-medium rounded-lg shadow-md ' +
          'transition duration-300 ' +
          //PSEUDO
          'hover:shadow-lg ' +
          'disabled:from-teal-900 disabled:to-teal-900 disabled:text-gray-300 ' +
          'focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-teal-600 ' +
          'hover:from-teal-600 hover:to-teal-600 ' +
          //DARK
          'dark:from-orange-700 dark:to-orange-800 ' +
          'dark:focus:ring-orange-700 ' +
          'hover:dark:from-orange-700 hover:dark:to-orange-700 ' +
          'disabled:dark:from-orange-900 disabled:dark:to-orange-900 disabled:text-gray-300',
          props.class,
      )
    "
  >
    <slot></slot>
  </BaseButton>
</template>

<script setup>
import { twMerge } from 'tailwind-merge'
import BaseButton from '@/components/elements/BaseButton.vue'

const props = defineProps({
  class: String,
})
</script>
