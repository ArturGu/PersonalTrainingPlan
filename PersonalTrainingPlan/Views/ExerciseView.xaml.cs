using PersonalTrainingPlan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalTrainingPlan.Views
{
    public partial class ExerciseView : Window
    {

        private readonly Exercise selectedExercise;

        public ExerciseView(Exercise exercise)
        {
            InitializeComponent();
            
            selectedExercise = exercise;
            
            Title = exercise.Name;

            ExerciseNameTextBlock.Text = exercise.Name;
            ApproachRepeatTextBlock.Text = "Підходів / Повторень: " + exercise.ApproachRepeat;
            DescriptionTextBlock.Text = exercise.Description;
        }
    }
}
