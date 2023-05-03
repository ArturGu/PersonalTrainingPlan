using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTrainingPlan.Models
{
    public class Training
    {
        public int id { get; set; }
        public string TrainingNumber { get; set; }
        public string Name { get; set; }
        public string ExecutionTime { get; set; }
        public int PlanId { get; set; }


        public virtual Plan Plan { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

    }
}
