using PatronBuilder;
using static System.Console;

Director miDirector = new();

BuilderNormal normal = new();
miDirector.Construye(normal);
Producto auto1 = normal.ObtenProducto();
auto1.MostrarAuto();

WriteLine("------------------");

BuilderDeportivo deportivo = new();
miDirector.Construye(deportivo);
Producto auto2 = deportivo.ObtenProducto();
auto2.MostrarAuto();