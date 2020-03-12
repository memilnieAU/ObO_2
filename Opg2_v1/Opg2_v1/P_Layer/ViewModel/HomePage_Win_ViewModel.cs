using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Opg2_v1.View;
using Opg2_v1;
using Opg2_v1.Interface;
using GalaSoft.MvvmLight.Command;
using Logic_tier;

namespace Opg2_v1.ViewModel
{
    public class HomePage_Win_ViewModel
    {
        Logic logic_Lay;
        //Constructor
        public int WindowCount { get; set; }
        public HomePage_Win_ViewModel(Logic logicRef)
        {
            logic_Lay = logicRef;
            this.CloseWindowCommandBP = new RelayCommand<ICloseable>(this.CloseWindowBP);
            this.CloseWindowCommandBS = new RelayCommand<ICloseable>(this.CloseWindowBS);
            this.CloseWindowCommandWeigth = new RelayCommand<ICloseable>(this.CloseWindowWeigth);
            logic_Lay.WindowCounter++;
        WindowCount = logic_Lay.WindowCounter;

        }

        #region Open BP Window Commands
        //Properties
        public RelayCommand<ICloseable> CloseWindowCommandBP { get; private set; }

        //Methods
        private void CloseWindowBP(ICloseable window)
        {
            OpenBPCommandHandler();//Her åbner jeg det andet vindue
            if (window != null)
                window.Close();
        }

        BP_Win BP_Window;
        private ICommand openBPCommand;
        public ICommand OpenBPCommand
        {
            get
            {
                return openBPCommand ?? (openBPCommand = new DelegateCommand(OpenBPCommandHandler));
            }
        }

        void OpenBPCommandHandler()
        {
            BP_Window = new BP_Win(logic_Lay);
            BP_Window.Show();
            
        }
        #endregion

        #region Open BS Window Commands
        //Properties
        public RelayCommand<ICloseable> CloseWindowCommandBS { get; private set; }

        //Methods
        private void CloseWindowBS(ICloseable window)
        {
            OpenBSCommandHandler();
            if (window != null)
                window.Close();
        }

        BS_Win BS_Window;
        private ICommand openBSCommand;
        public ICommand OpenBSCommand
        {
            get
            {
                return openBSCommand ?? (openBSCommand = new DelegateCommand(OpenBSCommandHandler));
            }
        }

        void OpenBSCommandHandler()
        {
            BS_Window = new BS_Win(logic_Lay);
            BS_Window.Show();

        }
        #endregion

        #region Open Weigth Window Commands
        //Properties
        public RelayCommand<ICloseable> CloseWindowCommandWeigth { get; private set; }

        //Methods
        private void CloseWindowWeigth(ICloseable window)
        {
            OpenWeigthCommandHandler();
            if (window != null)
                window.Close();
        }

        Weigth_Win Weigth_Window;
        private ICommand openWeigthCommand;
        public ICommand OpenWeigthCommand
        {
            get
            {
                return openWeigthCommand ?? (openWeigthCommand = new DelegateCommand(OpenWeigthCommandHandler));
            }
        }

        void OpenWeigthCommandHandler()
        {
            Weigth_Window = new Weigth_Win(logic_Lay);
            Weigth_Window.Show();

        }
        #endregion


    }
}
