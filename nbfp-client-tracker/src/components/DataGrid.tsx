import * as React from 'react';
import { DataGrid, GridColDef } from '@mui/x-data-grid';

interface DataTableProps {
    rows: any[];
    columns: GridColDef[];
    pageSize: number;
}

const DataTable = (props: DataTableProps) => {
    return (
        <div style={{ height: 400, width: '100%' }}>
            <DataGrid
                rows={props.rows}
                columns={props.columns}
                pageSizeOptions={[props.pageSize]}
                disableRowSelectionOnClick
            />
        </div>
    );
}

export default DataTable;