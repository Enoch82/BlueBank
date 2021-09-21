export interface Cliente {
    clienteId?:number;
    nombre?:string;
    apellido?:string;
    tipoDocumento?:string;
    documento?:string;
    email?:string;
    password?:string;
}
export interface loginUser {
    email?:string;
    password?:string;
}

export interface Cuenta {
    cuentaId:number;
    fechaCreacion:Date;
    saldoInicial:number;
    clienteId:number;
    productoId:number;

}

export interface Movimiento {
    movimientoId:number;
    fechaOperacion:Date;
    concepto:string;
    cargos:number;
    abonos:number;
    cuentaId:number
}

export interface CustomeResponse {
    data: object;
    sucess:number;
    message: string;
}