using MyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using P_Layer.Views;
using System.Windows;
using L_Layer;
using DTOs;

namespace P_Layer.ViewModels
{
    public class MainWindowViewModel
    {
        Window thisMainWindow;  //En referance til eget view
        LoginView loginWindow;  //En ref hvis der skal åbnes andre views

        LogicStump logicStump;


        public MainWindowViewModel(Window mainWindowRef)
        {
            thisMainWindow = mainWindowRef;
            logicStump = new LogicStump();
            if (OpenLoginViewCanExecute())  //Validering på om der er lavet et vindue tidligere
            {
                OpenLoginView();            //Åbner et nyt login vindue
            }
        }

        #region Open login window

        ICommand openloginWindowCommand;
        public ICommand OpenLoginWindowCommand
        {
            get { return openloginWindowCommand ?? (openloginWindowCommand = new RelayCommand(OpenLoginView, OpenLoginViewCanExecute)); }
        }

        private void OpenLoginView()
        {
            loginWindow = new LoginView(thisMainWindow,logicStump);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            loginWindow.ShowDialog();
            if (!String.IsNullOrWhiteSpace(logicStump.LoginSucceeded))
            {
            thisMainWindow.Show();
            }
            else
            {
            thisMainWindow.Close();
            }
        }

        private bool OpenLoginViewCanExecute()
        {
            if (loginWindow == null)
            {
                return true;
            }
            return false;
        }

        #endregion
        #region Logout and close login window

        ICommand closeloginWindowCommand;
        public ICommand CloseLoginWindowCommand
        {
            get { return closeloginWindowCommand ?? (closeloginWindowCommand = new RelayCommand(CloseLoginView, CloseLoginViewCanExecute)); }
        }

        private void CloseLoginView()
        {
            loginWindow = null;   
        }

        private bool CloseLoginViewCanExecute()
        {
            if (loginWindow != null)
            {
                return true;
            }
            return false;
        }

        #endregion


    }
}
