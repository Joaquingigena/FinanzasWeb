export interface Movimiento {

    id:number;
    usuarioId:number;
    tipoMovimientoId:number;
    descripcionTipoMovimiento: string;
    descripcion:string;
    monto: number;
    categoriaId: number;
    descripcionCategoria:string;
    fecha: Date;
}
