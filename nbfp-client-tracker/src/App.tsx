import Dashboard from './pages/Dashboard';
import Navbar from './components/NavBar';
import { ThemeProvider } from '@mui/material/styles';
import theme from './theme';

function App() {
  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <Navbar />
        <Dashboard />
      </div>
    </ThemeProvider>
  );
}

export default App;
