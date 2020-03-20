using DTOs;
using L_Layer;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace P_Layer.ViewModels
{
    public class WeightViewModel
    {
        Window ThisWindow;
        LogicStump logicStump;
        public WeightViewModel(Window WindowRef, Window MainWinRef, LogicStump logicStumpRef)
        {
            ThisWindow = WindowRef;
            logicStump = logicStumpRef;
            grafLoad();
        }
        #region Chart
        public SeriesCollection WeigthGraf { get; set; }
        public String[] Labels { get; set; }

        public AxesCollection AxisYCollection { get; set; }


        List<String> labelL;

        LineSeries WeigthLine;
        LineSeries BmiLine;
        void grafLoad()
        {
            WeigthGraf = new SeriesCollection();
            WeigthLine = new LineSeries { Title = "Vægt", Values = new ChartValues<double>(), ScalesYAt = 0,Foreground = Brushes.Red };
            BmiLine = new LineSeries { Title = "Bmi", Values = new ChartValues<int>(), ScalesYAt = 1, Foreground = Brushes.Blue };
            labelL = new List<string>();
            foreach (DTO_Weight item in logicStump.getWeightAndBMIData(""))
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
                   Step = 1,  Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255,0,0))
               
                     },
                    Foreground= Brushes.Red } ,
                new Axis {
                     Separator = new Separator
                {
                         Step = 1,
                   StrokeThickness = 1,
                   StrokeDashArray = new System.Windows.Media.DoubleCollection(3),
                   Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0,0,255))
                },
                    Foreground = Brushes.Blue  }
            };


        }
        #endregion
    }
}
