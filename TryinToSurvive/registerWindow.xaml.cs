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

namespace TryinToSurvive
{
    public partial class registerWindow : Window
    {
        public registerWindow()
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
                bool userfound = context.Users.Any(user => user.Name == Username);
                if (userfound)
                {
                    MessageBox.Show($"User: {Username} already exists");
                }
                else
                {
                    var newUser = new User { Name = Username,Password = Ready_Password};
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    MainWindow nextWindow = new MainWindow();
                    nextWindow.Show();
                    Close();
                }


            }
            // Your button click logic goes here
        }
        private void Hyper_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nextWindow = new MainWindow();
            nextWindow.Show();
            Close();

        }
    }
}
