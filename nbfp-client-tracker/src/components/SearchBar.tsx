import React from 'react';
import { TextField, InputAdornment } from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';

const SearchBar: React.FC = () => {
    return (
        <TextField
            placeholder="Search..."
            fullWidth
            sx={{ border: "2px", borderRadius: '5px' }}
            slotProps={{
                input: {
                    endAdornment: (
                        <InputAdornment position="start">
                            <SearchIcon />
                        </InputAdornment>
                    ),
                },
            }}
        />
    );
};

export default SearchBar;