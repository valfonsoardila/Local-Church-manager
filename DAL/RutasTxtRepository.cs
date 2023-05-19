using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class RutasTxtRepository
    {
        private string ruta = @"RutasDeGuardado.config";
        public void Guardar(RutasTxt rutasTxt)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{rutasTxt.RutaFacturasVenta};{rutasTxt.RutaCierreDeCaja};{rutasTxt.RutaProductosVendidos}");
            escritor.Close();
            file.Close();
        }
        public List<RutasTxt> Consultar()
        {
            List<RutasTxt> rutasTxts = new List<RutasTxt>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                RutasTxt rutasTxt = new RutasTxt()
                {
                    RutaFacturasVenta = dato[0],
                    RutaCierreDeCaja = dato[1],
                    RutaProductosVendidos=dato[2],
                };
                rutasTxts.Add(rutasTxt);
            }
            lector.Close();
            file.Close();
            return rutasTxts;
        }
        public bool FiltroIdentificaiconFacturaCierreDeCajas(string referencia)
        {
            List<RutasTxt> rutasTxts = new List<RutasTxt>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                if (dato[1].Equals(referencia))
                {
                    lector.Close();
                    file.Close();
                    return true;
                }
            }
            lector.Close();
            file.Close();
            return false;
        }
        public bool FiltroIdentificaiconFacturaDeVentas(string referencia)
        {
            List<RutasTxt> rutasTxts = new List<RutasTxt>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                if (dato[1].Equals(referencia))
                {
                    lector.Close();
                    file.Close();
                    return true;
                }
            }
            lector.Close();
            file.Close();
            return false;
        }
        private bool EsEncontrado(string referenciaRegistrada, string referenciaBuscada)
        {
            return referenciaRegistrada == referenciaBuscada;
        }
        public void ModificarFacturaCierreDeCajas(RutasTxt rutasTxt, string referencia)
        {
            List<RutasTxt> rutasTxts = new List<RutasTxt>();
            rutasTxts = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in rutasTxts)
            {
                if (!EsEncontrado(item.RutaCierreDeCaja, referencia))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(rutasTxt);
                }
            }
        }
        public void ModificarRutasTxt(RutasTxt rutasTxt, string referencia)
        {
            List<RutasTxt> rutasTxts = new List<RutasTxt>();
            rutasTxts = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in rutasTxts)
            {
                if (!EsEncontrado(item.Referencia.ToString(), referencia))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(rutasTxt);
                }
            }
        }
        public void ModificarFacturaDeVentas(RutasTxt rutasTxt, string referencia)
        {
            List<RutasTxt> rutasTxts = new List<RutasTxt>();
            rutasTxts = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in rutasTxts)
            {
                if (!EsEncontrado(item.RutaFacturasVenta, referencia))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(rutasTxt);
                }
            }
        }
        public void EliminarTodo()
        {
            File.Delete(ruta);
        }
        public void EliminarFacturaCierreDeCajas(string referencia)
        {
            List<RutasTxt> rutasTxts = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in rutasTxts)
            {
                if (!item.RutaCierreDeCaja.Equals(referencia))
                {
                    Guardar(item);
                }
            }
        }
        public void EliminarFacturaDeVentas(string referencia)
        {
            List<RutasTxt> rutasTxts = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in rutasTxts)
            {
                if (!item.RutaFacturasVenta.Equals(referencia))
                {
                    Guardar(item);
                }
            }
        }
        public int Totalizar()
        {
            return Consultar().Count();
        }
    }
}
