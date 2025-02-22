import React from "react";
import ClientList from "../components/ClientList";
import SearchBar from "../components/SearchBar";
import { Typography } from "@mui/material";


const Dashboard: React.FC = () => {

    return (
        <div className="flex flex-col items-center my-4">
            <Typography variant="h5" className="pt-8 pb-2">Check in clients</Typography>
            <div className="w-1/3">
                <SearchBar />
            </div>
            <div className="w-1/3 mt-5 flex-grow">
                <ClientList clients={["Cameron Turner", "Justin Morris", "Kade Sivak"]} />
            </div>
            
        </div>
    );
}

export default Dashboard;