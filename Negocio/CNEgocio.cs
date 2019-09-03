using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;
using Datos.Lectura;
using Datos.Escritura;

namespace Negocio
{
    public class CNegocio
    {
        private static CNegocio oInstance;
        private static Mutex oMutex = new Mutex();
        private CNegocio()
        {

        }
        public static CNegocio Instancia
        {
            get
            {
                oMutex.WaitOne();
                if (oInstance == null)
                {
                    oInstance = new CNegocio();
                }
                oMutex.ReleaseMutex();
                return oInstance;
            }
        }
        #region Comandos
        public List<Comandos> comandos_ListarAll()
        {
            return ComandoDAS.LlenarListaComandos();
        }
        public string[] CargarFrases()
        {
            return ComandoDAS.CargarFrases();
        }
        public Comandos InsertarComando(Comandos cm)
        {
            return ComandosDAO.InsertarComando(cm);
        }
        public Comandos UpdateComando(Comandos comandos)
        {
            return ComandosDAO.UpdateComando(comandos);
        }
        public int DeleteComando(int id)
        {
            return ComandosDAO.DeleteComando(id);
        }

        #endregion

        #region Respuestas
        public List<Respuestas> respuestas_ListarAll()
        {
            return RespuestasDAS.LlenarListaRespuestas();
        }
        public string[] CargarFrasesRespuestas()
        {
            return RespuestasDAS.CargarFrasesRespuestas();
        }
        public Respuestas InsertarRespuestas(Respuestas resp)
        {
            return RespuestasDAO.InsertarRespuesta(resp);
        }
        public Respuestas UpdateRespuestas(Respuestas resp)
        {
            return RespuestasDAO.UpdateRespuestas(resp);
        }
        #endregion
    }
}
