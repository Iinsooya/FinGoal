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

namespace FinGoal
{
    public partial class UpdateAmountDialog : Window
    {
        public decimal NewAmount { get; private set; }

        public UpdateAmountDialog(decimal currentAmount)
        {
            InitializeComponent();
            AmountBox.Text = currentAmount.ToString();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountBox.Text, out var result))
            {
                NewAmount = result;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
        }
    }
}
