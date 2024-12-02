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

namespace WSB.Biblioteka.Gui.View
{
    /// <summary>
    /// Logika interakcji dla klasy borrowinghistory.xaml
    /// </summary>
    public partial class borrowinghistory : Window
    {
        public borrowinghistory()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ChangedButton == MouseButton.Left)

                    DragMove();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ControlPanel controlPanel = new ControlPanel();
                this.Close();
                controlPanel.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd:{ex.Message}");
            }
        }
    }
}
