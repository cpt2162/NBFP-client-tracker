import React from 'react';
import { TextField, InputAdornment } from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';


interface SearchBarProps {
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const SearchBar: React.FC<SearchBarProps> = ({ onChange }) => {
    return (
        <TextField
            placeholder="Search..."
            fullWidth
            onChange={onChange}
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