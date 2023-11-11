using _420BytesProyect.DT.Ambiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General.Interfaces
{
    public interface IBMAmbientes
    {
        Task<bool> RegistrarTemperaturaAmbiente(RegistroTemperaturaAmbiente RegistroTemperaturaAmbiente);
    }
}
