import React from "react";
import ClientList from "../components/ClientList";
import SearchBar from "../components/SearchBar";


const Dashboard: React.FC = () => {

    return (
        <div>
        <h1>Dashboard</h1>
        <div className="w-1/3">
            <SearchBar />
        </div>
        <ClientList clients={["Client 1", "Client 2", "Client 3"]} />
        </div>
    );
}

export default Dashboard;