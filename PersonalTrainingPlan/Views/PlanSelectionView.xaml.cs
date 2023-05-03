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

    public partial class PlanSelectionView : Window
    {
        private PersonalPlanContext dbContext;

        public PlanSelectionView()
        {
            InitializeComponent();

            dbContext = new PersonalPlanContext();

            LoadListBox();
        }

        private void LoadListBox()
        {
            List<Plan> plans = dbContext.Plans.ToList();
            plansBox.ItemsSource = plans;

        }

        private void SelectPlanButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlan = plansBox.SelectedItem as Plan;
            if (selectedPlan != null)
            {
                var selectedPlanInDb = dbContext.SelectedPlans.FirstOrDefault(sp => sp.id == 1);

                if (selectedPlanInDb == null)
                {
                    dbContext.SelectedPlans.Add(new SelectedPlan { PlanId = selectedPlan.id });
                }
                else
                {
                    selectedPlanInDb.PlanId = selectedPlan.id;
                }

                dbContext.SaveChanges();
                
                MainWindow mainView = new MainWindow();
                mainView.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть план!");
            }
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
