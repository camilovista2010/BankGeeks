import { Backdrop, CircularProgress } from "@mui/material"; 
import React, { FC } from 'react'; 
import { useContext } from 'react';
import { ResponseContext } from '../context/ResponseContext';

const LoadingPage: FC = () => {
 
  const { valueContext , setvalueContext  }  = useContext(ResponseContext); 

  return ( 
    <>
      { valueContext.loading ? <CircularProgress color="inherit" /> : <div></div>}
    </> 
  );
};

export default LoadingPage;