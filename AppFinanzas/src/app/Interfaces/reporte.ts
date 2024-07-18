import { MovimientoXMes } from "./movimientosXMes"

export interface Reporte{

    idUsuario:number,
    balance: string,
    totalIngresos:string,
    totalGastos:string
    movimientosXmes: MovimientoXMes[]
}