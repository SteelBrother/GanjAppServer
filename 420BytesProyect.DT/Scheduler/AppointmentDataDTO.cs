using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Scheduler
{
    public class AppointmentDataDTO
    {
        public int Id { get; set; }
        public int Doc { get; set; }
        public AppointmentData? AppointmentData { get; set; }
    }
}
