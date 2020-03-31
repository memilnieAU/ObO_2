﻿using MyCommands;
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
using System.IO;

namespace P_Layer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private static MainWindowViewModel instance;

        public static MainWindowViewModel Instance
        {
            get {
                if (instance == null)
                    instance = new MainWindowViewModel();
                return instance; }
        }

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
     
        Logic logic;

        public MainWindowViewModel()
        {

        }

        public MainWindowViewModel(Window mainWindowRef)
        {
            thisMainWindow = mainWindowRef;
            thisMainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            logic = new Logic();

            if (OpenLoginViewHandlerCanExecute())  //Validering på om der er lavet et vindue tidligere
            {
                OpenLoginViewHandler();            //Åbner et nyt login vindue
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
            get { return sendDataCommand ?? (sendDataCommand = new RelayCommand(SendDataHandler, SendDataHandlerCanExecute)); }
        }

        public void SendDataHandler()
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

            DataIsSent = "Periode sendt";
        }


        public bool SendDataHandlerCanExecute()
        {


            if (!OneWeekChecked && !TwoWeekChecked && !FourWeekChecked)
            {
                return false;
            }
            DataIsSent = "[S]  Send";
            return true;

        }

        #endregion


        #region Open login window


        ICommand openloginWindowCommand;
        public ICommand OpenLoginWindowCommand
        {
            get { return openloginWindowCommand ?? (openloginWindowCommand = new RelayCommand(OpenLoginViewHandler, OpenLoginViewHandlerCanExecute)); }
        }
        
        public String UserInSystem { get; set; }
        private void OpenLoginViewHandler()
        {
            loginWindow = new LoginView(thisMainWindow, logic);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            loginWindow.ShowDialog();
            if (!String.IsNullOrWhiteSpace(logic.LoginSucceeded))
            {
                UserInSystem = "Du er logget på som: " + logic.LoginSucceeded.Substring(0,6);
                thisMainWindow.Show();
            }
            if (String.IsNullOrWhiteSpace(logic.LoginSucceeded))
            {
                thisMainWindow.Close();
            }
        }

        private bool OpenLoginViewHandlerCanExecute()
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
            get { return openBlodsugerWindowCommand ?? (openBlodsugerWindowCommand = new RelayCommand(OpenBlodsugerWindowHandler, OpenBlodsugerWindowHandlerCanExecute)); }
        }

        public void OpenBlodsugerWindowHandler()
        {
            blodSWindow = new BlodSView(thisMainWindow, logic);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            blodSWindow.ShowDialog();
            blodSWindow = null;
            if (!String.IsNullOrWhiteSpace(logic.LoginSucceeded))
            {
                thisMainWindow.Show();
            }
            else
            {
                thisMainWindow.Close();
            }
        }

        public bool OpenBlodsugerWindowHandlerCanExecute()
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
            get { return openBlodPWindowCommand ?? (openBlodPWindowCommand = new RelayCommand(OpenBlodPWindowHandler, OpenBlodPWindowHandlerCanExecute)); }
        }

        public void OpenBlodPWindowHandler()
        {
            blodPWindow = new BlodPView(thisMainWindow, logic);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            blodPWindow.ShowDialog();
            blodPWindow = null;
            if (!String.IsNullOrWhiteSpace(logic.LoginSucceeded))
            {
                thisMainWindow.Show();
            }
            else
            {
                thisMainWindow.Close();
            }
        }

        public bool OpenBlodPWindowHandlerCanExecute()
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
            get { return openWeightWindowCommand ?? (openWeightWindowCommand = new RelayCommand(OpenWeightWindowHandler, OpenWeightWindowHandlerCanExecute)); }
        }

        public void OpenWeightWindowHandler()
        {
            weigtWindow = new WeightView(thisMainWindow, logic);
            //Application.Current.MainWindow.Hide();
            thisMainWindow.Hide();
            weigtWindow.ShowDialog();
            weigtWindow = null;
            if (!String.IsNullOrWhiteSpace(logic.LoginSucceeded))
            {
                thisMainWindow.Show();
            }
            else
            {
                thisMainWindow.Close();
            }
        }

        public bool OpenWeightWindowHandlerCanExecute()
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
            get { return closeloginWindowCommand ?? (closeloginWindowCommand = new RelayCommand(CloseLoginViewCommandHandler, CloseLoginViewHandlerCanExecute)); }
        }

        public void CloseLoginViewCommandHandler()
        {
            loginWindow = null;
            blodPWindow = null;
            blodSWindow = null;
            weigtWindow = null;
            logic.LoginSucceeded = "";
            if (OpenLoginViewHandlerCanExecute())  //Validering på om der er lavet et vindue tidligere
            {
                OpenLoginViewHandler();            //Åbner et nyt login vindue
            }
        }

        public bool CloseLoginViewHandlerCanExecute()
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
