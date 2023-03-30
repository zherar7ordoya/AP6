using Acercamiento1.Models;
using Acercamiento1.Views;

namespace Acercamiento1.Presenters
{
    public class CRectanguloPresenter
    {
        IRectangulo rectanguloView;
        public CRectanguloPresenter(IRectangulo vista)
        { rectanguloView = vista; }

        public void CalculaArea()
        {
            CRectangulo rectangulo = new CRectangulo();
            rectangulo.Largo = double.Parse(rectanguloView.TextoLargo);
            rectangulo.Ancho = double.Parse(rectanguloView.TextoAncho);
            rectanguloView.TextoArea = rectangulo.CalculaArea().ToString();
        }
    }
}
