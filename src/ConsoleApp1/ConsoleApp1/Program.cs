using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            database db = new database();

            LogRow logrow = new LogRow()
            {
                Date = DateTime.Now,
                Exercise = "Benchpress",
                Weight = 210,
                Repetitions = 10,
                Sets = 5,
                Rest_time = 90,
                Notes = "BEASTMODE"     
            };

            //db.AddExercise(logrow);

            foreach (LogRow _logrow in db.Exercises)
            {
                Console.WriteLine(_logrow.Id + ", " + _logrow.Date.ToString("dd-MM-yy") + ", " + _logrow.Exercise + ", " + _logrow.Weight + ", " + _logrow.Repetitions + ", " + _logrow.Sets + ", " + _logrow.Rest_time + ", " + _logrow.Notes);
            }

            Console.ReadLine();


        }
    }
}
