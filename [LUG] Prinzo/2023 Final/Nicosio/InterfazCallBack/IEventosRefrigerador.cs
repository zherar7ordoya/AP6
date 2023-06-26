namespace InterfazCallBack
{
    /// <summary>
    /// Eventos que tendrá refrigerador.
    /// </summary>
    interface IEventosRefrigerador
    {
        void EReservasBajas(int pKilos);
        void ElDescongelado(int pGrados);
    }
}
