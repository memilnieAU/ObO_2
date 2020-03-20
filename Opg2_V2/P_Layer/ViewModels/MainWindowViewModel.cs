using MyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using P_Layer.Views;
using System.Windows;
using L_Layer;
using DTOs;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace P_Layer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        Window thisMainWindow;  //En referance til eget view
        LoginView loginWindow;  //En ref hvis der skal åbnes andre views
        BlodSView blodSWindow;
        BlodPView blodPWindow;
        WeightView weigtWindow;
        LogicStump logicStump;


        public MainWindowViewModel(Window mainWindowRef)
        {
            thisMainWindow = mainWindowRef;
            logicStump = new LogicStump();
            if (OpenLoginViewCanExecute())  //Validering på om der er lavet et vindue tidligere
            {
                OpenLoginView();            //Åbner et nyt login vindue
            }
        }

        #region RadioButtens for sent data

        private bool oneWeekChecked;

        public bool OneWeekChecked
        {
            get { return oneWeekChecked; }
            set
            {
                oneWeekChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool twoWeekChecked;

        public bool TwoWeekChecked
        {
            get { return twoWeekChecked; }
            set
            {
                twoWeekChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool fourWeekChecked;

        public bool FourWeekChecked
        {
            get { return fourWeekChecked; }
            set
            {
                fourWeekChecked = value;
                NotifyPropertyChanged();
            }
        }

        private String dataIsSent = "Vælg periode";

        public String DataIsSent
        {
            get { return dataIsSent; }
            set
            {
                dataIsSent = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region DataSendCommand 

        ICommand sendDataCommand;
        public ICommand SendDataCommand
        {
            get { return sendDataCommand ?? (sendDataCommand = new RelayCommand(SendDataCommandHandler, SendDataCommandHandlerCanExecute)); }
        }

        private void SendDataCommandHandler()
        {
            if (OneWeekChecked)
            {
                OneWeekChecked = false;
            }
            else if (TwoWeekChecked)
            {
                TwoWeekChecked = false;
            }
            else if (FourWeekChecked)
            {
                FourWeekChecked = false;
            }
            
                DataIsSent = "Periode sent";
        }
       
        
        private bool SendDataCommandHandlerCanExecute()
        {
            

            if (!OneWeekChecked && !TwoWeekChecked && !FourWeekChecked)
            {
                return false;
            }
            DataIsSent = "Send";
            return true;

        }

        #endregion


        #region Open login window

        ICommand openloginWindowCommand;
        public ICommand OpenLoginWindowCommand
        {
            get { return openloginWindowCommand ?? (openloginWindowCommand = new RelayCommand(OpenLoginView, OpenLoginViewCanExecute)); }
        }

        private void OpenLoginView()
        {
            loginWindow = new LoginView(thisMainWindow, logicStump);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            loginWindow.ShowDialog();
            if (!String.IsNullOrWhiteSpace(logicStump.LoginSucceeded))
            {
                thisMainWindow.Show();
            }
            else
            {
                thisMainWindow.Close();
            }
        }

        private bool OpenLoginViewCanExecute()
        {
            if (loginWindow == null)
            {
                return true;
            }
            return false;
        }

        #endregion
        #region Open BlodS window

        ICommand openBlodsugerWindowCommand;
        public ICommand OpenBlodsugerWindowCommand
        {
            get { return openBlodsugerWindowCommand ?? (openBlodsugerWindowCommand = new RelayCommand(OpenBlodSView, OpenBlodSViewCanExecute)); }
        }

        private void OpenBlodSView()
        {
            blodSWindow = new BlodSView(thisMainWindow, logicStump);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            blodSWindow.ShowDialog();
            if (!String.IsNullOrWhiteSpace(logicStump.LoginSucceeded))
            {
                thisMainWindow.Show();
            }
            else
            {
                thisMainWindow.Close();
            }
        }

        private bool OpenBlodSViewCanExecute()
        {
            if (blodSWindow == null)
            {
                return true;
            }
            return false;
        }

        #endregion
        #region Open BlodP window

        ICommand openBlodPWindowCommand;
        public ICommand OpenBlodPWindowCommand
        {
            get { return openBlodPWindowCommand ?? (openBlodPWindowCommand = new RelayCommand(OpenBlodPView, OpenBlodPViewCanExecute)); }
        }

        private void OpenBlodPView()
        {
            blodPWindow = new BlodPView(thisMainWindow, logicStump);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            blodPWindow.ShowDialog();
            if (!String.IsNullOrWhiteSpace(logicStump.LoginSucceeded))
            {
                thisMainWindow.Show();
            }
            else
            {
                thisMainWindow.Close();
            }
        }

        private bool OpenBlodPViewCanExecute()
        {
            if (blodPWindow == null)
            {
                return true;
            }
            return false;
        }

        #endregion
        #region Open Weight window

        ICommand openWeightWindowCommand;
        public ICommand OpenWeightWindowCommand
        {
            get { return openWeightWindowCommand ?? (openWeightWindowCommand = new RelayCommand(OpenWeightView, OpenWeightViewCanExecute)); }
        }

        private void OpenWeightView()
        {
            weigtWindow = new WeightView(thisMainWindow, logicStump);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            weigtWindow.ShowDialog();
            if (!String.IsNullOrWhiteSpace(logicStump.LoginSucceeded))
            {
                thisMainWindow.Show();
            }
            else
            {
                thisMainWindow.Close();
            }
        }

        private bool OpenWeightViewCanExecute()
        {
            if (weigtWindow == null)
            {
                return true;
            }
            return false;
        }

        #endregion
        #region Logout and Open login window

        ICommand closeloginWindowCommand;
        public ICommand CloseLoginWindowCommand
        {
            get { return closeloginWindowCommand ?? (closeloginWindowCommand = new RelayCommand(CloseLoginView, CloseLoginViewCanExecute)); }
        }

        private void CloseLoginView()
        {
            loginWindow = null;
            blodPWindow = null;
            blodSWindow = null;
            weigtWindow = null;
            if (OpenLoginViewCanExecute())  //Validering på om der er lavet et vindue tidligere
            {
                OpenLoginView();            //Åbner et nyt login vindue
            }
        }

        private bool CloseLoginViewCanExecute()
        {
            if (loginWindow != null)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
