<template>
  <div class="min-h-screen flex flex-col" :class="isDark ? 'dark' : ''">
    <div
      class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden"
    >
      <!-- Dot pattern background -->
      <div class="absolute inset-0 dot-pattern opacity-10 dark:opacity-20"></div>

      <div class="container mx-auto px-4 py-8 relative z-10">
        <!-- Settings Form -->
        <div class="bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden">
          <div class="p-8">
            <h2 class="text-2xl font-bold text-gray-800 dark:text-white mb-6">Settings</h2>

            <form @submit.prevent="saveSettings" class="space-y-8">
              <!-- Units of Measurement -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">
                  Units of Measurement
                </h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label
                      for="weightUnit"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                      >Weight</label
                    >
                    <select
                      id="weightUnit"
                      v-model="settings.units.weight"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    >
                      <option :value="WeightUnit.Kilograms">Kilograms (kg)</option>
                      <option :value="WeightUnit.Pounds">Pounds (lb)</option>
                    </select>
                  </div>

                  <div>
                    <label
                      for="lengthUnit"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                      >Length</label
                    >
                    <select
                      id="lengthUnit"
                      v-model="settings.units.length"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    >
                      <option :value="LengthUnit.Centimeters">Centimeters (cm)</option>
                      <option :value="LengthUnit.Inches">Inches (in)</option>
                    </select>
                  </div>
                </div>
              </div>

              <!-- Personal Information -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">
                  Personal Information
                </h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label
                      for="height"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Height ({{ lengthUnitString }})
                    </label>
                    <input
                      type="number"
                      id="height"
                      v-model="settings.height"
                      step="0.1"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    />
                  </div>

                  <div>
                    <label
                      for="startingWeight"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Starting Weight ({{ weightUnitString }})
                    </label>
                    <input
                      type="number"
                      id="startingWeight"
                      v-model="settings.startingWeight"
                      step="0.1"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    />
                  </div>

                  <div>
                    <label
                      for="startingDate"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Starting Date
                    </label>
                    <input
                      type="date"
                      id="startingDate"
                      v-model="settings.startingDate"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    />
                  </div>
                </div>
              </div>

              <div class="flex justify-end space-x-4">
                <PrimaryButton
                  type="submit"
                  @click.prevent="savePersonalSettings"
                  :loading="savingPersonal"
                  icon="pi pi-save mr-2"
                  iconPos="left"
                  label="Save Personal Information Settings"
                />
                <!--                </PrimaryButton>-->
              </div>

              <hr class="h-px my-8 bg-gray-300 border-0 dark:bg-gray-600" />

              <!-- Goal Settings -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">Goal Settings</h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label
                      for="goalWeight"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Goal Weight ({{ weightUnitString }})
                    </label>
                    <input
                      type="number"
                      id="goalWeight"
                      v-model="currentGoal.weight"
                      step="0.1"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    />
                  </div>

                  <div>
                    <label
                      for="goalPercentage"
                      class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
                    >
                      Goal as % of Body Weight
                    </label>
                    <div class="relative">
                      <input
                        type="number"
                        id="goalPercentage"
                        v-model="currentGoal.percentage"
                        step="0.1"
                        @input="validateGoalPercentage"
                        class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                      />
                      <div
                        v-if="goalPercentageWarning"
                        class="mt-1 text-sm text-red-600 dark:text-red-400"
                      >
                        {{ goalPercentageWarning }}
                      </div>
                    </div>
                  </div>

                </div>
              </div>
              <div class="flex justify-end space-x-4">
                <PrimaryButton
                  @click="showDateModal = true"
                  label="Start New Goal From Today"
                  class="h-full"
                />
                <div class="md:col-span-2">
                  <PrimaryButton
                    @click="showDateModal = true"
                    label="Recalculate Goal Line from Date"
                  />
                  <p class="mt-1 text-xs text-gray-500 dark:text-gray-400">
                    Set a new starting point for your goal calculations.
                  </p>
                </div>
              </div>

              <!-- Data Import/Export -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">
                  Data Import/Export
                </h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
                      Import Data
                    </label>
                    <div class="mt-1 flex items-center">
                      <label
                        for="csv-upload"
                        class="cursor-pointer py-2 px-4 border border-gray-300 dark:border-gray-600 rounded-lg text-sm font-medium text-gray-700 dark:text-gray-300 hover:bg-gray-50 dark:hover:bg-gray-700 focus:outline-none"
                      >
                        <span>Upload CSV</span>
                        <input
                          id="csv-upload"
                          type="file"
                          accept=".csv"
                          class="sr-only"
                          @change="handleFileUpload"
                        />
                      </label>
                      <span class="ml-3 text-sm text-gray-500 dark:text-gray-400">{{
                        uploadFileName || 'No file selected'
                      }}</span>
                    </div>
                    <p class="mt-1 text-xs text-gray-500 dark:text-gray-400">
                      Import your measurements from a CSV file. The file should have headers
                      matching the measurement fields.
                    </p>
                    <div
                      v-if="importStatus"
                      class="mt-2 text-sm"
                      :class="
                        importStatus.success
                          ? 'text-green-600 dark:text-green-400'
                          : 'text-red-600 dark:text-red-400'
                      "
                    >
                      {{ importStatus.message }}
                    </div>
                  </div>

                  <div>
                    <label class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
                      Export Data
                    </label>
                    <div class="mt-1 space-y-2">
                      <button
                        type="button"
                        @click="exportData('csv')"
                        class="py-2 px-4 border border-gray-300 dark:border-gray-600 rounded-lg text-sm font-medium text-gray-700 dark:text-gray-300 hover:bg-gray-50 dark:hover:bg-gray-700 focus:outline-none"
                      >
                        Export as CSV
                      </button>
                      <p class="text-xs text-gray-500 dark:text-gray-400">
                        Export all your measurement data to a CSV file that you can open in Excel or
                        other spreadsheet applications.
                      </p>
                    </div>
                  </div>
                </div>
              </div>

              <!-- Display Settings -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">Display Settings</h3>
                <div class="space-y-3">
                  <div class="flex items-center">
                    <input
                      type="checkbox"
                      id="darkMode"
                      v-model="settings.darkModeDefault"
                      class="h-4 w-4 text-teal-600 focus:ring-teal-600 dark:text-orange-700 dark:focus:ring-orange-700 rounded"
                    />
                    <label
                      for="darkMode"
                      class="ml-2 block text-sm text-gray-700 dark:text-gray-300"
                    >
                      Use dark mode by default
                    </label>
                  </div>

                  <div class="flex items-center">
                    <input
                      type="checkbox"
                      id="showTrends"
                      v-model="settings.showTrends"
                      class="h-4 w-4 text-teal-600 focus:ring-teal-600 dark:text-orange-700 dark:focus:ring-orange-700 rounded"
                    />
                    <label
                      for="showTrends"
                      class="ml-2 block text-sm text-gray-700 dark:text-gray-300"
                    >
                      Show trends in data table
                    </label>
                  </div>
                </div>
              </div>

              <div class="flex justify-end space-x-4">
                <SecondaryButton
                  type="button"
                  @click="resetSettings"
                  class="py-2 px-4 border border-gray-300 dark:border-gray-600 text-gray-700 dark:text-gray-300 font-medium rounded-lg hover:bg-gray-50 dark:hover:bg-gray-700 transition duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-500"
                  label="Reset to Defaults"
                />
                <PrimaryButton type="submit" label="Save Settings" />
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- Date selector modal -->
  <div
    v-if="showDateModal"
    class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50"
  >
    <div class="bg-white dark:bg-gray-800 rounded-lg shadow-xl p-6 max-w-md w-full">
      <h3 class="text-lg font-medium text-gray-800 dark:text-white mb-4">
        Select New Goal Start Date
      </h3>

      <div class="mb-4">
        <label
          for="goalStartDate"
          class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1"
        >
          Date
        </label>
        <input
          type="date"
          id="goalStartDate"
          v-model="newGoalStartDate"
          class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
        />
      </div>

      <div class="flex justify-end space-x-3">
        <button
          type="button"
          @click="showDateModal = false"
          class="py-2 px-4 border border-gray-300 dark:border-gray-600 text-gray-700 dark:text-gray-300 font-medium rounded-lg hover:bg-gray-50 dark:hover:bg-gray-700 transition duration-300 focus:outline-none"
        >
          Cancel
        </button>
        <button
          type="button"
          @click="recalculateGoalFromDate"
          class="py-2 px-4 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none"
        >
          Apply
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted, watch } from 'vue'
import Settings, { LengthUnit, WeightUnit } from '@/settings.js'
import { useToast } from 'vue-toastification'
import API from '@/api.js'
// import Button from 'primevue/button'
import PrimaryButton from '@/components/elements/PrimaryButton.vue'
import SecondaryButton from '@/components/elements/SecondaryButton.vue'

// Theme toggle
const isDark = ref(false)
const goalPercentageWarning = ref('')
const uploadFileName = ref('')
const importStatus = ref(null)
const loading = ref(true)
const savingPersonal = ref(false)
const toast = useToast()

// Date modal
const showDateModal = ref(false)
const newGoalStartDate = ref(new Date().toISOString().split('T')[0]) // Today's date

// Settings
const settings = reactive({
  units: {
    weight: Settings.weightUnit,
    length: Settings.lengthUnit,
  },
  height: Settings.height,
  startingWeight: Settings.startingWeight,
  startingDate: Settings.startingDate,
  darkModeDefault: false,
  showTrends: true,
})

const currentGoal = reactive({
  weight: Settings.goalWeight,
  percentage: Settings.goalPercentage,
})

const weightUnitString = ref(WeightUnit.toString(settings.units.weight))
const lengthUnitString = ref(LengthUnit.toString(settings.units.length))

const validateGoalPercentage = () => {
  if (settings.goalPercentage > 20) {
    goalPercentageWarning.value = 'Warning: A weight loss goal of more than 20% may be unhealthy.'
  } else if (settings.goalPercentage < 0) {
    goalPercentageWarning.value = 'Goal percentage cannot be negative.'
  } else {
    goalPercentageWarning.value = ''
  }
}

const recalculateGoalFromDate = () => {
  // In a real app, you would fetch the weight from the selected date
  // and recalculate the goal based on that weight
  console.log('Recalculating goal from date:', newGoalStartDate.value)

  // For demo purposes, let's simulate updating the goal
  settings.startingDate = newGoalStartDate.value

  // Close the modal
  showDateModal.value = false

  // Show confirmation
  alert(`Goal line recalculated from ${newGoalStartDate.value}`)
}

const savePersonalSettings = () => {
  console.log('Saving settings:', settings)
  savingPersonal.value = true

  const newSettings = reactive({
    weightUnit: settings.units.weight,
    lengthUnit: settings.units.length,
    height: settings.height,
    startingWeight: settings.startingWeight,
    startingDate: settings.startingDate,
  })

  API.Settings.Update(newSettings)
    .then((response) => {
      console.log('Settings saved:', response.data)
      if (response.success) {
        toast.success('Settings saved successfully!')
      } else {
        toast.error(response.message)
      }
    })
    .catch((error) => {
      console.error('Error saving settings:', error)
      toast.error('Error saving settings. Please try again later.')
    })
    .finally(() => (savingPersonal.value = false))
}

const handleFileUpload = (event) => {
  const file = event.target.files[0]
  if (!file) return

  uploadFileName.value = file.name

  // Check if it's a CSV file
  if (file.type !== 'text/csv' && !file.name.endsWith('.csv')) {
    importStatus.value = {
      success: false,
      message: 'Please upload a valid CSV file.',
    }
    return
  }

  const reader = new FileReader()
  reader.onload = (e) => {
    try {
      // In a real app, you would parse the CSV and import the data
      console.log('CSV content:', e.target.result)

      // Simulate successful import
      importStatus.value = {
        success: true,
        message: 'Data imported successfully!',
      }
    } catch (error) {
      importStatus.value = {
        success: false,
        message: 'Error importing data: ' + error.message,
      }
    }
  }

  reader.onerror = () => {
    importStatus.value = {
      success: false,
      message: 'Error reading file.',
    }
  }

  reader.readAsText(file)
}

const exportData = () => {}

watch(() => currentGoal.goalPercentage, validateGoalPercentage)
watch(
  () => settings.units.weight,
  (v) => (weightUnitString.value = WeightUnit.toString(v)),
)
watch(
  () => settings.units.length,
  (v) => (lengthUnitString.value = LengthUnit.toString(v)),
)

// Initialize theme on component mount
onMounted(() => {
  API.Settings.Get()
    .then((result) => {
      if (result.success) {
        console.log('result', result)
        settings.units = {
          length: result.data.lengthUnit,
          weight: result.data.weightUnit,
        }
        settings.height = result.data.height
        settings.startingWeight = result.data.startingWeight
      } else {
        toast.error(result.message)
      }
    })
    .catch((error) => {
      console.error('Error loading settings:', error)
      toast.error('Error loading settings. Please try again later.')
    })
    .finally(() => (loading.value = false))
})
</script>

<style>
/* Import KoHo font */
.dot-pattern {
  background-image: radial-gradient(circle, rgba(0, 0, 0, 0.1) 1px, transparent 1px);
  background-size: 20px 20px;
}

/* Dark mode styles */
.dark .dot-pattern {
  background-image: radial-gradient(circle, rgba(255, 255, 255, 0.1) 1px, transparent 1px);
}
</style>
