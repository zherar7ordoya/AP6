namespace PatronComposite
{
    interface IComponente<T>
    {
        T Nombre { get; set; }
        void Adiciona(IComponente<T> pElemento);
        IComponente<T> Borra(T pElemento);
        IComponente<T> Busca(T pElemento);
        string Muestra(int pProfundidad);
    }

}
