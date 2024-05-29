using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;
using System.Xml;

namespace Logica
{
    internal class LogicaMovimiento:ILogicaMovimiento
    {
        //Singleton
        private static LogicaMovimiento _instancia = null;
        private LogicaMovimiento() { }
        public static LogicaMovimiento GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaMovimiento();
            return _instancia;
        }

        //operaciones
        public void MovimientoAlta(Movimiento pMovimiento)
        {
            //Verificacion de retiro en cuenta corriente por el minimo
            if ((pMovimiento.UnaCuenta is CuentaCorriente) && (pMovimiento.TipoMov=="R"))
            {
                double _cuenta = pMovimiento.UnaCuenta.SaldoCuenta - pMovimiento.MontoMov;
                if (_cuenta < ((CuentaCorriente)pMovimiento.UnaCuenta).MinimoCta)
                    throw new Exception("El retiro supera el monto minimo de la cuenta");
            }

            //Verificacion en cualer tipo de moviento para caja de ahorro. Solo gratis 25 movs por mes
            if (pMovimiento.UnaCuenta is CuentaCAhorro) 
            {
                if (((CuentaCAhorro)pMovimiento.UnaCuenta).MovsCta >=25)
                    throw new Exception("Supera la cantidad d Movimientos Gratis");
            }

            FabricaPersistencia.GetPersitenciaMovimiento().Alta(pMovimiento);
        }

        public List<EntidadesCompartidas.Movimiento> ListarTodosLosMovimientos()
        {
            return (Persistencia.FabricaPersistencia.GetPersitenciaMovimiento().ListarTodosLosMovimientos());
        }

        public XmlDocument ListaMovs()
        {
            //obtengo datos
            List<Movimiento> _lista = FabricaLogica.GetLogicaMovimiento().ListarTodosLosMovimientos();

            //convierto a xml
            XmlDocument _Documento = new XmlDocument();
            _Documento.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <Raiz> </Raiz>");
            XmlNode _raiz = _Documento.DocumentElement;

            //recorro la lista para crear los nodos
            foreach (Movimiento unM in _lista)
            {
                XmlElement _IdMov = _Documento.CreateElement("IdMov");
                _IdMov.InnerText = unM.IdMov.ToString();

                XmlElement _NumCta = _Documento.CreateElement("NumCta");
                _NumCta.InnerText = unM.UnaCuenta.NumCta.ToString();

                XmlElement _FechaMov = _Documento.CreateElement("FechaMov");
                _FechaMov.InnerText = unM.FechaMov.ToString("yyyyMMdd");

                XmlElement _MontoMov = _Documento.CreateElement("MontoMov");
                _MontoMov.InnerText = unM.MontoMov.ToString();

                XmlElement _TipoMov = _Documento.CreateElement("TipoMov");
                _TipoMov.InnerText = unM.TipoMov;

                XmlElement _Nodo = _Documento.CreateElement("Movimiento");
                _Nodo.AppendChild(_IdMov);
                _Nodo.AppendChild(_NumCta);
                _Nodo.AppendChild(_FechaMov);
                _Nodo.AppendChild(_MontoMov);
                _Nodo.AppendChild(_TipoMov);

                _raiz.AppendChild(_Nodo);

            }

            //retorno los datos en formato XML
            return _Documento;
        }

  

    }
}
