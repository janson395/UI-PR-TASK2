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

namespace UI_PR_TASK2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _hashCode;
        private bool _cancelChanges;
        private User user = null;
        private bool auth = false;

        public MainWindow()
        {
            InitializeComponent();
            gridProfile.Visibility = Visibility.Hidden;
            _cancelChanges = false;
            user = new User("Dkit", "dkit@test.ru", "DkitGit");
            user.LastName = "Dkit";
            _hashCode = user.GetHashCode();
            DataContext = user;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(DataContext.GetHashCode() != _hashCode && !_cancelChanges)
            {
                MDSnackbarUnsavedChanges.IsActive = true;
                e.Cancel = true;
            }

            //Application.Current.Shutdown();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(TxbName.Text != "" && TxbEmail.Text != "" && TxbGithub.Text != "")
            {
                user.Name = TxbName.Text;
                user.Email = TxbEmail.Text;
                user.Github = TxbGithub.Text;
                user.LastName = "Dkit";

                DataContext = user;

                if (DataContext.GetHashCode() != _hashCode)
                {
                    SnackbarMsg("Данные обновлены", "ОК");
                    _hashCode = user.GetHashCode();


                    auth = true;

                    
                }
            } 
            else
            {
                SnackbarMsg("Не все поля заполнены", "ОК");
            }
        }

        private void SnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            MDSnackbarUnsavedChanges.IsActive = false;
            _cancelChanges = true;
            //Close();
        }

        private void SnackbarMsg(String msg, String actionContent)
        {
            MDSnackbarUnsavedChanges.IsActive = true;
            MDSnackbarMessage.Content = msg;
            MDSnackbarMessage.ActionContent = actionContent;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            tbUserName.Text = user.Name + " " + user.LastName;
            tbFristName.Text = user.Name;
            tbLastName.Text = user.LastName;

            gridMain.Visibility = Visibility.Hidden;
            gridProfile.Visibility = Visibility.Visible;
        }
    }
}
