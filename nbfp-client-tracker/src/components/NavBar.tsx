import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import AddIcon from '@mui/icons-material/Add';
import AdminPanelSettingsIcon from '@mui/icons-material/AdminPanelSettings';
import Box from '@mui/material/Box';

const Navbar: React.FC = () => {
    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                    <img src="/path/to/logo.png" alt="Logo" style={{ marginRight: '10px', verticalAlign: 'middle' }} />
                    Site Title
                </Typography>
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                    <IconButton color="inherit">
                        <AddIcon />
                        <Typography variant="body1" component="span" sx={{ marginLeft: '5px' }}>
                            Add Client
                        </Typography>
                    </IconButton>
                    <IconButton color="inherit">
                        <AdminPanelSettingsIcon />
                        <Typography variant="body1" component="span" sx={{ marginLeft: '5px' }}>
                            Admin
                        </Typography>
                    </IconButton>
                </Box>
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;