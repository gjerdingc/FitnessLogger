using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LogRow
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Exercise { get; set; }
        public int Weight { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public int Rest_time { get; set; }
        public string Notes { get; set; }

    }
}
