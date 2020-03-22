using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DTOs;
using L_Layer;
using MyCommands;
using P_Layer.Views;

namespace P_Layer.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Variabler
        Window ThisWindow;
        MainWindowViewModel MainWindow;
        LogicStump logicStump;
        public bool LoginOk { get; set; }


        public String Username { get; set; }

        private String password;

        public String Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }



        #endregion
        #region Ctor
        public LoginViewModel(MainWindowViewModel MainWinRef, LogicStump logicStumpRef)
        {
            Username = "999999-0000";
            Password = "testpw";
            
            ThisWindow = new LoginView(this);
            ThisWindow.Show();
            logicStump = logicStumpRef;
            MainWindow = MainWinRef;
            ThisWindow.Top = MainWindow.thisMainWindow.Top;
            ThisWindow.Left = MainWindow.thisMainWindow.Left;

        }

        #endregion
        #region Metoder



        #endregion


        #region Logout and close login window

        ICommand loginCommand;
        public ICommand LoginCommand
        {
            get { return loginCommand ?? (loginCommand = new RelayCommand(LoginHandler, LoginHandlerCanExecute)); }
        }
        private String errorType;

        public String ErrorType
        {
            get { return errorType; }
            set { errorType = value; Notify(); }
        }



        public void LoginHandler()
        {
            int LoginProces = logicStump.CheckLogin(Username, Password);
            switch (LoginProces)
            {
                case 1:
                    logicStump.LoginSucceeded = Username;
                    MainWindow.OpenOrClose();
                    ThisWindow.Close();

                    break;
                case 2:
                    ErrorType = "* CPR Findes ikke";
                    break;
                case 3:
                    ErrorType = "* Koden forkert";
                    break;

                default:
                    break;

            }
        }

        public bool LoginHandlerCanExecute()
        {
            if (Username[6] == '-' && Username.Length == 11)
            {
                return true;

            }
            else if (!Username.Contains("-") && Username.Length == 10)
            {
                return true;

            }
            return false;

        }

        #endregion
        #region close Application window

        ICommand closeCommand;
        public ICommand CloseCommand
        {
            get { return closeCommand ?? (closeCommand = new RelayCommand(CloseHandlerExecute, CloseHandlerCanExecute)); }
        }





        public void CloseHandlerExecute()
        {
            MessageBoxResult result = MessageBox.Show("Vil du lukke programmet?", "Bekræft lukning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                
                logicStump.LoginSucceeded = "";
                MainWindow.OpenOrClose();
                ThisWindow.Close();
                
                
            }
        }

        public bool CloseHandlerCanExecute()
        {
            return true;
        }

        #endregion

        // INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
