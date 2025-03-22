<template>
  <div class="min-h-screen flex flex-col" :class="isDark ? 'dark' : ''">
    <div class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden">
      <!-- Dot pattern background -->
      <div class="absolute inset-0 dot-pattern opacity-10 dark:opacity-20"></div>

      <div class="container mx-auto px-4 py-8 relative z-10">
        <!-- Header with navigation -->
        <header class="flex justify-between items-center mb-8">
          <div class="flex items-center">
            <!-- abstract body logo - woman with hourglass figure in active pose -->
            <div class="w-10 h-10 relative">
              <svg viewbox="0 0 100 100" xmlns="http://www.w3.org/2000/svg" class="w-full h-full">
                <!-- hourglass figure in active pose -->
                <path d="m50,10 c55,10 60,15 60,20 c60,25 58,30 55,35
                         c65,40 65,50 60,55 c55,60 50,60 45,55
                         c40,60 35,60 30,55 c25,50 25,40 35,35
                         c32,30 30,25 30,20 c30,15 35,10 50,10 z"
                      fill="url(#bodygradient)" />

                <!-- head -->
                <circle cx="50" cy="15" r="5" fill="url(#bodygradient)" />

                <!-- arms in active pose -->
                <path d="m55,35 c65,30 75,35 80,40" stroke="url(#bodygradient)" stroke-width="4" stroke-linecap="round" fill="none" />
                <path d="m35,35 c25,30 15,35 10,40" stroke="url(#bodygradient)" stroke-width="4" stroke-linecap="round" fill="none" />

                <!-- legs in active pose -->
                <path d="m45,55 c40,65 40,80 35,90" stroke="url(#bodygradient)" stroke-width="4" stroke-linecap="round" fill="none" />
                <path d="m55,55 c60,65 60,80 65,90" stroke="url(#bodygradient)" stroke-width="4" stroke-linecap="round" fill="none" />

                <!-- gradient for the body -->
                <defs>
                  <lineargradient id="bodygradient" x1="0%" y1="0%" x2="100%" y2="100%">
                    <stop offset="0%" stop-color="#0d9488" /> <!-- teal-600 -->
                    <stop offset="100%" stop-color="#c2410c" /> <!-- orange-700 -->
                  </lineargradient>
                </defs>
              </svg>
            </div>

            <!-- tyalo text with per-letter gradient using koho font and small caps -->
            <div class="ml-3 flex items-center">
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #0d9488, #15803d); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">t</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #15803d, #0e7490); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">y</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #0e7490, #0369a1); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">a</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #0369a1, #c2410c); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">l</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #c2410c, #9a3412); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">o</span>
            </div>
          </div>

          <div class="flex items-center space-x-4">
            <nav class="hidden md:flex space-x-4">
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">dashboard</a>
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">add measurement</a>
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">data table</a>
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">graphs</a>
              <a href="#" class="text-teal-600 dark:text-orange-600 font-medium">settings</a>
            </nav>

            <button @click="toggletheme" class="p-2 rounded-full bg-white dark:bg-gray-800 shadow-md">
              <svg v-if="isdark" xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewbox="0 0 24 24" fill="none" stroke="currentcolor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-orange-700">
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
              <svg v-else xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewbox="0 0 24 24" fill="none" stroke="currentcolor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-teal-600">
                <path d="m21 12.79a9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"></path>
              </svg>
            </button>

            <button class="md:hidden p-2 text-gray-700 dark:text-gray-300" @click="togglemobilemenu">
              <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewbox="0 0 24 24" fill="none" stroke="currentcolor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                <line x1="3" y1="12" x2="21" y2="12"></line>
                <line x1="3" y1="6" x2="21" y2="6"></line>
                <line x1="3" y1="18" x2="21" y2="18"></line>
              </svg>
            </button>
          </div>
        </header>

        <!-- Mobile menu -->
        <div v-if="mobileMenuOpen" class="md:hidden bg-white dark:bg-gray-800 rounded-lg shadow-lg p-4 mb-6">
          <nav class="flex flex-col space-y-3">
            <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600 py-2">Dashboard</a>
            <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600 py-2">Add Measurement</a>
            <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600 py-2">Data Table</a>
            <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600 py-2">Graphs</a>
            <a href="#" class="text-teal-600 dark:text-orange-600 font-medium py-2">Settings</a>
          </nav>
        </div>

        <!-- Settings Form -->
        <div class="bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden">
          <div class="p-8">
            <h2 class="text-2xl font-bold text-gray-800 dark:text-white mb-6">Settings</h2>

            <form @submit.prevent="saveSettings" class="space-y-8">
              <!-- Units of Measurement -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">Units of Measurement</h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label for="weightUnit" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">Weight</label>
                    <select
                      id="weightUnit"
                      v-model="settings.units.weight"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    >
                      <option value="kg">Kilograms (kg)</option>
                      <option value="lb">Pounds (lb)</option>
                    </select>
                  </div>

                  <div>
                    <label for="lengthUnit" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">Length</label>
                    <select
                      id="lengthUnit"
                      v-model="settings.units.length"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    >
                      <option value="cm">Centimeters (cm)</option>
                      <option value="in">Inches (in)</option>
                    </select>
                  </div>
                </div>
              </div>

              <!-- Personal Information -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">Personal Information</h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label for="height" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
                      Height ({{ settings.units.length }})
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
                    <label for="startingWeight" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
                      Starting Weight ({{ settings.units.weight }})
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
                    <label for="startingDate" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
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

              <!-- Goal Settings -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">Goal Settings</h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label for="goalWeight" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
                      Goal Weight ({{ settings.units.weight }})
                    </label>
                    <input
                      type="number"
                      id="goalWeight"
                      v-model="settings.goalWeight"
                      step="0.1"
                      class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                    />
                  </div>

                  <div>
                    <label for="goalPercentage" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
                      Goal as % of Body Weight
                    </label>
                    <div class="relative">
                      <input
                        type="number"
                        id="goalPercentage"
                        v-model="settings.goalPercentage"
                        step="0.1"
                        @input="validateGoalPercentage"
                        class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                      />
                      <div v-if="goalPercentageWarning" class="mt-1 text-sm text-red-600 dark:text-red-400">
                        {{ goalPercentageWarning }}
                      </div>
                    </div>
                  </div>

                  <div class="md:col-span-2">
                    <button
                      type="button"
                      @click="showDateModal = true"
                      class="py-2 px-4 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none"
                    >
                      Recalculate Goal Line from Date
                    </button>
                    <p class="mt-1 text-xs text-gray-500 dark:text-gray-400">
                      Set a new starting point for your goal calculations.
                    </p>
                  </div>
                </div>
              </div>

              <!-- Data Import/Export -->
              <div class="space-y-4">
                <h3 class="text-lg font-medium text-gray-800 dark:text-white">Data Import/Export</h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div>
                    <label class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
                      Import Data
                    </label>
                    <div class="mt-1 flex items-center">
                      <label for="csv-upload" class="cursor-pointer py-2 px-4 border border-gray-300 dark:border-gray-600 rounded-lg text-sm font-medium text-gray-700 dark:text-gray-300 hover:bg-gray-50 dark:hover:bg-gray-700 focus:outline-none">
                        <span>Upload CSV</span>
                        <input id="csv-upload" type="file" accept=".csv" class="sr-only" @change="handleFileUpload" />
                      </label>
                      <span class="ml-3 text-sm text-gray-500 dark:text-gray-400">{{ uploadFileName || 'No file selected' }}</span>
                    </div>
                    <p class="mt-1 text-xs text-gray-500 dark:text-gray-400">
                      Import your measurements from a CSV file. The file should have headers matching the measurement fields.
                    </p>
                    <div v-if="importStatus" class="mt-2 text-sm" :class="importStatus.success ? 'text-green-600 dark:text-green-400' : 'text-red-600 dark:text-red-400'">
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
                        Export all your measurement data to a CSV file that you can open in Excel or other spreadsheet applications.
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
                    <label for="darkMode" class="ml-2 block text-sm text-gray-700 dark:text-gray-300">
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
                    <label for="showTrends" class="ml-2 block text-sm text-gray-700 dark:text-gray-300">
                      Show trends in data table
                    </label>
                  </div>
                </div>
              </div>

              <div class="flex justify-end space-x-4">
                <button
                  type="button"
                  @click="resetSettings"
                  class="py-2 px-4 border border-gray-300 dark:border-gray-600 text-gray-700 dark:text-gray-300 font-medium rounded-lg hover:bg-gray-50 dark:hover:bg-gray-700 transition duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-500"
                >
                  Reset to Defaults
                </button>
                <button
                  type="submit"
                  class="py-2 px-4 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-teal-600 dark:focus:ring-orange-700"
                >
                  Save Settings
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- Date selector modal -->
  <div v-if="showDateModal" class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
    <div class="bg-white dark:bg-gray-800 rounded-lg shadow-xl p-6 max-w-md w-full">
      <h3 class="text-lg font-medium text-gray-800 dark:text-white mb-4">Select New Goal Start Date</h3>

      <div class="mb-4">
        <label for="goalStartDate" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">
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
import { ref, reactive, onMounted, watch } from 'vue';

// Theme toggle
const isDark = ref(false);
const mobileMenuOpen = ref(false);
const goalPercentageWarning = ref('');
const uploadFileName = ref('');
const importStatus = ref(null);

// Date modal
const showDateModal = ref(false);
const newGoalStartDate = ref(new Date().toISOString().split('T')[0]); // Today's date

// Settings
const settings = reactive({
  units: {
    weight: 'kg',
    length: 'cm'
  },
  height: 175,
  startingWeight: 77,
  startingDate: new Date().toISOString().split('T')[0],
  goalWeight: 70,
  goalPercentage: 10,
  darkModeDefault: false,
  showTrends: true
});

// Default settings for reset
const defaultSettings = {
  units: {
    weight: 'kg',
    length: 'cm'
  },
  height: 175,
  startingWeight: 77,
  startingDate: new Date().toISOString().split('T')[0],
  goalWeight: 70,
  goalPercentage: 10,
  darkModeDefault: false,
  showTrends: true
};

const toggleTheme = () => {
  isDark.value = !isDark.value;
  if (typeof localStorage !== 'undefined') {
    localStorage.setItem('tyalo-theme', isDark.value ? 'dark' : 'light');
  }
};

const toggleMobileMenu = () => {
  mobileMenuOpen.value = !mobileMenuOpen.value;
};

const validateGoalPercentage = () => {
  if (settings.goalPercentage > 20) {
    goalPercentageWarning.value = 'Warning: A weight loss goal of more than 20% may be unhealthy.';
  } else if (settings.goalPercentage < 0) {
    goalPercentageWarning.value = 'Goal percentage cannot be negative.';
  } else {
    goalPercentageWarning.value = '';
  }
};

const recalculateGoalFromDate = () => {
  // In a real app, you would fetch the weight from the selected date
  // and recalculate the goal based on that weight
  console.log('Recalculating goal from date:', newGoalStartDate.value);

  // For demo purposes, let's simulate updating the goal
  settings.startingDate = newGoalStartDate.value;

  // Close the modal
  showDateModal.value = false;

  // Show confirmation
  alert(`Goal line recalculated from ${newGoalStartDate.value}`);
};

const saveSettings = () => {
  console.log('Saving settings:', settings);
  // Here you would typically save the settings to localStorage or your database

  // Update the theme based on the darkModeDefault setting
  if (settings.darkModeDefault !== isDark.value) {
    toggleTheme();
  }

  alert('Settings saved successfully!');
};

const resetSettings = () => {
  // Reset all settings to defaults
  Object.keys(defaultSettings).forEach(key => {
    if (typeof defaultSettings[key] === 'object') {
      Object.keys(defaultSettings[key]).forEach(subKey => {
        settings[key][subKey] = defaultSettings[key][subKey];
      });
    } else {
      settings[key] = defaultSettings[key];
    }
  });

  goalPercentageWarning.value = '';
};

const handleFileUpload = (event) => {
  const file = event.target.files[0];
  if (!file) return;

  uploadFileName.value = file.name;

  // Check if it's a CSV file
  if (file.type !== 'text/csv' && !file.name.endsWith('.csv')) {
    importStatus.value = {
      success: false,
      message: 'Please upload a valid CSV file.'
    };
    return;
  }

  const reader = new FileReader();
  reader.onload = (e) => {
    try {
      // In a real app, you would parse the CSV and import the data
      console.log('CSV content:', e.target.result);

      // Simulate successful import
      importStatus.value = {
        success: true,
        message: 'Data imported successfully!'
      };
    } catch (error) {
      importStatus.value = {
        success: false,
        message: 'Error importing data: ' + error.message
      };
    }
  };

  reader.onerror = () => {
    importStatus.value = {
      success: false,
      message: 'Error reading file.'
    };
  };

  reader.readAsText(file);
};

const exportData = (format) => {
  // In a real app, you would fetch all measurements and convert them to CSV

  // Sample data for demonstration
  const data = [
    ['date', 'weight', 'chest', 'waist', 'hips', 'thigh', 'arm', 'bodyFat', 'notes'],
    ['2023-03-15', '75.5', '95.0', '82.3', '98.1', '55.2', '32.4', '18.5', 'Feeling good today!'],
    ['2023-03-08', '76.2', '95.5', '83.0', '98.5', '55.5', '32.2', '19.0', 'Had a tough week'],
    ['2023-03-01', '77.0', '96.0', '84.2', '99.0', '56.0', '32.0', '19.5', 'Starting to see progress']
  ];

  if (format === 'csv') {
    // Convert data to CSV
    const csvContent = data.map(row => row.join(',')).join('\n');

    // Create a blob and download link
    const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', `tyalo-measurements-${new Date().toISOString().split('T')[0]}.csv`);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
};

// Watch for changes to goalPercentage
watch(() => settings.goalPercentage, validateGoalPercentage);

// Initialize theme on component mount
onMounted(() => {
  if (typeof window !== 'undefined' && typeof localStorage !== 'undefined') {
    const savedTheme = localStorage.getItem('tyalo-theme');
    if (savedTheme === 'dark' || (!savedTheme && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
      isDark.value = true;
      settings.darkModeDefault = true;
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

/* Dark mode styles */
.dark {
  color-scheme: dark;
}

.dark .dot-pattern {
  background-image: radial-gradient(circle, rgba(255,255,255,0.1) 1px, transparent 1px);
}
</style>

