<template>
  <div class="min-h-screen flex flex-col" :class="isDark ? 'dark' : ''">
    <div class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden">
      <!-- Dot pattern background -->
      <div class="absolute inset-0 dot-pattern opacity-10 dark:opacity-20"></div>

      <div class="container mx-auto px-4 py-8 relative z-10">
        <!-- Data Table -->
        <div class="bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden">
          <div class="p-6">
            <div class="flex flex-col md:flex-row justify-between items-start md:items-center mb-6">
              <h2 class="text-2xl font-bold text-gray-800 dark:text-white mb-4 md:mb-0">Measurement History</h2>

              <div class="flex flex-col sm:flex-row space-y-3 sm:space-y-0 sm:space-x-3 w-full md:w-auto">
                <div class="relative">
                  <input
                    type="text"
                    placeholder="Search..."
                    class="pl-10 pr-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                  />
                  <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400">
                    <circle cx="11" cy="11" r="8"></circle>
                    <line x1="21" y1="21" x2="16.65" y2="16.65"></line>
                  </svg>
                </div>

                <select class="px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white">
                  <option value="all">All Measurements</option>
                  <option value="last30">Last 30 Days</option>
                  <option value="last90">Last 90 Days</option>
                  <option value="thisYear">This Year</option>
                </select>

                <button class="py-2 px-4 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none">
                  Export Data
                </button>
              </div>
            </div>

            <!-- Column selection -->
            <div class="mb-6">
              <div class="flex flex-col sm:flex-row items-start sm:items-center gap-3">
                <label class="text-sm font-medium text-gray-700 dark:text-gray-300">Column Presets:</label>
                <select
                  v-model="selectedPreset"
                  @change="applyColumnPreset"
                  class="px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                >
                  <option value="all">All Columns</option>
                  <option value="basic">Basic (Date, Weight, Body Fat)</option>
                  <option value="upper">Upper Body (Chest, Arms)</option>
                  <option value="lower">Lower Body (Waist, Hips, Thighs)</option>
                  <option value="custom">Custom Selection</option>
                </select>

                <button
                  @click="showColumnSelector = !showColumnSelector"
                  class="flex items-center text-sm text-teal-600 dark:text-orange-600 hover:underline"
                >
                  <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                    <path d="M12 20h9"></path>
                    <path d="M16.5 3.5a2.121 2.121 0 0 1 3 3L7 19l-4 1 1-4L16.5 3.5z"></path>
                  </svg>
                  Customize Columns
                </button>
              </div>

              <!-- Column selector dropdown -->
              <div v-if="showColumnSelector" class="mt-3 p-4 border rounded-lg bg-gray-50 dark:bg-gray-700 dark:border-gray-600">
                <div class="text-sm font-medium text-gray-700 dark:text-gray-300 mb-2">Select columns to display:</div>
                <div class="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 gap-2">
                  <div v-for="column in availableColumns" :key="column.key" class="flex items-center">
                    <input
                      type="checkbox"
                      :id="`col-${column.key}`"
                      v-model="visibleColumns"
                      :value="column.key"
                      class="h-4 w-4 text-teal-600 focus:ring-teal-600 dark:text-orange-700 dark:focus:ring-orange-700 rounded"
                    />
                    <label :for="`col-${column.key}`" class="ml-2 text-sm text-gray-700 dark:text-gray-300">
                      {{ column.label }}
                    </label>
                  </div>
                </div>
                <div class="mt-3 flex justify-end">
                  <button
                    @click="saveCustomColumns"
                    class="px-3 py-1 text-sm bg-teal-600 dark:bg-orange-700 text-white rounded-md hover:bg-teal-700 dark:hover:bg-orange-800"
                  >
                    Apply
                  </button>
                </div>
              </div>
            </div>

            <div class="overflow-x-auto">
              <table class="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
                <thead class="bg-gray-50 dark:bg-gray-700">
                  <tr>
                    <th v-if="isColumnVisible('date')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Date</th>
                    <th v-if="isColumnVisible('weight')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Weight ({{ units.weight }})</th>
                    <th v-if="isColumnVisible('chest')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Chest ({{ units.length }})</th>
                    <th v-if="isColumnVisible('waist')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Waist ({{ units.length }})</th>
                    <th v-if="isColumnVisible('hips')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Hips ({{ units.length }})</th>
                    <th v-if="isColumnVisible('thigh')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Thigh ({{ units.length }})</th>
                    <th v-if="isColumnVisible('arm')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Arm ({{ units.length }})</th>
                    <th v-if="isColumnVisible('bodyFat')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Body Fat %</th>
                    <th v-if="isColumnVisible('notes')" scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Notes</th>
                    <th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Actions</th>
                  </tr>
                </thead>
                <tbody class="bg-white dark:bg-gray-800 divide-y divide-gray-200 dark:divide-gray-700">
                  <tr v-for="(item, index) in measurements" :key="index" class="hover:bg-gray-50 dark:hover:bg-gray-700">
                    <td v-if="isColumnVisible('date')" class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900 dark:text-white">{{ formatDate(item.date) }}</td>
                    <td v-if="isColumnVisible('weight')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">
                      {{ item.weight }}
                      <span v-if="index > 0" :class="getChangeClass(item.weight, measurements[index-1].weight)">
                        {{ getChange(item.weight, measurements[index-1].weight) }}
                      </span>
                    </td>
                    <td v-if="isColumnVisible('chest')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">{{ item.chest }}</td>
                    <td v-if="isColumnVisible('waist')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">{{ item.waist }}</td>
                    <td v-if="isColumnVisible('hips')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">{{ item.hips }}</td>
                    <td v-if="isColumnVisible('thigh')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">{{ item.thigh }}</td>
                    <td v-if="isColumnVisible('arm')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">{{ item.arm }}</td>
                    <td v-if="isColumnVisible('bodyFat')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">{{ item.bodyFat }}</td>
                    <td v-if="isColumnVisible('notes')" class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-300">
                      <div class="max-w-xs truncate">{{ item.notes }}</div>
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap text-sm font-medium">
                      <div class="flex space-x-2">
                        <button class="text-teal-600 dark:text-orange-600 hover:text-teal-900 dark:hover:text-orange-400">Edit</button>
                        <button class="text-red-600 hover:text-red-900">Delete</button>
                      </div>
                    </td>
                  </tr>

                  <!-- Empty state -->
                  <tr v-if="measurements.length === 0">
                    <td colspan="10" class="px-6 py-10 text-center text-gray-500 dark:text-gray-400">
                      No measurements found. Start by adding your first measurement.
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>

            <!-- Pagination -->
            <div class="flex items-center justify-between mt-6">
              <div class="text-sm text-gray-700 dark:text-gray-300">
                Showing <span class="font-medium">1</span> to <span class="font-medium">{{ measurements.length }}</span> of <span class="font-medium">{{ measurements.length }}</span> results
              </div>

              <div class="flex space-x-2">
                <button class="px-3 py-1 border rounded-md text-sm text-gray-700 dark:text-gray-300 dark:border-gray-600 hover:bg-gray-50 dark:hover:bg-gray-700" disabled>Previous</button>
                <button class="px-3 py-1 border rounded-md text-sm text-gray-700 dark:text-gray-300 dark:border-gray-600 hover:bg-gray-50 dark:hover:bg-gray-700" disabled>Next</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue';

// Theme toggle
const isDark = ref(false);
const mobileMenuOpen = ref(false);
const showColumnSelector = ref(false);
const selectedPreset = ref('all');

// Units of measurement (would come from settings in a real app)
const units = reactive({
  weight: 'kg',
  length: 'cm'
});

// Available columns
const availableColumns = [
  { key: 'date', label: 'Date' },
  { key: 'weight', label: 'Weight' },
  { key: 'chest', label: 'Chest' },
  { key: 'waist', label: 'Waist' },
  { key: 'hips', label: 'Hips' },
  { key: 'thigh', label: 'Thigh' },
  { key: 'arm', label: 'Arm' },
  { key: 'bodyFat', label: 'Body Fat %' },
  { key: 'notes', label: 'Notes' }
];

// Column presets
const columnPresets = {
  all: ['date', 'weight', 'chest', 'waist', 'hips', 'thigh', 'arm', 'bodyFat', 'notes'],
  basic: ['date', 'weight', 'bodyFat'],
  upper: ['date', 'weight', 'chest', 'arm', 'bodyFat'],
  lower: ['date', 'weight', 'waist', 'hips', 'thigh', 'bodyFat'],
  custom: []
};

// Visible columns
const visibleColumns = ref([...columnPresets.all]);

// Sample measurement data
const measurements = ref([
  {
    date: '2023-03-15',
    weight: 75.5,
    chest: 95.0,
    waist: 82.3,
    hips: 98.1,
    thigh: 55.2,
    arm: 32.4,
    bodyFat: 18.5,
    notes: 'Feeling good today!'
  },
  {
    date: '2023-03-08',
    weight: 76.2,
    chest: 95.5,
    waist: 83.0,
    hips: 98.5,
    thigh: 55.5,
    arm: 32.2,
    bodyFat: 19.0,
    notes: 'Had a tough week'
  },
  {
    date: '2023-03-01',
    weight: 77.0,
    chest: 96.0,
    waist: 84.2,
    hips: 99.0,
    thigh: 56.0,
    arm: 32.0,
    bodyFat: 19.5,
    notes: 'Starting to see progress'
  }
]);

const toggleTheme = () => {
  isDark.value = !isDark.value;
  if (typeof localStorage !== 'undefined') {
    localStorage.setItem('tyalo-theme', isDark.value ? 'dark' : 'light');
  }
};

const toggleMobileMenu = () => {
  mobileMenuOpen.value = !mobileMenuOpen.value;
};

const formatDate = (dateString) => {
  const options = { year: 'numeric', month: 'short', day: 'numeric' };
  return new Date(dateString).toLocaleDateString(undefined, options);
};

const getChange = (current, previous) => {
  if (!current || !previous) return '';
  const diff = current - previous;
  return diff > 0 ? `+${diff.toFixed(1)}` : diff.toFixed(1);
};

const getChangeClass = (current, previous) => {
  if (!current || !previous) return '';
  const diff = current - previous;
  // For weight, negative is good (weight loss)
  return diff < 0
    ? 'ml-2 text-green-600 dark:text-green-400'
    : 'ml-2 text-red-600 dark:text-red-400';
};

const isColumnVisible = (columnKey) => {
  return visibleColumns.value.includes(columnKey);
};

const applyColumnPreset = () => {
  if (selectedPreset.value === 'custom') {
    // Keep current selection if custom is selected
    columnPresets.custom = [...visibleColumns.value];
  } else {
    // Apply the selected preset
    visibleColumns.value = [...columnPresets[selectedPreset.value]];
  }
  showColumnSelector.value = false;
};

const saveCustomColumns = () => {
  columnPresets.custom = [...visibleColumns.value];
  selectedPreset.value = 'custom';
  showColumnSelector.value = false;
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

/* Dark mode styles */
.dark {
  color-scheme: dark;
}

.dark .dot-pattern {
  background-image: radial-gradient(circle, rgba(255,255,255,0.1) 1px, transparent 1px);
}
</style>

