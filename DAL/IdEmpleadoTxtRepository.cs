using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class IdEmpleadoTxtRepository
    {
        private string ruta = @"IdEmpleadoSesion.config";
        public void Guardar(IdUsuarioTxt idEmpleadoTxt)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{idEmpleadoTxt.Identificacion}");
            escritor.Close();
            file.Close();
        }
        public List<IdUsuarioTxt> Consultar()
        {
            List<IdUsuarioTxt> idEmpleadoTxts = new List<IdUsuarioTxt>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                IdUsuarioTxt idEmpleadoTxt = new IdUsuarioTxt()
                {
                    Identificacion = dato[0],
                };
                idEmpleadoTxts.Add(idEmpleadoTxt);
            }
            lector.Close();
            file.Close();
            return idEmpleadoTxts;
        }
        public bool FiltroIdentificaicon(string referencia)
        {
            List<IdUsuarioTxt> idEmpleadoTxts = new List<IdUsuarioTxt>();
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
        public void Modificar(IdUsuarioTxt idEmpleadoTxt, string referencia)
        {
            List<IdUsuarioTxt> idEmpleadoTxts = new List<IdUsuarioTxt>();
            idEmpleadoTxts = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in idEmpleadoTxts)
            {
                if (!EsEncontrado(item.Identificacion, referencia))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(idEmpleadoTxt);
                }
            }
        }
        public void EliminarTodo()
        {
            File.Delete(ruta);
        }
        public void Eliminar(string referencia)
        {
            List<IdUsuarioTxt> idEmpleadoTxts = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in idEmpleadoTxts)
            {
                if (!item.Identificacion.Equals(referencia))
                {
                    Guardar(item);
                }
            }
        }
    }
}
