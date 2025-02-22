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
        <AppBar position="static" className='flex flex-row justify-between align-center'>
            <Toolbar>
                <Typography variant="h4" component="div" className='flex-grow text-center'>
                    <div className='absolute left-1/2 transform -translate-x-1/2 bottom-2'>
                        North Buffalo Food Pantry
                    </div>
                </Typography>
                <Box className='flex flex-row float-right'>
                    <IconButton color="inherit">
                        <AddIcon />
                        <Typography variant='button' className='ml-1'>
                            Add Client
                        </Typography>
                    </IconButton>
                    <IconButton color="inherit">
                        <AdminPanelSettingsIcon />
                        <Typography variant='button' className='ml-1'>
                            Admin
                        </Typography>
                    </IconButton>
                </Box>
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;