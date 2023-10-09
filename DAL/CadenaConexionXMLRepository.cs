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
        private string ruta = @"";
        
        public void Guardar(CadenaConexionXML cadenaConexion)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{cadenaConexion.Cadena}");
            escritor.Close();
            file.Close();
        }
        public void Modificar(CadenaConexionXML cadenaConexion, string oldServer, string ui)
        {
            if (ui != "")
            {
                ruta = @"" + ui + ".exe.config";
            }
            else
            {
                ruta = @"UI.exe.config";
            }
            List<CadenaConexionXML> appconfig = new List<CadenaConexionXML>();
            appconfig = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            if (appconfig.Count > 0)
            {
                int i = 0;
                foreach (var item in appconfig)
                {
                    if (i == 8)
                    {
                        Guardar(cadenaConexion);
                    }
                    else
                    {
                        Guardar(item);
                    }
                    i = i + 1;
                }
            }
        }
        public List<CadenaConexionXML> Consultar()
        {
            if (ruta == "")
            {
                ruta = @"UI.exe.config";
            }
            List<CadenaConexionXML> appconfig = new List<CadenaConexionXML>();
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
                appconfig.Add(cadenaConexion);
            }
            lector.Close();
            file.Close();
            return appconfig;
        }
        private bool EsEncontrado(string cadenaConexionRegistrada, string newServerBuscada)
        {
            return cadenaConexionRegistrada == newServerBuscada;
        }
    }
}
