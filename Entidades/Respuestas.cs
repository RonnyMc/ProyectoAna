using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Respuestas
    {
        private int idRespuestas;
        private int idComandos;
        private string respuesta;

        public Respuestas()
        {

        }

        public Respuestas(int idComandos, string respuesa)
        {
            this.idComandos = idComandos;
            this.respuesta = respuesa;
        }

        public Respuestas(int idRespuestas, int idComandos, string respuesa)
        {
            this.idRespuestas = idRespuestas;
            this.idComandos = idComandos;
            this.respuesta = respuesa;
        }

        public int IdRespuestas { get => idRespuestas; set => idRespuestas = value; }
        public int IdComandos { get => idComandos; set => idComandos = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
    }
}
