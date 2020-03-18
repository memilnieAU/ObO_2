using MyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using P_Layer.Views;
using System.Windows;

namespace P_Layer.ViewModels
{
    public class MainWindowViewModel
    {
        LoginView loginWindow;
        Window mainWindow;

        public MainWindowViewModel(Window mainWindowRef)
        {
            mainWindow = mainWindowRef;
        }

        #region Commands

        ICommand openloginWindowCommand;
        public ICommand OpenLoginWindowCommand
        {
            get { return openloginWindowCommand ?? (openloginWindowCommand = new RelayCommand(OpenLoginView, OpenLoginViewCanExecute)); }
        }

        private void OpenLoginView()
        {
            loginWindow = new LoginView();
            //Application.Current.MainWindow.Hide();
            mainWindow.Hide();
            loginWindow.ShowDialog();
            mainWindow.Show();
        }

        private bool OpenLoginViewCanExecute()
        {
            return true;
        }

        #endregion
    }
}
