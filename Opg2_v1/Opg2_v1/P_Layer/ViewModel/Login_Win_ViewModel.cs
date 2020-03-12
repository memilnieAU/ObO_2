using GalaSoft.MvvmLight.Command;
using Opg2_v1.Interface;
using Prism.Commands;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_tier;

namespace Opg2_v1.ViewModel
{
    public class Login_win_ViewModel
    {
        public int WindowCount { get; set; }

        public Login_win_ViewModel()
        {
            this.CloseWindowCommandLogin = new RelayCommand<ICloseable>(this.CloseWindowLogin);
            logic_Lay = new Logic();
            logic_Lay.WindowCounter++;
        WindowCount = logic_Lay.WindowCounter;
        }
        #region Open HP Window Commands
        //Properties
        public RelayCommand<ICloseable> CloseWindowCommandLogin { get; private set; }

        //Methods
        private void CloseWindowLogin(ICloseable window)
        {
            if (logic_Lay.checkLogin(CPRnumber, PassWord))
            {
                if (HP_Window == null)
                {
                OpenHPCommandHandler();

                }
                if (window != null)
                    window.Close();
            }
        }

        HomePage_Win HP_Window;
        private ICommand openHPCommand;
        public ICommand OpenHPCommand
        {
            get
            {
                return openHPCommand ?? (openHPCommand = new DelegateCommand(OpenHPCommandHandler));
            }
        }

        void OpenHPCommandHandler()
        {
            HP_Window = new HomePage_Win(logic_Lay);
            HP_Window.Show();

        }
        #endregion
        #region Logic Test lag

        Logic logic_Lay;
       
        private String cprnumber = "999999-0000";

        public String CPRnumber
        {
            get { return cprnumber; }
            set { cprnumber = value; }
        }

        private String passWord = "testpw";

        public String PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }


        private ICommand loginClick;

        public ICommand LoginClick
        {
            get { return loginClick ?? (loginClick = new DelegateCommand(LoginClickCommandHandler)); }
           
        }

        void LoginClickCommandHandler()
        {
            
            if (logic_Lay.checkLogin(CPRnumber, PassWord))
            {
                OpenHPCommandHandler();
                
                
            }
        }

        #endregion
    }

}
