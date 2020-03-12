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
using Opg2_v1.Interface;
using Opg2_v1.ViewModel;

namespace Opg2_v1.View
{
    /// <summary>
    /// Interaction logic for Login_Win.xaml
    /// </summary>
    public partial class Login_Win : Window, ICloseable
    {
        public Login_Win()
        {
            InitializeComponent();
            DataContext = new Login_win_ViewModel();

        }
    }
}
