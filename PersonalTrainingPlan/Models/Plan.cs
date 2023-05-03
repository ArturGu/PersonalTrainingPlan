using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTrainingPlan.Models
{
    public class Plan
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Complexity { get; set; }
        public string TrainingDays { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }


    }
}
