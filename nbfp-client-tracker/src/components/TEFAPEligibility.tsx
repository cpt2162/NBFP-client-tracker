import * as React from 'react';
import { Radio, RadioGroup, FormControl, FormControlLabel, FormLabel, Typography, List, ListItem, ListItemText, Checkbox }  from '@mui/material/';
import { Check } from '@mui/icons-material';
import TEFAPIncomeChart from './TEFAPIncomeChart';
const TEFAPEligibility: React.FC = () => {
  const [value, setValue] = React.useState('female');

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setValue((event.target as HTMLInputElement).value);
  };

  return (
    <div className='my-4'>
        <div>
          <Typography color='primary' className='!font-semibold'>Select how the client is eligible for TEFAP </Typography>
          <div className='flex flex-col border rounded-lg'>
              <div className='flex flex-row items-start my-2'>
                  <Checkbox className='!pt-1'/>
                  <span> <b>Categorical:</b> Clients are categorically eligible to receive USDA Foods through TEFAP if their household
                  participates in any of the following programs: SNAP, WIC, TANF, Medicaid, or SSI.</span>
              </div>
              <div className='flex flex-row items-start'>
                  <Checkbox className='!pt-1'/>
                  <span> <b>Income:</b> If the client's gross annual household income is at or below the amount listed for the number of people in
                  their household, they are eligible to receive USDA Foods through TEFAP.</span>
              </div>
              <div className='p-4'>
                  <TEFAPIncomeChart />
              </div>
          </div>
        </div>
        <div className='my-6'>
            <Typography color='primary' className='!font-semibold'>Attest the client's information is correct</Typography>
            <div className='border rounded-lg'>
              <div className='flex flex-row items-end'>
                  <Checkbox className='!pb-0'/>
                  <span> Checking this box asserts the following statements are true:</span>
              </div>
              <List className='left-4'>    
                  <ListItem className='my-0 !py-0'>
                    <ListItemText
                      primary="1: The recipient’s name, address (to the extent practicable) and household size is correct"
                    />
                  </ListItem>
                  <ListItem className='my-0 !py-0'>
                    <ListItemText
                      primary="2: The recipient resides within New York State (there is no minimum length of residency required)."
                    />
                  </ListItem>
                  <ListItem className='my-0 !py-0'>
                  <ListItemText
                      primary="3: The recipient meets Categorical or Income requirements of TEFAP eligibility guidelines above."
                    />
                  </ListItem>
                  <ListItem className='my-0 !py-0'>
                    <ListItemText
                      primary="4: This food is for the recipient’s home consumption only, and will not be sold, traded, or bartered."
                    />
                  </ListItem>
                  <ListItem className='my-0 !py-0'>
                    <ListItemText
                      primary="5: The recipient is aware of their civil rights as described in the USDA Nondiscrimination Statement."
                    />
                  </ListItem>
              </List>
          </div>
        </div>
    </div>
  )
}

export default TEFAPEligibility;