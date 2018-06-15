using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class Negocio
    {
        private static Negocio oInstance;
        private static Mutex oMutex = new Mutex();
        private Negocio()
        {

        }
        public static Negocio Instancia
        {
            get
            {
                oMutex.WaitOne();
                if (oInstance == null)
                {
                    oInstance = new Negocio();
                }
                oMutex.ReleaseMutex();
                return oInstance;
            }
        }
        #region Comandos
        //public List<Comandos> comandos_ListarAll()
        //{
        //    return ClaseDAS.getAll();
        //}
        #endregion
    }
}
