using System;

namespace Matriale
{
    public class Stuff
    {

        #region Variabler

        #endregion
        #region Ctor

        #endregion
        #region Metoder

        #endregion
        #region Commando
        #region Open login window

        ICommand openloginWindowCommand;
        public ICommand OpenLoginWindowCommand
        {
            get { return openloginWindowCommand ?? (openloginWindowCommand = new RelayCommand(OpenLoginView, OpenLoginViewCanExecute)); }
        }

        private void OpenLoginView()
        {
            loginWindow = new LoginView();
            //Application.Current.MainWindow.Hide();
            mainWindow.Hide();
            loginWindow.ShowDialog();
            mainWindow.Show();
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
        #endregion
    }
}
