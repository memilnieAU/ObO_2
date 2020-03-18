using MyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using P_Layer.Views;

namespace P_Layer.ViewModels
{
    public class MainWindowViewModel
    {
        LoginView loginWindow;




        #region Commands

        ICommand _calcBMICommand;
        public ICommand CalcBMICommand
        {
            get { return _calcBMICommand ?? (_calcBMICommand = new RelayCommand(CalcBMI, CalcBMICanExecute)); }
        }

        private void CalcBMI()
        {
            loginWindow = new LoginView();
            
            loginWindow.ShowDialog();
        }

        private bool CalcBMICanExecute()
        {
            return true;
        }

        #endregion
    }
}
