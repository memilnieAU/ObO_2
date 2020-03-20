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
    public class BlodSViewModel
    {
        Window ThisWindow;
        LogicStump logicStump;
        public BlodSViewModel(Window WindowRef, Window MainWinRef, LogicStump logicStumpRef)
        {
            ThisWindow = WindowRef;
            logicStump = logicStumpRef;
            grafLoad();
        }

        #region Chart
        public SeriesCollection BlodS { get; set; }
        public String[] Labels { get; set; }



        List<String> labelL;

        LineSeries SugerLine;

        void grafLoad()
        {
            BlodS = new SeriesCollection();
            SugerLine = new LineSeries { Title = "Suger", Values = new ChartValues<double>() };

            labelL = new List<string>();
            foreach (DTO_BSugar item in logicStump.getBSugarData(""))
            {
                SugerLine.Values.Add(item.BloodSugar_);

                labelL.Add(item.Date_.ToString().Substring(0, 16));
            }

            Labels = labelL.ToArray();

            BlodS.Add(SugerLine);




        }
        /*Series="{Binding BlodP}"
         * Grid.Column="0" Grid.Row="1" Grid.RowSpan="2"
         * */
        #endregion
    }
}
