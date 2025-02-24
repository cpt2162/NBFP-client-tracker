import React from 'react';
import { useParams } from 'react-router-dom';
import ClientPage from './ClientPage';

const ClientPageWrapper: React.FC = () => {
  const { clientId } = useParams<{ clientId: string }>();
  const clientIdNumber = Number(clientId);
  return <ClientPage clientId={clientIdNumber} />;
};

export default ClientPageWrapper;