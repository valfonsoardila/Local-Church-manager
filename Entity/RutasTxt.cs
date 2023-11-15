using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RutasTxt
    {
        public RutasTxt(int referencia, string rutaInformeIndividual, string rutaInformeGeneral, string rutaMiembros, string rutaBautizados)
        {
            Referencia = referencia;
            RutaInformeIndividual = rutaInformeIndividual;
            RutaInformeGeneral = rutaInformeGeneral;
            RutaMiembros = rutaMiembros;
            RutaBautizados = rutaBautizados;
        }
        //Constructor Sobrecargado
        public RutasTxt()
        {

        }
        /*Atributos de la clase*/
        public int Referencia { get; set; }
        public string RutaInformeIndividual { get; set; }
        public string RutaInformeGeneral { get; set; }
        public string RutaMiembros { get; set; }
        public string RutaBautizados { get; set; }
    }
}
