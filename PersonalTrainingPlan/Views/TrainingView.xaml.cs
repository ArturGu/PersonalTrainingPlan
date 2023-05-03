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

    public partial class TrainingView : Window
    {
        private readonly Training selectedTraining;

        public TrainingView(Training training)
        {
            InitializeComponent();

            selectedTraining = training;

            Title = training.TrainingNumber;

            TrainingNumberTextBlock.Text = training.TrainingNumber;
            TrainingNameTextBlock.Text = training.Name;
            ExecutionTimeTextBlock.Text = training.ExecutionTime;

            var exercises = GetExercisesForTraining(training.id);
            TrainingsListBox.ItemsSource = exercises;
        }

        
        private List<Exercise> GetExercisesForTraining(int trainingId)
        {
            using (var db = new PersonalPlanContext())
            {
                return db.Exercises.Where(e => e.TrainingId == trainingId).ToList();
            }
        }

        

        private void ViewExerciseButton_Click(object sender, RoutedEventArgs e)
        {

            var selectedExercise = (sender as Button).DataContext as Exercise;
          
            ExerciseView exerciseView = new ExerciseView(selectedExercise);
            exerciseView.Show();
   
        }

        private void Button_GetBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainView = new MainWindow();
            mainView.Show();
            Hide();
        }

        private void PlanSelectionView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
