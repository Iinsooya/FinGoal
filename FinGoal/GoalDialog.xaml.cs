using FinGoal.Models;
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

namespace FinGoal.Views
{
    public partial class GoalDialog : Window
    {
        public FinancialGoal Goal { get; private set; }

        public GoalDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(TargetBox.Text, out var target) &&
                decimal.TryParse(CurrentBox.Text, out var current))
            {
                Goal = new FinancialGoal
                {
                    Title = TitleBox.Text,
                    TargetAmount = target,
                    CurrentAmount = current,
                    Deadline = DeadlinePicker.SelectedDate ?? DateTime.Now
                };
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные.");
            }
        }
    }
}
