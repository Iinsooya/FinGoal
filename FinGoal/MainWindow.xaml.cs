using FinGoal.Models;
using FinGoal.Services;
using FinGoal.Views;
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
using Microsoft.VisualBasic;

namespace FinGoal
{
    public partial class MainWindow : Window
    {
        private List<FinancialGoal> goals = new List<FinancialGoal>();
        private List<FinancialGoal> filteredGoals = new List<FinancialGoal>();

        public MainWindow()
        {
            InitializeComponent();
            goals = DataService.LoadGoals();
            ApplySortAndFilter();
        }

        private void AddGoal_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new GoalDialog();
            if (dialog.ShowDialog() == true)
            {
                goals.Add(dialog.Goal);
                ApplySortAndFilter();
                DataService.SaveGoals(goals);
            }
        }

        private void UpdateGoal_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var goal = btn?.DataContext as FinancialGoal;
            if (goal == null) return;

            var dialog = new UpdateAmountDialog(goal.CurrentAmount);
            if (dialog.ShowDialog() == true)
            {
                goal.CurrentAmount = dialog.NewAmount;
                ApplySortAndFilter();
                DataService.SaveGoals(goals);
            }
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySortAndFilter();
        }

        private void FilterChanged(object sender, RoutedEventArgs e)
        {
            ApplySortAndFilter();
        }

        private void ApplySortAndFilter()
        {
            IEnumerable<FinancialGoal> query = goals;

            // Фильтрация: цели с дедлайном в течение 7 дней
            if (DeadlineFilterCheckBox.IsChecked == true)
            {
                var now = DateTime.Now;
                query = query.Where(g => (g.Deadline - now).TotalDays <= 7);
            }

            // Сортировка
            if (SortComboBox.SelectedIndex == 0)
                query = query.OrderByDescending(g => g.Progress); // по прогрессу
            else if (SortComboBox.SelectedIndex == 1)
                query = query.OrderBy(g => g.Deadline); // по дате

            filteredGoals = query.ToList();
            GoalsPanel.ItemsSource = null;
            GoalsPanel.ItemsSource = filteredGoals;
        }
    }
}