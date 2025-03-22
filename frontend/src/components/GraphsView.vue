<template>
  <div class="min-h-screen flex flex-col" :class="isDark ? 'dark' : ''">
    <div class="flex-1 bg-gradient-to-br from-orange-50 to-teal-50 dark:from-gray-900 dark:to-gray-800 relative overflow-hidden">
      <!-- Dot pattern background -->
      <div class="absolute inset-0 dot-pattern opacity-10 dark:opacity-20"></div>
      
      <div class="container mx-auto px-4 py-8 relative z-10">
        <!-- Header with navigation -->
        <header class="flex justify-between items-center mb-8">
          <div class="flex items-center">
            <!-- Abstract body logo - woman with hourglass figure in active pose -->
            <div class="w-10 h-10 relative">
              <svg viewBox="0 0 100 100" xmlns="http://www.w3.org/2000/svg" class="w-full h-full">
                <!-- Hourglass figure in active pose -->
                <path d="M50,10 C55,10 60,15 60,20 C60,25 58,30 55,35 
                         C65,40 65,50 60,55 C55,60 50,60 45,55 
                         C40,60 35,60 30,55 C25,50 25,40 35,35 
                         C32,30 30,25 30,20 C30,15 35,10 50,10 Z" 
                      fill="url(#bodyGradient)" />
                
                <!-- Head -->
                <circle cx="50" cy="15" r="5" fill="url(#bodyGradient)" />
                
                <!-- Arms in active pose -->
                <path d="M55,35 C65,30 75,35 80,40" stroke="url(#bodyGradient)" stroke-width="4" stroke-linecap="round" fill="none" />
                <path d="M35,35 C25,30 15,35 10,40" stroke="url(#bodyGradient)" stroke-width="4" stroke-linecap="round" fill="none" />
                
                <!-- Legs in active pose -->
                <path d="M45,55 C40,65 40,80 35,90" stroke="url(#bodyGradient)" stroke-width="4" stroke-linecap="round" fill="none" />
                <path d="M55,55 C60,65 60,80 65,90" stroke="url(#bodyGradient)" stroke-width="4" stroke-linecap="round" fill="none" />
                
                <!-- Gradient for the body -->
                <defs>
                  <linearGradient id="bodyGradient" x1="0%" y1="0%" x2="100%" y2="100%">
                    <stop offset="0%" stop-color="#0d9488" /> <!-- teal-600 -->
                    <stop offset="100%" stop-color="#c2410c" /> <!-- orange-700 -->
                  </linearGradient>
                </defs>
              </svg>
            </div>
            
            <!-- Tyalo text with per-letter gradient using KoHo font and small caps -->
            <div class="ml-3 flex items-center">
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #0d9488, #15803d); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">T</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #15803d, #0e7490); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">y</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #0e7490, #0369a1); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">a</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #0369a1, #c2410c); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">l</span>
              <span class="text-2xl font-bold font-koho" style="background: linear-gradient(to right, #c2410c, #9a3412); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">o</span>
            </div>
          </div>
          
          <div class="flex items-center space-x-4">
            <nav class="hidden md:flex space-x-4">
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">Dashboard</a>
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">Add Measurement</a>
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">Data Table</a>
              <a href="#" class="text-teal-600 dark:text-orange-600 font-medium">Graphs</a>
              <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600">Settings</a>
            </nav>
            
            <button @click="toggleTheme" class="p-2 rounded-full bg-white dark:bg-gray-800 shadow-md">
              <svg v-if="isDark" xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-orange-700">
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
              <svg v-else xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-teal-600">
                <path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"></path>
              </svg>
            </button>
            
            <button class="md:hidden p-2 text-gray-700 dark:text-gray-300" @click="toggleMobileMenu">
              <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
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
            <a href="#" class="text-teal-600 dark:text-orange-600 font-medium py-2">Graphs</a>
            <a href="#" class="text-gray-700 dark:text-gray-300 hover:text-teal-600 dark:hover:text-orange-600 py-2">Settings</a>
          </nav>
        </div>
        
        <!-- Graph controls -->
        <div class="bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden mb-6">
          <div class="p-6">
            <div class="flex flex-col md:flex-row justify-between items-start md:items-center mb-6">
              <h2 class="text-2xl font-bold text-gray-800 dark:text-white mb-4 md:mb-0">Progress Visualization</h2>
              
              <div class="flex flex-col sm:flex-row space-y-3 sm:space-y-0 sm:space-x-3 w-full md:w-auto">
                <select v-model="timeRange" class="px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white">
                  <option value="30">Last 30 Days</option>
                  <option value="90">Last 90 Days</option>
                  <option value="180">Last 6 Months</option>
                  <option value="365">Last Year</option>
                  <option value="all">All Time</option>
                  <option value="custom">Custom Period</option>
                </select>
                
                <select v-model="chartType" class="px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white">
                  <option value="line">Line Chart</option>
                  <option value="bar">Bar Chart</option>
                </select>
              </div>
            </div>
            
            <!-- Custom date range (shows only when custom period is selected) -->
            <div v-if="timeRange === 'custom'" class="flex flex-col sm:flex-row gap-4 mb-6">
              <div>
                <label for="startDate" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">Start Date</label>
                <input 
                  type="date" 
                  id="startDate" 
                  v-model="customDateRange.start" 
                  class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                />
              </div>
              
              <div>
                <label for="endDate" class="block text-sm font-medium text-gray-700 dark:text-gray-300 mb-1">End Date</label>
                <input 
                  type="date" 
                  id="endDate" 
                  v-model="customDateRange.end" 
                  class="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-teal-600 dark:focus:ring-orange-700 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:text-white"
                />
              </div>
              
              <div class="self-end">
                <button 
                  @click="applyCustomDateRange" 
                  class="px-4 py-2 bg-gradient-to-r from-teal-600 to-teal-700 dark:from-orange-700 dark:to-orange-800 text-white font-medium rounded-lg shadow-md hover:shadow-lg transition duration-300 focus:outline-none"
                >
                  Apply
                </button>
              </div>
            </div>
            
            <!-- Measurement type selection -->
            <div class="flex flex-wrap gap-2 mb-6">
              <button 
                v-for="type in measurementTypes" 
                :key="type.value"
                @click="toggleMeasurementType(type.value)"
                :class="[
                  'px-3 py-1 rounded-full text-sm font-medium transition-colors',
                  selectedTypes.includes(type.value) 
                    ? 'bg-teal-100 text-teal-800 dark:bg-orange-900 dark:text-orange-100' 
                    : 'bg-gray-100 text-gray-700 dark:bg-gray-700 dark:text-gray-300 hover:bg-gray-200 dark:hover:bg-gray-600'
                ]"
              >
                {{ type.label }}
              </button>
            </div>
          </div>
        </div>
        
        <!-- Weight Chart -->
        <div class="bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden mb-6">
          <div class="p-6">
            <h3 class="text-xl font-bold text-gray-800 dark:text-white mb-4">Weight Progress</h3>
            <div class="h-64 md:h-80">
              <!-- This would be a chart component in a real app -->
              <div class="w-full h-full flex items-center justify-center bg-gray-50 dark:bg-gray-700 rounded-lg">
                <div class="text-center">
                  <svg xmlns="http://www.w3.org/2000/svg" width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="mx-auto mb-4 text-teal-600 dark:text-orange-600">
                    <line x1="4" y1="19" x2="20" y2="19"></line>
                    <polyline points="4 15 8 9 12 11 16 6 20 10"></polyline>
                  </svg>
                  <p class="text-gray-500 dark:text-gray-400">
                    Weight trend over time would appear here.<br>
                    <span class="text-sm">In a real app, this would be a dynamic chart showing your weight progress.</span>
                  </p>
                </div>
              </div>
            </div>
            
            <div class="mt-4 flex justify-between text-sm text-gray-500 dark:text-gray-400">
              <div>Starting: 77.0 {{ units.weight }}</div>
              <div>Current: 75.5 {{ units.weight }}</div>
              <div>Change: -1.5 {{ units.weight }} (-1.9%)</div>
            </div>
          </div>
        </div>
        
        <!-- Body Measurements Chart -->
        <div class="bg-white dark:bg-gray-800 rounded-xl shadow-xl overflow-hidden mb-6">
          <div class="p-6">
            <h3 class="text-xl font-bold text-gray-800 dark:text-white mb-4">Body Measurements</h3>
            <div class="h-64 md:h-80">
              <!-- This would be a chart component in a real app -->
              <div class="w-full h-full flex items-center justify-center bg-gray-50 dark:bg-gray-700 rounded-lg">
                <div class="text-center">
                  <svg xmlns="http://www.w3.org/2000/svg" width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="mx-auto mb-4 text-teal-600 dark:text-orange-600">
                    <rect x="3" y="3" width="18" height="18" rx="2" ry="2"></rect>
                    <line x1="3" y1="9" x2="21" y2="9"></line>
                    <line x1="3" y1="15" x2="21" y2="15"></line>
                    <line x1="9" y1="3" x2="9" y2="21"></line>
                    <line x1="15" y1="3" x2="15" y2="21"></line>
                  </svg>
                  <p class="text-gray-500 dark:text-gray-400">
                    Body measurement trends would appear here.<br>
                    <span class="text-sm">In a real app, this would be a dynamic chart showing changes in your selected body measurements.</span>
                  </p>
                </div>
              </div>
            </div>
            
            <div class="mt-4 grid grid-cols-2 md:grid-cols-4 gap-4 text-sm">
              <div class="bg-gray-50 dark:bg-gray-700 p-3 rounded-lg">
                <div class="text-gray-500 dark:text-gray-400">Chest</div>
                <div class="font-medium text-gray-800 dark:text-white">95.0 {{ units.length }}</div>
                <div class="text-green-600 dark:text-green-400">-1.0 {{ units.length }}</div>
              </div>
              
              <div class="bg-gray-50 dark:bg-gray-700 p-3 rounded-lg">
                <div class="text-gray-500 dark:text-gray-400">Waist</div>
                <div class="font-medium text-gray-800 dark:text-white">82.3 {{ units.length }}</div>
                <div class="text-green-600 dark:text-green-400">-1.9 {{ units.length }}</div>
              </div>
              
              <div class="bg-gray-50 dark:bg-gray-700 p-3 rounded-lg">
                <div class="text-gray-500 dark:text-gray-400">Hips</div>
                <div class="font-medium text-gray-800 dark:text-white">98.1 {{ units.length }}</div>
                <div class="text-green-600 dark:text-green-400">-0.9 {{ units.length }}</div>
              </div>
              
              <div class="bg-gray-50 dark:bg-gray-700 p-3 rounded-lg">
                <div class="text-gray-500 dark:text-gray-400">Body Fat</div>
                <div class="font-medium text-gray-800 dark:text-white">18.5%</div>
                <div class="text-green-600 dark:text-green-400">-1.0%</div>
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

// Units of measurement (would come from settings in a real app)
const units = reactive({
  weight: 'kg',
  length: 'cm'
});

// Chart controls
const timeRange = ref('90');
const chartType = ref('line');
const selectedTypes = ref(['weight', 'waist', 'bodyFat']);

// Custom date range
const customDateRange = reactive({
  start: new Date(Date.now() - 90 * 24 * 60 * 60 * 1000).toISOString().split('T')[0], // 90 days ago
  end: new Date().toISOString().split('T')[0] // Today
});

const measurementTypes = [
  { label: 'Weight', value: 'weight' },
  { label: 'Chest', value: 'chest' },
  { label: 'Waist', value: 'waist' },
  { label: 'Hips', value: 'hips' },
  { label: 'Thigh', value: 'thigh' },
  { label: 'Arm', value: 'arm' },
  { label: 'Body Fat %', value: 'bodyFat' }
];

const toggleTheme = () => {
  isDark.value = !isDark.value;
  if (typeof localStorage !== 'undefined') {
    localStorage.setItem('tyalo-theme', isDark.value ? 'dark' : 'light');
  }
};

const toggleMobileMenu = () => {
  mobileMenuOpen.value = !mobileMenuOpen.value;
};

const toggleMeasurementType = (type) => {
  if (selectedTypes.value.includes(type)) {
    selectedTypes.value = selectedTypes.value.filter(t => t !== type);
  } else {
    selectedTypes.value.push(type);
  }
};

const applyCustomDateRange = () => {
  console.log('Applied custom date range:', customDateRange);
  // Here you would fetch data for the custom date range
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

