using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
    /// <summary>
    /// Clase que mapea los permisos a constantes para no tener que recordar los códigos cada vez que se los requiere
    /// </summary>
    public static class ConstPermisos
    {

        //Seguridad
        public const string GESTIONAR_USUARIOS = "PS1001";
        public const string GESTIONAR_PARAMETROS_SEGURIDAD = "PS1002";
        public const string VER_LOGS_DEL_SISTEMA = "PS1003";
        public const string GESTIONAR_PERMISOS = "PS1004";
        public const string GESTIONAR_BACKUPS = "PS1005";

        //Gestion
        public const string GESTIONAR_MARCAS = "PS1006";
        public const string GESTIONAR_MODELOS = "PS1007";
        public const string GESTIONAR_COLORES = "PS1008";
        public const string GESTIONAR_FORMAS_PAGO = "PS1009";
        public const string GESTIONAR_PARAMETROS_VENTAS = "PS1010";
        public const string GESTIONAR_PARAMETROS_COMISIONES = "PS1011";
        public const string GESTIONAR_CLIENTES = "PS1012";
        public const string GESTIONAR_UNIDADES = "PS1013";
        public const string GESTIONAR_TIPO_CONTACTO = "PS1014";

        //Ventas        
        public const string STOCK_VER = "PS2001";
        public const string STOCK_PONER_EN_OFERTA = "PS2002";

        public const string OPERACION_VER = "PS2003";
        public const string OPERACION_CARGAR_VENTA = "PS2004";
        public const string OPERACION_VER_MIS_VENTAS = "PS2005";
        public const string OPERACION_VER_TODAS_LAS_VENTAS = "PS2006";
        public const string OPERACION_AUTORIZAR = "PS2007";
        public const string OPERACION_MODIFICAR_VENTA = "PS2008";
        public const string OPERACION_ANULAR_VENTA = "PS2009";

        //Liquidacion
        public const string LIQUIDACION_VER = "PS3001";
        public const string LIQUIDACION_CREAR = "PS3002";
        public const string LIQUIDACION_ELIMINAR = "PS3003";

    }
}
