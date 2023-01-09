namespace FullCarMultimarca.UI
{
    public class ConsultaCriterio
    {

        public ConsultaCriterio(string value)
        {
            PropertyMember = value;
            DisplayMember = value;
        }
        public ConsultaCriterio(string value, string display)
        {
            PropertyMember = value;
            DisplayMember = display;
        }
        public string PropertyMember { get; set; }
        public string DisplayMember { get; set; }

    }
}
