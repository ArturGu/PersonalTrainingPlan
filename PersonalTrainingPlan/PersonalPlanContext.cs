using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalTrainingPlan.Models;

namespace PersonalTrainingPlan
{
    public class PersonalPlanContext : DbContext
    {

        public PersonalPlanContext() : base("DbConnectionString") 
        {       
        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<SelectedPlan> SelectedPlans { get; set; }
    }
}
