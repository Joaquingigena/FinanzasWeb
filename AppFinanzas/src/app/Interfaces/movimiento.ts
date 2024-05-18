export interface Movimiento {

    id:number;
    usuarioId:number;
    tipoMovimientoId:number;
    descripcion:string;
    monto: number;
    categoriaId: number;
    fecha: Date;
}
