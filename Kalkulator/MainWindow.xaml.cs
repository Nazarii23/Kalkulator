using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        Double result = 0; 
        string operation = "";
        bool enter_value = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funkcja pozwala na nacisnanie przycisku w kalkulatorze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if ((textBlock.Text == "0") || (enter_value))
                textBlock.Text = "";
            enter_value = false;
            

            Button num = (Button)sender;
            if ((string)num.Content == ".")
            {
                if (!textBlock.Text.Contains("."))
                    textBlock.Text = textBlock.Text + (string)num.Content;
            }
            else
                textBlock.Text = textBlock.Text + (string)num.Content;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "0";
        }

        private void Single_Clear_Click(object sender, RoutedEventArgs e)
        {
            if(textBlock.Text.Length > 0)
                textBlock.Text = textBlock.Text.Remove(textBlock.Text.Length - 1, 1);
            if(textBlock.Text == "")
                textBlock.Text = "0";
        }

        private void Basic_Arithmetic_Click(object sender, RoutedEventArgs e)
        {
            Button num = (Button)sender;
            operation = (string)num.Content;
            result = Double.Parse(textBlock.Text, CultureInfo.InvariantCulture);
            
            textBlock.Text = "";
            if(operation == "sin" || operation == "cos" || operation == "√" || operation == "x²" || operation == "1/x")
            {
                switch (operation)
                {
                    case "sin":
                        textBlock.Text = Math.Sin(result).ToString();
                        enter_value = true;
                        break;
                    case "cos":
                        textBlock.Text = Math.Cos(result).ToString();
                        enter_value = true;
                        break;
                    case "√":
                        textBlock.Text = Math.Sqrt(result).ToString();
                        enter_value = true;
                        break;
                    case "x²":
                        textBlock.Text = (result * result).ToString();
                        enter_value = true;
                        break;
                    case "1/x":
                        textBlock.Text = (1 / result).ToString();
                        enter_value = true;
                        break;
                }
            }
            else
                label.Content = System.Convert.ToString(result) + " " + operation;
        }

        private void Eaquals_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "";

            switch (operation)
            {
                case "+":
                    textBlock.Text = (result + Double.Parse(textBlock.Text)).ToString();
                    enter_value = true;
                    break;
                case "*":
                    textBlock.Text = (result * Double.Parse(textBlock.Text)).ToString();
                    enter_value = true;
                    break;
                case "-":
                    textBlock.Text = (result - Double.Parse(textBlock.Text)).ToString();
                    enter_value = true;
                    break;
                case "/":
                    textBlock.Text = (result / Double.Parse(textBlock.Text)).ToString();
                    enter_value = true;
                    break;
                case "%":
                    textBlock.Text = (result % Double.Parse(textBlock.Text)).ToString();
                    enter_value = true;
                    break;
            }
        }
    }
}
