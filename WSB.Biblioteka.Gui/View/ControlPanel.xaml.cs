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
    /// Logika interakcji dla klasy ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Zamykanie aplikacji
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainAccount mainAccount = new MainAccount();
                this.Close();
                mainAccount.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd:{ex.Message}");
            }
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                borrowinghistory borrowingHistory = new borrowinghistory();
                this.Close();
                borrowingHistory.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");

            }
        }
        private void btnSearchBooks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainpanel mainPanel = new mainpanel();
                this.Close();
                mainPanel.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd:{ex.Message}");
            }
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wylogowano pomyślnie.");
            LoginView loginView = new LoginView();
            this.Close();
            loginView.Show();
        }
    }
}
