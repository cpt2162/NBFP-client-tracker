import React from "react";
import { useEffect, useState } from "react";
import { TextField, Typography } from "@mui/material";
import DataTable from "../components/DataTable";
import { GridColDef } from "@mui/x-data-grid";

const houseMemberCountColumns: GridColDef[] = [
    { field: 'totalMembers', headerName: 'Total Members in Household', width: 200 },
    { field: 'infants', headerName: 'Infants (<2)', width: 130 },
    { field: 'toddlers', headerName: 'Toddlers (2-5)', width: 130 },
    { field: 'children', headerName: 'Children (6-17)', width: 130 },
    { field: 'adults', headerName: 'Adults (18-59)', width: 130 },
    { field: 'seniors', headerName: 'Seniors (60+)', width: 130 }
];

const houseMemberCountRows = [
    { id: 1, totalMembers: 5, infants: 1, toddlers: 0, children: 2, adults: 2, seniors: 0 }
];

const houseMemberNameColumns: GridColDef[] = [
    { field: 'firstName', headerName: 'First Name', width: 200 },
    { field: 'lastName', headerName: 'Last Name', width: 200 }
];

const houseMemberNameRows = [
    { id: 1, firstName: 'Cameron', lastName: 'Turner' },
    { id: 2, firstName: 'Justin', lastName: 'Morris' },
    { id: 3, firstName: 'Kade', lastName: 'Sivak' }
]

const houseVisitColumns: GridColDef[] = [
    { field: 'visitDate', headerName: 'Visit Date', width: 100 },
    { field: 'staffMember', headerName: 'Staff Member', width: 200 }
];

const houseVisitRows = [
    { id: 1, visitDate: '10/10/2021' }
];

interface ClientPageProps {
    clientId: number;
}

const ClientPage: React.FC<ClientPageProps> = (id) => {
    const [clientData, setClientData] = useState<any>({});
    useEffect(() => {

    }, []);

    const fetchClientData = async () => {
        try {
            const response = await fetch(`http://localhost:3001/clients/${id}`);
            const data = await response.json();
            setClientData(data);
        } catch (error) {
            console.error(error);
        }
    }

    return (
        <div className="flex flex-col items-center my-4 mx-4">
            <Typography variant="h2" className="py-2">Cameron Turner</Typography>
            <Typography variant="subtitle1" className="pb-2">Address</Typography>
            <div className="flex flex-row w-full justify-between">
                <div className="w-1/2 px-2 flex flex-col">
                    <DataTable columns={houseMemberCountColumns} rows={houseMemberCountRows} pageSize={2}/>
                    <div className="flex flex-row w-full justify-between">
                        <TextField
                            id="outlined-multiline-static"
                            label="Other people authorized to pick up food"
                            multiline
                            rows={2}
                            defaultValue="Add authorized people here"
                            variant="outlined"
                            sx={{ mt: 2 }}
                        />
                        <DataTable columns={houseVisitColumns} rows={houseVisitRows} pageSize={10}/>
                    </div>
                </div>
                <div className="w-1/2 px-2">
                    <DataTable columns={houseMemberNameColumns} rows={houseMemberNameRows} pageSize={10}/>
                </div>
            </div>
        </div>
    );
}

export default ClientPage;