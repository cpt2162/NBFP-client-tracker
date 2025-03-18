import React from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';

const TEFAPIncomeChart: React.FC = () => {
    return (
        <TableContainer className='border' component={Paper}>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Household Size</TableCell>
                        <TableCell>1</TableCell>
                        <TableCell>2</TableCell>
                        <TableCell>3</TableCell>
                        <TableCell>4</TableCell>
                        <TableCell>5</TableCell>
                        <TableCell>6</TableCell>
                        <TableCell>7</TableCell>
                        <TableCell>8</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody >
                    <TableRow>
                        <TableCell>Anual Income</TableCell>
                        <TableCell>$33,885</TableCell>
                        <TableCell>$45,990</TableCell>
                        <TableCell>$58,095</TableCell>
                        <TableCell>$70,200</TableCell>
                        <TableCell>$82,305</TableCell>
                        <TableCell>$94,410 </TableCell>
                        <TableCell>$106,515</TableCell>
                        <TableCell>$118,620</TableCell>
                    </TableRow>
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default TEFAPIncomeChart;