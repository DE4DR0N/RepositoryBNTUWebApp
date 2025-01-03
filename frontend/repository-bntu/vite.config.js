import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5222',
        changeOrigin: true,
        secure: false, // Установите false, если у вашего backend используется самоподписанный сертификат
        }
    }
  }
})
