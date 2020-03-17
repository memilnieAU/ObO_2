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
using Opg2_v1.ViewModel;
using Opg2_v1.Interface;
using Logic_tier;

namespace Opg2_v1
{
    /// <summary>
    /// Interaction logic for HomePage_Win.xaml
    /// 
    ///  <Window.DataContext>
    ///    <local:HomePage_Win_ViewModel/>
    /// </Window.DataContext>
    /// 
    /// </summary>
    public partial class HomePage_Win : Window, ICloseable
    {
        public HomePage_Win(Logic logicRef)
        {
            InitializeComponent();
            DataContext = new HomePage_Win_ViewModel(logicRef);
        }
    }
}

