import { categoriasMontos } from "./categoriasMontos"
import { MovimientoXMes } from "./movimientosXMes"

export interface Reporte{

    idUsuario:number,
    balance: string,
    totalIngresos:string,
    totalGastos:string
    movimientosXMes: MovimientoXMes[]
    categoriasXMovimientos: categoriasMontos[]
}