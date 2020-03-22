using MyCommands;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using P_Layer.ViewModels;

namespace P_Layer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    ///      <Window.DataContext>
   ///          <viewmodels:MainWindowViewModel/>
    ///      </Window.DataContext>
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainWindowViewModel;
        public MainWindow()
        {
            mainWindowViewModel = new MainWindowViewModel(this);
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }

        private void Tastatur_Tryk(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.S:
                case Key.Oem5:
                    if (mainWindowViewModel.SendDataHandlerCanExecute())
                    {
                        mainWindowViewModel.SendDataHandler();
                    }
                    break;
                case Key.D0:
                    break;
                case Key.D1:
                    rad_1Week.IsChecked = true;
                    break;
                case Key.D2:
                    rad_2Week.IsChecked = true;
                    break;
                case Key.D3:
                    break;
                case Key.D4:
                    rad_4Week.IsChecked = true;
                    break;
                case Key.Escape:
                    if (mainWindowViewModel.CloseLoginViewHandlerCanExecute())
                    {
                        mainWindowViewModel.CloseLoginViewCommandHandler();
                    }
                    break;
                case Key.F1:
                    if (mainWindowViewModel.OpenBlodsugerWindowHandlerCanExecute())
                    {
                        mainWindowViewModel.OpenBlodsugerWindowHandler();
                    }
                    break;
                case Key.F2:
                    if (mainWindowViewModel.OpenBlodPWindowHandlerCanExecute())
                    {
                        mainWindowViewModel.OpenBlodPWindowHandler();
                    }
                    break;
                case Key.F3:
                    if (mainWindowViewModel.OpenWeightWindowHandlerCanExecute())
                    {
                        mainWindowViewModel.OpenWeightWindowHandler();
                    }
                    break;
                #region Spare Keys

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
