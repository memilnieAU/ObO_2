using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Opg2_v1.Interface;
using Opg2_v1.View;
using Prism.Commands;

namespace Opg2_v1.ViewModel
{
    class BS_Win_ViewModel
    {

        public BS_Win_ViewModel()
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
