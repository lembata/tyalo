<template>
  <Button
    :class="props.class"
    :icon="loading ? loadingIcon : props.icon"
    :disabled="loading || disabled">
    <slot></slot>
  </Button>
</template>

<script setup>
import Button from 'primevue/button'
import { ref, watch } from 'vue'

function stripNonIconClasses(value) {
  if (value === undefined || value === null || value === '') {
    return ""
  }

  return value.split(" ")
    .filter(v => !v.startsWith("pi-"))
    .join(" ")
}

const props = defineProps({
  class: String,
  icon: String,
  loading: Boolean,
  disabled: Boolean,
})

const loadingIcon = 'pi pi-spin pi-spinner ' + stripNonIconClasses(props.icon)

const loading = ref(props.loading)
watch(
  () => props.loading,
  (l) => (loading.value = l),
)
</script>
