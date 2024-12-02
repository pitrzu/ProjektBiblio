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
    /// Logika interakcji dla klasy MainAccount.xaml
    /// </summary>
    public partial class MainAccount : Window
    {
        public MainAccount()
        {
            InitializeComponent();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wylogowano pomyślnie.");
            LoginView loginView = new LoginView();
            this.Close();
            loginView.Show();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ChangedButton == MouseButton.Left)

                    DragMove();
            }
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
