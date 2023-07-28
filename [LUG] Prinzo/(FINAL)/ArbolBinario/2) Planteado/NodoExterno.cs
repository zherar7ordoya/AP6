namespace BinaryTree
{
    /// <summary>
    /// El nodo no necesita mayores explicaciones: nombre, izquierda, derecha
    /// </summary>
    public class NodoExterno
    {
        private string nombre;

        public string Nombre {
            get => nombre;
            //set => nombre = value.PadLeft(2).PadRight(3);
            set => nombre = value.PadLeft(value.Length + 1).PadRight(value.Length + 2);
        }
        public NodoExterno Izquierda { get; set; }
        public NodoExterno Derecha { get; set; }
    }
}
