using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
namespace DAL
{
    public class ArchivoRespaldoRepository
    {
        private DateTime fechaActual = DateTime.Now;
        private string fecha { get; set; }
        private string ruta { get; set; }

        public void Guardar(ArchivoRespaldo archivoRespaldo)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{archivoRespaldo.NombreDeArchivo}");
            escritor.Close();
            file.Close();
        }
        public List<ArchivoRespaldo> Consultar()
        {
            List<ArchivoRespaldo> archivoRespaldos = new List<ArchivoRespaldo>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                ArchivoRespaldo archivoRespaldo = new ArchivoRespaldo()
                {
                    NombreDeArchivo = dato[0],
                };
                archivoRespaldos.Add(archivoRespaldo);
            }
            lector.Close();
            file.Close();
            return archivoRespaldos;
        }
        public bool FiltroIdentificaicon(string referencia)
        {
            List<ArchivoRespaldo> archivoRespaldos = new List<ArchivoRespaldo>();
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
        public void Modificar(ArchivoRespaldo archivoRespaldo, string referencia)
        {
            List<ArchivoRespaldo> archivoRespaldos = new List<ArchivoRespaldo>();
            archivoRespaldos = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in archivoRespaldos)
            {
                if (!EsEncontrado(item.NombreDeArchivo, referencia))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(archivoRespaldo);
                }
            }
        }
        public void EliminarTodo()
        {
            fecha = fechaActual.ToString("dd-MM-yyyy");
            ruta = @"BackupDB " + fecha + ".xlsx";
            File.Delete(ruta);
        }
        public void Eliminar(string referencia)
        {
            List<ArchivoRespaldo> archivoRespaldos = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in archivoRespaldos)
            {
                if (!item.NombreDeArchivo.Equals(referencia))
                {
                    Guardar(item);
                }
            }
        }
    }
}
