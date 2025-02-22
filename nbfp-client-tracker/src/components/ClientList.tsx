import * as React from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import CommentIcon from '@mui/icons-material/Comment';
import IconButton from '@mui/material/IconButton';


interface ClientListProps {
  clients: string[];
}

const ClientList: React.FC<ClientListProps> = ({ clients }) => {
  return (
    <List >
      {clients.map((value) => (
        <ListItem
          key={value}
          divider
          disableGutters
          secondaryAction={
            <IconButton aria-label="go to client's page" color="secondary">
              <CommentIcon />
            </IconButton>
          }
        >
          <ListItemText inset primary={value} />
        </ListItem>
      ))}
    </List>
  );
}

export default ClientList;