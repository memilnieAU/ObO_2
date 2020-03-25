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

    public class BlodPViewModel
    {
        Window ThisWindow;
        Logic logic;
        Window MainWindow;
        public BlodPViewModel(Window WindowRef, Window MainWinRef, Logic logicRef)
        {
            ThisWindow = WindowRef;
            logic = logicRef;
            MainWindow = MainWinRef;
            ThisWindow.Top = MainWindow.Top;
            ThisWindow.Left = MainWindow.Left;
            GrafLoad();
        }

        #region Chart
        public SeriesCollection BlodP { get; set; }
        public String[] Labels { get; set; }



        List<String> labelL;

        ColumnSeries SystolicLine;
        ColumnSeries DiastolicLine;
        void GrafLoad()
        {
            
            BlodP = new SeriesCollection();
            SystolicLine = new ColumnSeries { Title = "Systoliske tryk", MaxColumnWidth = 15, MaxWidth = 25, Values = new ChartValues<int>() };
            DiastolicLine = new ColumnSeries { Title = "Diastoliske tryk", MaxColumnWidth = 15, Values = new ChartValues<int>() };
            labelL = new List<string>();
            foreach (DTO_BPressure item in logic.getBPressureData(""))
            {
                SystolicLine.Values.Add(item.Systolic_);
                DiastolicLine.Values.Add(item.Diastolic_);
                labelL.Add(item.Date_.ToString().Substring(0,10));
            }

            Labels = labelL.ToArray();

            BlodP.Add(DiastolicLine);
            BlodP.Add(SystolicLine);



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
