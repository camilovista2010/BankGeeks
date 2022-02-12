import React, { FC, useContext } from 'react'; 
import Card from '@mui/material/Card'; 
import CardContent from '@mui/material/CardContent'; 
import Typography from '@mui/material/Typography'; 
import { Alert } from '@mui/material';
import { ResponseContext } from '../context/ResponseContext';

const ResponseCalculate: FC = () => { 
    
  const { valueContext , setvalueContext  }  = useContext(ResponseContext); 

  return (
    <> 
     {valueContext.response.success ? 
      <Card sx={{ minWidth: 275 }} >
      <CardContent>
          <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
          La sumatoria entre {valueContext.response.calculationRecord?.firstValue} + {valueContext.response.calculationRecord?.secondValue} es : {valueContext.response.calculationRecord?.result} 
          </Typography>
          <Typography variant="h5" component="div">
          Este valor {valueContext.response.calculationRecord?.isFibonacci ? 'SI' : 'NO'} corresponde a la secuencia fibonacci.
          </Typography>
      </CardContent>
      </Card>
      :
        valueContext.response.message !== '' ? 
        <Alert severity="error">
          <span id="msnErrorFile">{valueContext.response.message}</span>
        </Alert> : <></>
    }
    </>
  );
};

export default ResponseCalculate;