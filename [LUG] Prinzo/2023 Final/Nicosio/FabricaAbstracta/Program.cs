using FabricaAbstracta;
using static System.Console;

IFabrica miFabrica = new FabricaQuimica();

miFabrica.crearProductos();

IProductoLeche miLeche = miFabrica.ObtenProductoLeche;
IProductoSaborizante miSabor = miFabrica.ObtenSabor;

miLeche.producir();
miSabor.obtener();

WriteLine($"Mi malteada es de {miLeche.obtenDatos()} y {miSabor.informacion()}");
WriteLine("-------");

miFabrica = new FabricaNatural();

miFabrica.crearProductos();

miLeche = miFabrica.ObtenProductoLeche;
miSabor = miFabrica.ObtenSabor;
WriteLine($"Mi malteada es de {miLeche.obtenDatos()} y {miSabor.informacion()}");
