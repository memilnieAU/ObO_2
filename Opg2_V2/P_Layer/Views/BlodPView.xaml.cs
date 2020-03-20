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
        public BlodPView(Window mainWinRef, LogicStump logicStumpRef)
        {
            MainWinRef = mainWinRef;
            ViewModel = new BlodPViewModel(this, mainWinRef, logicStumpRef);
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
