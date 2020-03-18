using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DTOs;
using L_Layer;
using MyCommands;

namespace P_Layer.ViewModels
{
    public class LoginViewModel
    {
        #region Variabler
        Window ThisWindow;
        LogicStump logicStump;
        public String Username { get; set; }
        public String Password { get; set; }
        #endregion
        #region Ctor
        public LoginViewModel(Window WindowRef,LogicStump logicStumpRef )
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

        private void Login()
        {
            if (logicStump.checkLogin(Username, Password))
            {

            ThisWindow.Close();
            }
        }

        private bool LoginCanExecute()
        {
            if (Username.Length ==10 || Username.Length ==11)
            {
                return true;

            }
            return false;
            
        }

        #endregion
    }
}
