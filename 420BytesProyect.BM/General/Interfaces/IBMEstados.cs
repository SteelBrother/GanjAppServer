using _420BytesProyect.DT.Estado;
using _420BytesProyect.DT.Planta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General.Interfaces
{
    public interface IBMEstados
    {
        Task<string> ActualizarEstadoDeLaPlanta(Estado estado);
    }
}
