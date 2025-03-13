import React, { useState, ChangeEvent } from 'react';

interface TableData {
  [key: string]: string | number; 
}

interface DataTableProps {
  columns: TableData[]; 
  data: TableData[];
  onCellChange?: (rowIndex: number, columnKey: string, value: string | number) => void;
}

const DataTable: React.FC<DataTableProps> = ({ columns, data: initialData, onCellChange }) => {
  const [tableData, setTableData] = useState<TableData[]>(initialData);

  const handleChange = (
    rowIndex: number,
    columnKey: string,
    event: ChangeEvent<HTMLInputElement>
  ) => {
    const newValue = event.target.value;
    const newTableData = [...tableData];
    newTableData[rowIndex] = { ...newTableData[rowIndex], [columnKey]: newValue };
    setTableData(newTableData);
    onCellChange && onCellChange(rowIndex, columnKey, newValue);
  };

  return (
    <table className="border border-separate rounded-lg w-full">
        <thead>
        <tr>
            {columns.map((column, index) => (
            <th
            key={index}
            className={`text-center bg-gray-400 ${index === columns.length - 1 ? '' : 'border-r'}`}
            >
            {column.title}
            </th>
            ))}
        </tr>
        </thead>
        <tbody>
        {tableData.map((row, rowIndex) => (
            <tr key={rowIndex}>
            {columns.map((column) => {
            const columnKey = (column.key as String).toLowerCase().replace(/\s+/g, ''); 
            return (
                <td
                key={`${rowIndex}-${columnKey}`}
                className={`border-t ${column === columns[columns.length - 1] ? '' : 'border-r'}`}
                >
                <input
                type={typeof row[columnKey] === 'number' ? 'number' : 'text'}
                value={row[columnKey] as string | number}
                onChange={(e) => handleChange(rowIndex, columnKey, e)}
                className="w-full p-1 "
                />
                </td>
            );
            })}
            </tr>
        ))}
        </tbody>
    </table>
  );
};


export default DataTable;