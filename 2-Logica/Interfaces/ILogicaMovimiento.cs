using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Logica
{
   public interface ILogicaMovimiento
    {
       void MovimientoAlta(EntidadesCompartidas.Movimiento pMovimiento);
       List<EntidadesCompartidas.Movimiento> ListarTodosLosMovimientos();
       XmlDocument ListaMovs();
    }
}
