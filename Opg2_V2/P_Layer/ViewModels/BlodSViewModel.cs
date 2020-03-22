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

namespace P_Layer.ViewModels
{
    public class BlodSViewModel
    {
        Window ThisWindow;
        LogicStump logicStump;
        Window MainWindow;
        public BlodSViewModel(Window WindowRef, Window MainWinRef, LogicStump logicStumpRef)
        {
            ThisWindow = WindowRef;
            logicStump = logicStumpRef;
            MainWindow = MainWinRef;
            ThisWindow.Top = MainWindow.Top;
            ThisWindow.Left = MainWindow.Left;
            GrafLoad();
        }

        #region Chart
        public SeriesCollection BlodS { get; set; }
        public String[] Labels { get; set; }



        List<String> labelL;

        LineSeries SugerLine;

        void GrafLoad()
        {
            BlodS = new SeriesCollection() { };
            SugerLine = new LineSeries {  Values = new ChartValues<double>()  };

            labelL = new List<string>();
            foreach (DTO_BSugar item in logicStump.GetBSugarData(""))
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


        #region Close this Window

        ICommand closeThisWindowCommand;


        public ICommand CloseThisWindowCommand
        {
            get { return closeThisWindowCommand ?? (closeThisWindowCommand = new RelayCommand(CloseThisWindowHandler, CloseThisWindowHandlerCanExecute)); }
        }

        public void CloseThisWindowHandler()
        {
            ThisWindow.Close();

        }

        public bool CloseThisWindowHandlerCanExecute()
        {

            return true;

        }

        #endregion
    }
}
