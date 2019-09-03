using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comandos
    {
        private int id;
        private string comando;
        private string accion;
        private string respuesta;
        private string respuestaPregunta;

        public Comandos()
        {

        }

        public Comandos(string comando, string accion, string respuesta, string respuestaPregunta)
        {
            this.comando = comando;
            this.accion = accion;
            this.respuesta = respuesta;
            this.respuestaPregunta = respuestaPregunta;
        }

        public Comandos(int id, string comando, string accion, string respuesta, string respuestaPregunta)
        {
            this.id = id;
            this.comando = comando;
            this.accion = accion;
            this.respuesta = respuesta;
            this.respuestaPregunta = respuestaPregunta;
        }

        public int Id { get => id; set => id = value; }
        public string Comando { get => comando; set => comando = value; }
        public string Accion { get => accion; set => accion = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
        public string RespuestaPregunta { get => respuestaPregunta; set => respuestaPregunta = value; }
    }


}
