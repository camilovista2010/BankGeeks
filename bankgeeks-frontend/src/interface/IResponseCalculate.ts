export interface IResponseCalculate {
    success:           boolean;
    message:           string;
    calculationRecord: CalculationRecord | null;
}

export interface CalculationRecord {
    id:          number;
    firstValue:  number;
    secondValue: number;
    result:      number;
    isFibonacci: boolean;
}
