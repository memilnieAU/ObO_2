using GalaSoft.MvvmLight.Command;
using Opg2_v1.Interface;
using Prism.Commands;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg2_v1.ViewModel
{
    public class Login_win_ViewModel
    {

        public Login_win_ViewModel()
        {
            this.CloseWindowCommandHP = new RelayCommand<ICloseable>(this.CloseWindowHP);
        }
        #region Open HP Window Commands
        //Properties
        public RelayCommand<ICloseable> CloseWindowCommandHP { get; private set; }

        //Methods
        private void CloseWindowHP(ICloseable window)
        {
            OpenHPCommandHandler();
            if (window != null)
                window.Close();
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
            HP_Window = new HomePage_Win();
            HP_Window.Show();

        }
        #endregion
    }

}
