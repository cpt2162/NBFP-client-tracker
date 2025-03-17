import React from "react";
import { useEffect, useState } from "react";
import ClientList from "../components/ClientList";
import SearchBar from "../components/SearchBar";
import { Typography } from "@mui/material";



const Dashboard: React.FC = () => {
    interface ClientData {
        first: string;
        last: string;
        id: number;
    }
    const [searchValue, setSearchValue] = useState<string>("");
    const [clients, setClients] = useState<ClientData[]>([{first: "John", last: "Doe", id: 1}, {first: "Jane", last: "Smith", id: 2}]);
    const [error, setError] = useState<string>("");


    // useEffect(() => {
    //     fetchClients();
    // }, );

    const fetchClients = async () => {
        try{
            const response = await fetch("http://localhost:3001/clients");
            const data = await response.json();
            setClients(data);
        } catch (error) {
            console.error(error);
        }
    }

    const onSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearchValue(e.target.value);
        setClients(clients.filter((client) => 
            client.first.includes(e.target.value) || client.last.includes(e.target.value)
        ));
    }


    return (
        <div className="flex flex-col items-center my-4">
            <Typography variant="h5" className="pt-8 pb-2">Check in clients</Typography>
            <div className="w-1/3">
                <SearchBar onChange={(e) => onSearchChange(e)}/>
            </div>
            <div className="w-1/3 mt-5 flex-grow">
                <ClientList clients={clients} />
            </div>
            
        </div>
    );
}

export default Dashboard;