import * as React from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import { useNavigate } from 'react-router-dom';
import { Button } from '@mui/material';

interface ClientData {
  first: string;
  last: string;
  id: number;
}

interface ClientListProps {
  clients: ClientData[];
}




const ClientList: React.FC<ClientListProps> = ({ clients }) => {
  const navigate = useNavigate();

  const onClientClick = (client : ClientData) => {
    console.log(client);
    navigate(`/client/${client.id}`);
  }


  return (
    <List >
      {clients.map((client) => (
        <ListItem
          key={client.id}
          divider
          disableGutters
          secondaryAction={
            // <IconButton aria-label="go to client's page" color="secondary">
            //   <CommentIcon />
            // </IconButton>
            <Button variant="outlined" color="primary" size="small" onClick={() => onClientClick(client)}>
              Go to Client Page
            </Button>
          }
        >
          <ListItemText inset primary={client.first + ' ' + client.last} />
        </ListItem>
      ))}
    </List>
  );
}

export default ClientList;