using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTrainingPlan.Models
{
    public class Exercise
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ApproachRepeat { get; set; }
        public string Description { get; set; }
        public int TrainingId { get; set; }

        public virtual Training Training { get; set; }

    }
}
