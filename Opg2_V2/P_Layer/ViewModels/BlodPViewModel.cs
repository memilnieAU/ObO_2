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

namespace P_Layer.ViewModels
{

    public class BlodPViewModel
    {
        Window ThisWindow;
        LogicStump logicStump;
        public BlodPViewModel(Window WindowRef, Window MainWinRef, LogicStump logicStumpRef)
        {
            ThisWindow = WindowRef;
            logicStump = logicStumpRef;
            grafLoad();
        }

        #region Chart
        public SeriesCollection BlodP { get; set; }
        public String[] Labels { get; set; }



        List<String> labelL;

        ColumnSeries SystolicLine;
        ColumnSeries DiastolicLine;
        void grafLoad()
        {
            BlodP = new SeriesCollection();
            SystolicLine = new ColumnSeries { Title = "Systolic", MaxColumnWidth = 15, MaxWidth = 25, Values = new ChartValues<int>() };
            DiastolicLine = new ColumnSeries { Title = "Diastolic", MaxColumnWidth = 15, Values = new ChartValues<int>() };
            labelL = new List<string>();
            foreach (DTO_BPressure item in logicStump.getBPressureData(""))
            {
                SystolicLine.Values.Add(item.Systolic_);
                DiastolicLine.Values.Add(item.Diastolic_);
                labelL.Add(item.Date_.ToString().Substring(0, 16));
            }

            Labels = labelL.ToArray();

            BlodP.Add(DiastolicLine);
            BlodP.Add(SystolicLine);



        }
        /*Series="{Binding BlodP}"
         * Grid.Column="0" Grid.Row="1" Grid.RowSpan="2"
         * */
        #endregion
    }
}
