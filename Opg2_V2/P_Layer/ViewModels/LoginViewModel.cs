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

namespace P_Layer.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Variabler
        Window ThisWindow;
        Window MainWindow;
        Logic logic;
        public bool LoginOk { get; set; }
        public String Username { get; set; }

        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion
        #region Ctor
        public LoginViewModel(Window WindowRef, Window MainWinRef, Logic logicRef)
        {
            ThisWindow = WindowRef;
            logic = logicRef;
            //Username = "123456-7890";
            //Password = "1234";
            Username = "DDMMYY-XXXX";
            Password = "****";
            MainWindow = MainWinRef;
            WindowRef.Top = MainWindow.Top;
            WindowRef.Left = MainWindow.Left;
            //MainWindowViewModel.Instance.OpenBlodPWindowCommand
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
            bool LoginProces = logic.CheckLogin(Username, Password);

            if (LoginProces == true)
            {
                logic.LoginSucceeded = Username;
                ThisWindow.Close();
            }
            else
            {
                ErrorType = "CPR eller kode forkert";
            }

            //switch (LoginProces)
            //{
            //    case 1:
            //        logic.LoginSucceeded = Username;
            //        ThisWindow.Close();
            //        break;
            //    case 2:
            //        ErrorType = "* CPR Findes ikke";
            //        break;
            //    case 3:
            //        ErrorType = "* Koden forkert";
            //        break;
            //    default:
            //        break;
            //}
        }

        public bool LoginHandlerCanExecute()
        {
            if (Username.Length >= 10)
            {
                if (Username[6] == '-' && Username.Length == 11)
                {
                    return true;

                }
                else if (!Username.Contains("-") && Username.Length == 10)
                {
                    return true;
                }
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
                logic.LoginSucceeded = "";
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
