import React from "react";
import { useEffect, useState } from "react";
import { TextField, Typography, Divider } from "@mui/material";
import DataTable from "../components/DataTable";
import TEFAPIncomeChart from "../components/TEFAPIncomeChart";
import TEFAPEligibility from "../components/TEFAPEligibilityOptions";

const houseMemberCountColumns = [
    { key: 'totalmembers', title: 'Total Members in Household' },
    { key: 'infants', title: 'Infants (<2)' },
    { key: 'toddlers', title: 'Toddlers (2-5)' },
    { key: 'children', title: 'Children (6-17)' },
    { key: 'adults', title: 'Adults (18-59)' },
    { key: 'seniors', title: 'Seniors (60+)'}
];

let houseMemberCountRows = [
    { totalmembers: 5, infants: 1, toddlers: 0, children: 2, adults: 2, seniors: 0 }
];

let houseMemberNameColumns = [
    { key: 'firstname', title: 'First Name' },
    { key: 'lastname', title: 'Last Name' }
];

const houseMemberNameRows = [
    { firstname: 'Cameron', lastname: 'Turner' },
    { firstname: 'Justin', lastname: 'Morris' },
    { firstname: 'Kade', lastname: 'Sivak' }
]

const houseVisitColumns = [
    { key: 'visitdate', title: 'Visit Date' },
    { key: 'staffmember', title: 'Staff Member' }
];

const houseVisitRows = [
    { visitdate: '10/10/2021', staffmember: 'John Doe' },
];

interface ClientPageProps {
    clientId: number;
}

const ClientPage: React.FC<ClientPageProps> = (id) => {
    const [clientData, setClientData] = useState<any>({});
    const [memberCountRows, setMemberCountRows] = useState<any[]>(houseMemberCountRows);
    const [memberNameRows, setMemberNameRows] = useState<any[]>(houseMemberNameRows);
    const [visitRows, setVisitRows] = useState<any[]>(houseVisitRows);
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
            <div className="flex flex-row h-screen w-full justify-between">
                <div className="w-1/2 mx-2 pr-4 flex flex-col">
                        <Typography variant="h6" className="py-4" align="center">Client Eligibility</Typography>
                        <Typography variant="body2">Date of Eligibility Attestation: </Typography>

                        <Divider orientation="horizontal" variant="middle" flexItem />
                        <TEFAPEligibility />
                </div>
                <Divider orientation="vertical" variant="middle" flexItem />
                <div className="w-1/2 mx-2 pl-4 flex flex-col">
                    <Typography variant="h6" className="py-4" align="center">Client Information</Typography>
                    <Typography variant="body2">Date of last change to client information: </Typography>
                    <Divider orientation="horizontal" variant="middle" flexItem />
                    <div className="my-4 flex flex-col">
                        <div className="my-4">
                            <DataTable columns={houseMemberCountColumns} data={memberCountRows} />
                        </div>
                        <TextField
                        id="outlined-multiline-static"
                        label="Other people authorized to pick up food"
                        multiline
                        rows={2}
                        defaultValue="Add authorized people here"
                        variant="outlined"
                        />
                        <div className="flex flex-row mt-5 justify-between">
                            <div className="w-1/2 mr-5" >
                                <DataTable columns={houseMemberNameColumns} data={memberNameRows} />
                            </div>
                            <div className="w-1/2 ml-5">
                                <DataTable columns={houseVisitColumns} data={visitRows} />
                            </div>
                        </div>
                    </div>
                   
                </div>
            </div>
        </div>
    );
}

export default ClientPage;