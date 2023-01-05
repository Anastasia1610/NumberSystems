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
                    if(item == btn)
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
        }
    }
}
