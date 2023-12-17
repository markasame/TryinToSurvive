using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace TryinToSurvive
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Username = usernameInputBox.Text;
            var Password = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(passwordInputBox.SecurePassword);
            var Ready_Password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(Password);
            using (userDataContext context = new userDataContext())
            {
                bool userfound = context.Users.Any(user => user.Name == Username && user.Password == Ready_Password);
                if (userfound)
                {
                    GrantAccess();
                    Close();
                }
                else
                {
                    MessageBox.Show($"Password: {Ready_Password} User: {Username}");
                }


            }
            // Your button click logic goes here
        }
        private void Hyper_Click(object sender, RoutedEventArgs e)
        {
            registerWindow nextWindow = new registerWindow();
            nextWindow.Show();
            Close();

        }
        public void GrantAccess()
        {
            MainBody main = new MainBody();
            main.Show();
            Close();

        }
    }
}
