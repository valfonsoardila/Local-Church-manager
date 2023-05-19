using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entity;
using System.IO;
using System.Xml;

namespace DAL
{
    public class CadenaConexionXMLRepository
    {
        private string ruta = @"AdminPharm.exe.config";
        
        public void Guardar(CadenaConexionXML cadenaConexion)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{cadenaConexion.Cadena}");
            escritor.Close();
            file.Close();
        }
        public void Modificar(CadenaConexionXML cadenaConexion, string oldServer)
        {
            List<CadenaConexionXML> cadenaConexions = new List<CadenaConexionXML>();
            cadenaConexions = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in cadenaConexions)
            {
                if (!EsEncontrado(item.Cadena, oldServer))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(cadenaConexion);
                }
            }
        }
        public List<CadenaConexionXML> Consultar()
        {
            List<CadenaConexionXML> cadenaConexions = new List<CadenaConexionXML>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split('>');
                CadenaConexionXML cadenaConexion = new CadenaConexionXML()
                {
                    Cadena = dato[0] + ">",
                };
                cadenaConexions.Add(cadenaConexion);
            }
            lector.Close();
            file.Close();
            return cadenaConexions;
        }
        private bool EsEncontrado(string cadenaConexionRegistrada, string newServerBuscada)
        {
            return cadenaConexionRegistrada == newServerBuscada;
        }
    }
}
