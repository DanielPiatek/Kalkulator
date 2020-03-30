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
using System.Data;

namespace kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float num1 = 0;
        float num2 = 0;
        string dzialanie = "";
        bool zabezpieczenie = false;
        bool przecinek = false;
        int wartoscPrzecinka = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string tag = ((Button)sender).Tag.ToString();
            float wartosc = float.Parse(tag);
            if (przecinek == false)
                num1 = (num1 * 10) + wartosc;
            if (przecinek == true)
            {
                num1 = num1 + wartosc / (10 * wartoscPrzecinka);
                wartoscPrzecinka *= 10;
            }

            textBoxCzarny.Text = num1.ToString();


        }

        private void ButtonDzialanie_Click(object sender, RoutedEventArgs e)
        {
            if(dzialanie == "")
            {
                dzialanie = ((Button)sender).Tag.ToString();
                textBoxSzary.Text = textBoxCzarny.Text + " " + dzialanie + " ";
                if(dzialanie == "+")
                    textBoxSzary.Tag = textBoxCzarny.Text + " " + "@" + " ";
                textBoxCzarny.Text = "0";

                num2 = num1;
                num1 = 0;
                zabezpieczenie = true;
                przecinek = false;
                wartoscPrzecinka = 1;
            }
        }


        private void ButtonRownanie_Click(object sender, RoutedEventArgs e)
        {
            string[] s = new string[] { " ", " ", " "};
            float rownanie = 0;

            if (zabezpieczenie == true)
            {
                //DataTable dt = new DataTable();
                //String v = dt.Compute(textBoxSzary.Text + textBoxCzarny.Text, null).ToString();
                //textBoxSzary.Text = textBoxSzary.Text + textBoxCzarny.Text;
                //textBoxCzarny.Text = v.ToString();
                string temp = textBoxSzary.Text + textBoxCzarny.Text;

                switch (dzialanie)
                {
                    case "+":
                        s = (textBoxSzary.Tag.ToString() + textBoxCzarny.Text).Split('@');
                        rownanie = float.Parse(s[0]) + float.Parse(s[1]);
                        textBoxSzary.Text = textBoxSzary.Text + textBoxCzarny.Text;
                        textBoxCzarny.Text = rownanie.ToString();

                        break;
                    case "-":
                        s = (textBoxSzary.Text + textBoxCzarny.Text).Split('-');
                        if (s[0] == "")
                            rownanie = -float.Parse(s[1]) - float.Parse(s[2]);
                        else
                            rownanie = float.Parse(s[0]) - float.Parse(s[1]);
                        textBoxSzary.Text = textBoxSzary.Text + textBoxCzarny.Text;
                        textBoxCzarny.Text = rownanie.ToString();
                        s[0] = "";
                        break;
                    case "/":
                        s = (textBoxSzary.Text + textBoxCzarny.Text).Split('/');
                        if(float.Parse(s[1]) != 0)
                            rownanie = float.Parse(s[0]) / float.Parse(s[1]);
                        textBoxSzary.Text = textBoxSzary.Text + textBoxCzarny.Text;
                        textBoxCzarny.Text = rownanie.ToString();
                        break;
                    case "*":
                        s = (textBoxSzary.Text + textBoxCzarny.Text).Split('*');
                        rownanie = float.Parse(s[0]) * float.Parse(s[1]);
                        textBoxSzary.Text = textBoxSzary.Text + textBoxCzarny.Text;
                        textBoxCzarny.Text = rownanie.ToString();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }


                num2 = float.Parse(textBoxCzarny.Text);
                num1 = 0;
            }
            zabezpieczenie = false;
            przecinek = false;
            wartoscPrzecinka = 1;
            dzialanie = "";


        }

        private void ButtonPrzecinek_Click(object sender, RoutedEventArgs e)
        {
            if (!textBoxCzarny.Text.Contains(","))
            {
                textBoxCzarny.Text = textBoxCzarny.Text + ",";
                przecinek = true;
            }


        }
    }
}
