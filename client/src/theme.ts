import { createTheme } from '@mui/material/styles';
import { red } from '@mui/material/colors';

// Create a theme instance.
const theme = createTheme({
    palette: {
        primary: {
            main: '#26a69a',
            dark: '#00766c'
        },
        secondary: {
            main: '#d95965',
            dark: '#a6273e'
        },
        error: {
            main: red.A400,
        },
        background: {
            default: '#fff',
        },
    },
    // typography: {
    //     fontFamily: 'Electrolize, sans-serif',
    // },
});

export default theme;