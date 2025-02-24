import Dashboard from './pages/Dashboard';
import Navbar from './components/NavBar';
import { ThemeProvider } from '@mui/material/styles';
import theme from './theme';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ClientPage from './pages/ClientPage';
import ClientPageWrapper from './pages/ClientPageWrapper';


function App() {
  return (
    <ThemeProvider theme={theme}>
      <Navbar />
      <BrowserRouter>
        <Routes>
          <Route path="" element={<Dashboard/>} />
          <Route path="Client/:clientId" element={<ClientPageWrapper/>} />
        </Routes>
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
