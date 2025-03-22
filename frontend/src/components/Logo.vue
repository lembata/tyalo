<template>
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

    <!-- Tyalo text with per-letter gradient using KoHo font and small caps  #c03300-->
    <div class="ml-3 flex items-center">
      <span class="text-2xl font-bold font-koho" style="background: linear-gradient(0.2turn, var(--color-teal-600) 60%, #c03300 70%); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">T</span>
      <span class="text-2xl font-bold font-koho" style="background: linear-gradient(0.2turn, var(--color-teal-600) 60%, #c03300 70%); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">y</span>
      <span class="text-2xl font-bold font-koho" style="background: linear-gradient(0.2turn, var(--color-teal-600) 60%, #c03300 70%); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">a</span>
      <span class="text-2xl font-bold font-koho" style="background: linear-gradient(0.2turn, var(--color-teal-600) 60%, #c03300 70%); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">l</span>
      <span class="text-2xl font-bold font-koho" style="background: linear-gradient(0.2turn, var(--color-teal-600) 60%, #c03300 70%); -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-variant: small-caps;">o</span>
    </div>
  </div>
</template>

<script>
export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: 'Logo'
}
</script>

<style>
/* Import KoHo font */
</style>

