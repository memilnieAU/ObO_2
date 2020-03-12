using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Opg2_v1.View;
using Prism.Commands;

namespace Opg2_v1.ViewModel
{
    class BS_Win_ViewModel
    {
        HomePage_Win Home_Window;
        #region Commands
        private ICommand openCommand;
        public ICommand OpenCommand
        {
            get
            {
                return openCommand ?? (openCommand = new DelegateCommand(OpenCommandHandler));
            }
        }

        void OpenCommandHandler()
        {
            Home_Window = new HomePage_Win();
            Home_Window.ShowDialog();

        }


        #endregion
       
    }
}
