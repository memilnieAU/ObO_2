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
    /// Interaction logic for WeightView.xaml
    /// </summary>
    public partial class WeightView : Window
    {
        WeightViewModel ViewModel;
        Window MainWinRef;
        public WeightView(Window mainWinRef, LogicStump logicStumpRef)
        {
            MainWinRef = mainWinRef;

            ViewModel = new WeightViewModel(this, mainWinRef, logicStumpRef);
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
