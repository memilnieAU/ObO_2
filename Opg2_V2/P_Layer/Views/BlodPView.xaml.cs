using L_Layer;
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

namespace P_Layer.Views
{
    /// <summary>
    /// Interaction logic for BlodPView.xaml
    /// </summary>
    public partial class BlodPView : Window
    {
        Window MainWinRef;
        BlodPViewModel ViewModel;
        public BlodPView(Window mainWinRef, Logic logicRef)
        {
            MainWinRef = mainWinRef;
            ViewModel = new BlodPViewModel(this, MainWinRef, logicRef);
            InitializeComponent();
            DataContext = ViewModel;
        }
        private void Tastatur_Tryk(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.Escape:
                    if (ViewModel.CloseThisWindowHandlerCanExecute())
                    {
                        ViewModel.CloseThisWindowHandler();
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
