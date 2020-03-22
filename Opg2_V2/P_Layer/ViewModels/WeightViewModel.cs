using DTOs;
using L_Layer;
using LiveCharts;
using LiveCharts.Wpf;
using MyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using P_Layer.Views;


namespace P_Layer.ViewModels
{
    public class WeightViewModel
    {
        Window ThisWindow;
        LogicStump logicStump;
        MainWindowViewModel MainWindow;
        public WeightViewModel(MainWindowViewModel MainWinRef, LogicStump logicStumpRef)
        {
            ThisWindow = new WeightView(this);
            ThisWindow.Show();
            MainWindow = MainWinRef;
            logicStump = logicStumpRef;
            ThisWindow.Top = MainWindow.thisMainWindow.Top;
            ThisWindow.Left = MainWindow.thisMainWindow.Left;
            GrafLoad();
        }
        #region Chart
        public SeriesCollection WeigthGraf { get; set; }

        public String[] Labels { get; set; }

        public AxesCollection AxisYCollection { get; set; }


        List<String> labelL;

        LineSeries WeigthLine;
        LineSeries BmiLine;
        void GrafLoad()
        {
            WeigthGraf = new SeriesCollection();
            WeigthLine = new LineSeries {Fill = Brushes.Transparent,  Title = "Vægt", Values = new ChartValues<double>(), ScalesYAt = 0,Foreground = Brushes.Red };
            BmiLine = new LineSeries { Fill = Brushes.Transparent , Title = "Bmi", Values = new ChartValues<int>(), ScalesYAt = 1, Foreground = Brushes.Blue };
            labelL = new List<string>();
            foreach (DTO_Weight item in logicStump.GetWeightAndBMIData(""))
            {
                WeigthLine.Values.Add(item.Weight_);
                BmiLine.Values.Add(item.BMI_);
                labelL.Add(item.Date_.ToString().Substring(0, 10));
            }

            Labels = labelL.ToArray();

            WeigthGraf.Add(BmiLine);
            WeigthGraf.Add(WeigthLine);

            AxisYCollection = new AxesCollection
            {
                
                new Axis {
                     Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(2),
                   Step = 1 
               
                     },
                    Foreground= Brushes.Red } ,
                new Axis {
                     Separator = new Separator
                {
                         Step = 0.5,
                   StrokeThickness = 1,
                   StrokeDashArray = new System.Windows.Media.DoubleCollection(3),
                   Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0,0,0))
                },
                    Foreground = Brushes.Blue  }
            };


        }
        #endregion


        #region Close this Window

        ICommand closeThisWindowCommand;
     

        public ICommand CloseThisWindowCommand
        {
            get { return closeThisWindowCommand ?? (closeThisWindowCommand = new RelayCommand(CloseThisWindowHandler, CloseThisWindowHandlerCanExecute)); }
        }

        public void CloseThisWindowHandler()
        {
            MainWindow.OpenOrClose();
            ThisWindow.Close();

        }

        public bool CloseThisWindowHandlerCanExecute()
        {
           
                return true;
            
        }

        #endregion
    }
}
