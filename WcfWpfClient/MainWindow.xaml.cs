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
using WcfWpfClient.ServiceReference1;

namespace WcfWpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorClient client = null;

        public MainWindow()
        {
            InitializeComponent();
            client = new CalculatorClient();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double op1Double = Double.Parse(op1.Text);
            double op2Double = Double.Parse(op2.Text);

            string selectedOp = (string)((ListBoxItem)(operatorComboBox.SelectedValue)).Content;
            double result = 0;
            switch(selectedOp)
            {
                case "+":
                    result = client.Add(op1Double, op2Double);
                    break;
                case "-":
                    result = client.Subtract(op1Double, op2Double);
                    break;
                case "*":
                    result = client.Multiply(op1Double, op2Double);
                    break;
                case "/":
                    result = client.Divide(op1Double, op2Double);
                    break;
            }

            MessageBox.Show(op1Double + " " + selectedOp + " " + op2Double + " = " + result);
        }
    }
}
