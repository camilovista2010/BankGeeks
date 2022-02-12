import React from "react";   
import { IResponseCalculate } from "../interface/IResponseCalculate";

export const responsePayload : IResponseCalculate = {
    success:           false,
    message:           "",
    calculationRecord:  null
}
 
const valueContext = {loading : false , response : responsePayload };

function setvalueContext(request: any) {
  return request;
} 

export const ResponseContext = React.createContext({ valueContext  , setvalueContext  }); 