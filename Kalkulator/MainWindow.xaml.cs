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

        public Double result = 0;         /**< zmienna do której jest zapisywany resultat obliczeń */
        public string operation = "";     /**< zmienna która chroni informacje o bieżącej operacji */
        public bool enter_value = false;  /**< zmienna która określa stan operacji: stan 'true' jeżeli zakończona lub stan 'false' jeżeli jest w trakcie działania obliczeń */

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funkcja pozwala na nacisnanie przycisku w kalkulatorze (wprowadzenie cyfr oraz znaku ".")
        /// </summary>
        /// <param name="sender">Parametr , który odwoluje się do obiektu.</param>
        /// <param name="e">Parametr zawierający informację o wydarzeniu(wyświetlienie informacji).</param>
        public void Number_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Funkcja która oczyszcza całą zawartość elementu TextBlock od zamieszczonej w nim informacji.
        /// </summary>
        /// <param name="sender">Parametr , który odwoluje się do obiektu.</param>
        /// <param name="e">Parametr zawierający informację o wydarzeniu(wyświetlienie informacji).</param>
        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "0";
        }
        /// <summary>
        /// Funkcja która usuwa ostatni element z ciągu znaków zawartych w elemencie TextBlock.
        /// </summary>
        /// <param name="sender">Parametr , który odwoluje się do obiektu.</param>
        /// <param name="e">Parametr zawierający informację o wydarzeniu(wyświetlienie informacji).</param>
        public void Single_Clear_Click(object sender, RoutedEventArgs e)
        {
            if(textBlock.Text.Length > 0)
                textBlock.Text = textBlock.Text.Remove(textBlock.Text.Length - 1, 1);
            if(textBlock.Text == "")
                textBlock.Text = "0";
        }
        /// <summary>
        /// Funkcja która wylicza podstawowe funkcje matematyczne jednego argumentu lub określa funkcje matematyczne dwóch argumentów (pracuje w kombinacji z Eaquals_Click()) w zależności od operacji.
        /// </summary>
        /// <param name="sender">Parametr , który odwoluje się do obiektu.</param>
        /// <param name="e">Parametr zawierający informację o wydarzeniu(wyświetlienie informacji).</param>
        public void Basic_Arithmetic_Click(object sender, RoutedEventArgs e)
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
        /// <summary>
        /// Funkcja która wylicza podstawowe funkcje matematyczne dwóch argumentów.
        /// </summary>
        /// <param name="sender">Parametr , który odwoluje się do obiektu.</param>
        /// <param name="e">Parametr zawierający informację o wydarzeniu(wyświetlienie informacji).</param>
        public void Eaquals_Click(object sender, RoutedEventArgs e)
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
