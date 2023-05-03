using PersonalTrainingPlan.Models;
using PersonalTrainingPlan.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalTrainingPlan
{

    public partial class MainWindow : Window
    {
        private PersonalPlanContext _context;


        public MainWindow()
        {
            InitializeComponent();
            _context = new PersonalPlanContext();
            ShowSelectedPlan();
        }

        private void ShowSelectedPlan()
        {
            var selectedPlan = _context.SelectedPlans.FirstOrDefault(sp => sp.id == 1);
            if (selectedPlan == null)
            {
                return;
            }

            var plan = _context.Plans.FirstOrDefault(p => p.id == selectedPlan.PlanId);
            if (plan == null)
            {
                return;
            }

            var trainings = _context.Trainings.Where(t => t.PlanId == plan.id).ToList();

            PlanNameTextBlock.Text = plan.Name;
            PlanDescriptionTextBlock.Text = "Рівень: " + plan.Complexity;
            PlanDaysTextBlock.Text = "Термін виконання: " + plan.TrainingDays;

            TrainingsListBox.ItemsSource = trainings;
        }

        private void ViewTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTraining = (sender as Button).DataContext as Training;

            if (selectedTraining == null) return;

            var trainingView = new TrainingView(selectedTraining);
            trainingView.Show();
            Hide();
        }



        private void Button_SelectedPlan_Click(object sender, RoutedEventArgs e)
        {
            PlanSelectionView planSelectionView = new PlanSelectionView();
            planSelectionView.Show();
            Hide();
        }

        private void PlanSelectionView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
