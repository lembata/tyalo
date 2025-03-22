<template>
  <div class="min-h-screen flex flex-col" :class="isDark ? 'dark' : ''">
    <div
      class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden"
    >
      <div class="container mx-auto px-4 py-8 relative z-10">
        <!-- Measurement form -->
        <div
          class="max-w-2xl mx-auto bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden"
        >
          <div class="p-8">
            <h2 class="text-2xl font-bold text-gray-800 dark:text-white mb-6">
              Add New Measurement
            </h2>

            <form @submit.prevent="saveMeasurement" class="space-y-6">
              <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                  <label
                    for="date"
                    class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >Date</label
                  >
                  <input
                    type="date"
                    v-model="measurement.date"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    required
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="weight"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Weight ({{ units.weight }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.weight"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    required
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="neck"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Neck ({{ units.length }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.neck"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="chest"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Chest ({{ units.length }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.chest"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="waist"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Natural Waist ({{ units.length }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.naturalWaist"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="waist"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Waist ({{ units.length }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.waist"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="hips"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Hips ({{ units.length }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.hips"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="thigh"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Thigh ({{ units.length }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.thigh"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="arm"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Arm ({{ units.length }})
                    </label>
                  </div>
                  <input
                    type="number"
                    v-model="measurement.arm"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                </div>

                <div>
                  <div class="flex justify-between">
                    <label
                      for="bodyFat"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Body Fat %
                    </label>
                    <div class="flex items-center">
                      <input
                        type="checkbox"
                        v-model="isApproximatedBodyFat"
                        class="h-4 w-4 text-teal-600 focus:ring-teal-600 dark:text-orange-700 dark:focus:ring-orange-700 rounded"
                      />
                      <label
                        for="bodyFat-approx"
                        class="ml-2 text-xs text-gray-500 dark:text-gray-400"
                        >Approximate</label
                      >
                    </div>
                  </div>
                  <input
                    v-if="isApproximatedBodyFat"
                    type="number"
                    :value="approximatedBodyFat"
                    disabled
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                  <input
                    v-else
                    type="number"
                    v-model="measurement.bodyFat"
                    step="0.1"
                    class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                  <div
                    v-if="approximateBodyFat"
                    class="mt-1 text-xs text-gray-500 dark:text-gray-400 italic"
                  >
                    This value is approximate
                  </div>
                </div>
              </div>

              <div>
                <label
                  for="notes"
                  class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                  >Notes</label
                >
                <textarea
                  v-model="measurement.notes"
                  rows="3"
                  class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  placeholder="Add any notes about your measurements or how you're feeling..."
                ></textarea>
              </div>

              <div class="flex justify-end space-x-4">
                <button
                  type="button"
                  class="py-2 px-4 border border-gray-300 dark:border-gray-600 text-gray-700 dark:text-gray-300 font-medium rounded-lg hover:bg-gray-50 dark:hover:bg-gray-700 transition duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-500"
                >
                  Cancel
                </button>
                <button
                  type="submit"
                  class="py-2 px-4 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-teal-600 dark:focus:ring-orange-700"
                >
                  Save Measurement
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted, computed } from 'vue'

// Theme toggle
const isDark = ref(localStorage.getItem('tyalo-theme') === 'dark')
// || window.matchMedia('(prefers-color-scheme: dark)').matches);

// Units of measurement (would come from settings in a real app)
const units = reactive({
  weight: 'kg',
  length: 'cm',
})

// Measurement form data
const measurement = reactive({
  date: new Date().toISOString().split('T')[0], // Today's date in YYYY-MM-DD format
  weight: Number | null,
  chest: Number | null,
  naturalWaist: Number | null,
  waist: Number | null,
  hips: Number | null,
  neck: Number | null,
  thigh: Number | null,
  arm: Number | null,
  bodyFat: Number | null,
  notes: '',
})

const isApproximatedBodyFat = ref(true)

const saveMeasurement = () => {
  console.log('Saving measurement:', measurement)
  // Here you would typically save the measurement to your database

  // For demo purposes, let's reset the form
  Object.keys(measurement).forEach((key) => {
    if (key !== 'date') {
      measurement[key] = key === 'notes' ? '' : null
    }
  })

  alert('Measurement saved successfully!')
}

// Initialize theme on component mount
onMounted(() => {
  if (typeof window !== 'undefined' && typeof localStorage !== 'undefined') {
    const savedTheme = localStorage.getItem('tyalo-theme')
    if (
      savedTheme === 'dark' ||
      (!savedTheme && window.matchMedia('(prefers-color-scheme: dark)').matches)
    ) {
      isDark.value = true
    }
  }
})

//TODO: get this from settings
const height = 1.85

const approximateBodyFat = () => {
  const neck = measurement.neck || 0
  const waist = measurement.waist || 0

  if (!neck || !waist) {
    return 0
  }

  let bf = 0
  if (units.length === 'in') {
    bf = 86.01 * Math.log10(waist - neck) - 70.041 * Math.log10(height) + 36.76
  } else {
    bf =
      495 / (1.0324 - 0.19077 * Math.log10(waist - neck) + 0.15456 * Math.log10(height * 100)) - 450
  }

  return bf.toFixed(2)
}

const approximatedBodyFat = computed(() => {
  return  approximateBodyFat()
})
</script>

<style></style>
