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
    public class LoginViewModel: INotifyPropertyChanged
    {
        #region Variabler
        Window ThisWindow;
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
        public LoginViewModel(Window WindowRef, Window MainWinRef,LogicStump logicStumpRef )
        {
            ThisWindow = WindowRef;
            logicStump = logicStumpRef;
            Username = "999999-0000";
            Password = "testpw";
        }

        #endregion
        #region Metoder

        

        #endregion


        #region Logout and close login window

        ICommand loginCommand;
        public ICommand LoginCommand
        {
            get { return loginCommand ?? (loginCommand = new RelayCommand(Login, LoginCanExecute)); }
        }
        private String errorType;

        public String ErrorType
        {
            get { return errorType; }
            set { errorType = value; Notify(); }
        }

      

        private void Login()
        {
            int LoginProces = logicStump.checkLogin(Username, Password);
            switch (LoginProces)
            {
                case 1:
                    logicStump.LoginSucceeded = Username;
                        ThisWindow.Close();

                    break;
                case 2:
                    ErrorType = "* Username forkert";
                    break;
                case 3:
                    ErrorType = "* Password forkert";
                    break;
                
                default:
                    break;
           
            }
        }

        private bool LoginCanExecute()
        {
            if (Username[6]=='-' && Username.Length == 11)
            {
                return true;

            }
            else if (!Username.Contains("-") && Username.Length ==10)
            {
                return true;

            }
            return false;
            
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
