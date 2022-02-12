import React, { useState } from 'react';
import './App.css';
import CssBaseline from '@mui/material/CssBaseline';
import { Box, Dialog, DialogContent, DialogTitle, Divider } from '@mui/material';
import LoadingPage from './components/Loading';
import FrmCalculate from './components/FrmCalculate';
import ResponseCalculate from './components/ResponseCalculate';
import { ResponseContext, responsePayload } from './context/ResponseContext';



function App() {

  const [valueContext , setvalueContext] = useState({loading : false , response : responsePayload});

  return (
    <ResponseContext.Provider value={{ valueContext , setvalueContext  }} >
        <CssBaseline />
      <Dialog
        fullWidth
        open={true}
        maxWidth="xs"
        sx={{
          backdropFilter: "blur(5px)",
          //other styles here
        }}
      >
        <DialogTitle>Sumar dos valores</DialogTitle>
        <DialogContent> 
          <FrmCalculate/> 
          <Divider />
          <LoadingPage/>
          <Divider />
          <ResponseCalculate />
        </DialogContent> 
      </Dialog> 
      <Box
        sx={{
          minHeight: "100vh",
          backgroundSize: "cover",
        }}
      ></Box>
    </ResponseContext.Provider>
  );
}

export default App;
