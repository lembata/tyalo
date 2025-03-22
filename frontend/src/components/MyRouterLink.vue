<script setup>
import {RouterLink, useRoute} from "vue-router";
import {indexTrim} from "@/utils.js";

const props = defineProps({
  to: String,
  text: String,
});

const route = useRoute();
const key = indexTrim(props.to, '/');

const isSelected = () => {
  return route.matched.some((route) => route.name === key)
};

</script>
<template>
  <RouterLink
    :to="props.to"
    :class="{
      'text-teal-600 dark:text-orange-600': isSelected(),
      'text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600': !isSelected(),
    }"
  >{{props.text}}</RouterLink
  >
</template>
