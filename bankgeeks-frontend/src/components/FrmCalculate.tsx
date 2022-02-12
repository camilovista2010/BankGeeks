import React, { FC, useContext } from 'react';
import { useFormik } from 'formik';
import * as Yup from "yup";
import { IRequestCalculate } from '../interface/IRequestCalculate';
import { Box, Button, TextField } from '@mui/material';  
import { ResponseContext } from '../context/ResponseContext'; 


const FrmCalculate: FC = () => { 

  const { valueContext , setvalueContext  }  = useContext(ResponseContext); 

  const sendDataApi = (request: IRequestCalculate) => { 
    
    setvalueContext({loading : true , response : {  success:  false, message: "" , calculationRecord: null }});
    
    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    const raw = JSON.stringify(request); 

    fetch("http://localhost:2742/api/Calculator", {
      method: 'POST',
      headers: myHeaders,
      body: raw,
      redirect: 'follow'
    })
      .then(response => response.json())
      .then(result =>  setvalueContext({loading : false , response : result}))
      .catch(error => setvalueContext({loading : false , response : {  success:  false, message: error , calculationRecord: null } }));  

  }

    const initialValues: IRequestCalculate = {
        firstValue : 0,
        secondValue: 0
    }

    const formik = useFormik({
        initialValues: initialValues, 
        validationSchema: Yup.object({
          firstValue:Yup.string().required("Required"),
          secondValue:Yup.string().required("Required")
        }),
        onSubmit: (values , actions ) => {  
            sendDataApi(values);
        },
    });  

  return (
    <form id="ContainerDivAdd" onSubmit={formik.handleSubmit} >
            <Box
                component="form"
                sx={{
                    '& > :not(style)': { m: 1, width: '30ch' },
                    width: 800,
                    maxWidth: '100%'
                }}
                noValidate
                autoComplete="off"
                > 
                <TextField onChange={formik.handleChange} type="number" id="firstValue" name="firstValue" label="Primer Número" variant="outlined"  size="small" required  /> 
                <br></br>
                <TextField onChange={formik.handleChange} type="number" id="secondValue" name="secondValue" label="Segundo Número" variant="outlined"  size="small" required  />
            </Box> 
            <Button color="success" variant="contained"  size="large" type="submit" disabled={!(formik.isValid && formik.dirty)} >CALCULAR </Button>
    </form>
  );
};

export default FrmCalculate;