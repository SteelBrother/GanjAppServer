
using _420BytesProyect.DT.Planta;
using _420BytesProyect.DT.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General.Interfaces
{
    public interface IBMPlantas
    {
        Task<List<Planta>> ConsultarListaDePlantas();
        Task<List<PlantaxUsuario>>ConsultarPlantasPorUsuario(int Cedula); 
    }
}
