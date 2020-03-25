using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using P_Layer.ViewModels;
using L_Layer;

namespace P_Layer.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        LoginViewModel ViewModel;
        Window MainWinRef;
        public LoginView(Window mainWinRef, Logic logicRef)
        {
            MainWinRef = mainWinRef;
            ViewModel = new LoginViewModel(this, MainWinRef, logicRef);
            InitializeComponent();
            DataContext = ViewModel;

            TBx_UserName.SelectAll();
            TBx_UserName.Focus();

        }


        private void Tastatur_Tryk(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.Enter:
                case Key.Oem5:
                    if (ViewModel.LoginHandlerCanExecute())
                    {
                        ViewModel.LoginHandler();
                    }
                    break;

                case Key.Tab:
                    if (TBx_UserName.IsFocused)
                    {
                        TBx_PassWord.Focus();
                        TBx_PassWord.SelectAll();
                    }
                    else if (TBx_PassWord.IsFocused)
                    {
                        TBx_UserName.Focus();
                        TBx_UserName.SelectAll();

                    }
                    break;
                case Key.Escape:
                    if (ViewModel.CloseHandlerCanExecute())
                    {
                        ViewModel.CloseHandlerExecute();
                    }
                    break;
                #region SpareKeys

                case Key.D0:
                    break;
                case Key.D1:
                    break;
                case Key.D2:
                    break;
                case Key.D3:
                    break;
                case Key.D4:

                    break;
                case Key.D5:
                    break;
                case Key.D6:
                    break;
                case Key.D7:
                    break;
                case Key.D8:
                    break;
                case Key.D9:
                    break;

                case Key.F1:

                    break;
                case Key.F2:

                    break;
                case Key.F3:

                    break;
                case Key.F4:

                    break;
                case Key.F5:
                    break;
                case Key.F6:
                    break;
                case Key.F7:
                    break;
                case Key.F8:
                    break;
                case Key.F9:
                    break;

                default:
                    break;
                    #endregion
            }

        }

       
    }
}
