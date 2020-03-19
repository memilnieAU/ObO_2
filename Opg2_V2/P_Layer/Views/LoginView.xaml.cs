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
        public LoginView(Window mainWinRef , LogicStump logicStumpRef)
        {
            MainWinRef = mainWinRef;
            ViewModel = new LoginViewModel(this, mainWinRef, logicStumpRef);
            InitializeComponent();
            DataContext = ViewModel;
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
 