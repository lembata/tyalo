<template>
  <BaseButton
    class=""
    :class="
      twMerge(
        'py-2 px-4 ' +
          'border border-gray-300 ' +
          'text-gray-700 font-medium ' +
          'rounded-lg ' +
          'transition duration-300 ' +
          //PSEUDO
          'hover:bg-gray-50 ' +
          'disabled:bg-gray-500 disabled:text-gray-300 ' +
          'focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-500 ' +
          //DARK
          'dark:border-gray-600 dark:text-gray-300 ' +
          'dark:hover:bg-gray-700 ' +
          'disabled:dark:bg-gray-500 disabled:dark:text-gray-300 ' +
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
