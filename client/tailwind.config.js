const { grey } = require('@mui/material/colors');

 /** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js,ts,tsx}"],
  theme: {
    fontFamily: {
      mono: ["Fira Code", "monospace"]
    },
    colors: {
      primary: {
        resting: '#FF6363',
        hover: '#FF7A7A'
      },
      secondary: {
        resting: '#FFA500',
        hover: '#FFD700'
      }
    }
  },
  plugins: []
}