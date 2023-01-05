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

namespace NumberSystems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int InSystem;
        private int OutSystem;
        private string Number;



        private void InButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int system = 0;
            foreach (UIElement item in In.Children)
                if (item is Button)
                {
                    ((Button)item).Background = Brushes.LightGray; //Все кнопки StackPanel "In" становятся серыми
                    if (item == btn)
                        InSystem = system + 2;
                    system++;
                }
            btn.Background = Brushes.LightGreen;      //Выбранная кнопка - выделяется цветом
        }

        private void OutButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int system = 0;
            foreach (UIElement item in Out.Children)
                if (item is Button)
                {
                    ((Button)item).Background = Brushes.LightGray; //Все кнопки StackPanel "In" становятся серыми
                    if (item == btn)
                        OutSystem = system + 2;
                    system++;
                }
            btn.Background = Brushes.LightGreen;      //Выбранная кнопка - выделяется цветом
        }


        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            Number = InField.Text;

            if (InSystem != 10)  //Перевод входящего числа в десятичную систему
            {
                string[] arr = new string[Number.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Number[i].ToString();
                    if (arr[i] == "A")
                        arr[i] = "10";
                    else
                    if (arr[i] == "B")
                        arr[i] = "11";
                    else if (arr[i] == "C")
                        arr[i] = "12";
                    else if (arr[i] == "D")
                        arr[i] = "13";
                    else if (arr[i] == "E")
                        arr[i] = "14";
                    else if (arr[i] == "F")
                        arr[i] = "15";    
                }

                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += int.Parse(arr[i]) * (int)(Math.Pow(InSystem, arr.Length - i - 1));
                }
                Number = sum.ToString();
            }

            //Перевод числа из десятичной систему в исходящую
            string OutNumber = "";
            do
            {
                OutNumber += int.Parse(Number) % OutSystem;
                Number = (int.Parse(Number) / OutSystem).ToString();
            } while (int.Parse(Number) > OutSystem);
            OutNumber += int.Parse(Number);
            char[] array = OutNumber.ToCharArray();
            Array.Reverse(array);
            OutNumber = new string(array);
            OutField.Text = OutNumber;
        }
    }
}
