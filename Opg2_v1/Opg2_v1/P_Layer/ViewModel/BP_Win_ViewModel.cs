using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using Opg2_v1.View;
using Prism.Commands;
using Opg2_v1.Interface;
using GalaSoft.MvvmLight.Command;
using Logic_tier;

using LiveCharts;
using LiveCharts.Wpf;
using DTO;

namespace Opg2_v1.ViewModel
{
    class BP_Win_ViewModel
    {
        Logic logic_Lay;
        public int WindowCount { get; set; }
        public BP_Win_ViewModel(Logic logicRef)
        {
            logic_Lay = logicRef;
            this.CloseWindowCommandHP = new RelayCommand<ICloseable>(this.CloseWindowHP);
            logic_Lay.WindowCounter++;


            WindowCount = logic_Lay.WindowCounter;
            grafLoad();
        }

        #region Open HP Window Commands
        //Properties
        public RelayCommand<ICloseable> CloseWindowCommandHP { get; private set; }

        //Methods
        private void CloseWindowHP(ICloseable window)
        {
            OpenHPCommandHandler();
            if (window != null)
                window.Close();
        }

        HomePage_Win HP_Window;
        private ICommand openHPCommand;
        public ICommand OpenHPCommand
        {
            get
            {
                return openHPCommand ?? (openHPCommand = new DelegateCommand(OpenHPCommandHandler));
            }
        }

        void OpenHPCommandHandler()
        {
            HP_Window = new HomePage_Win(logic_Lay);
            HP_Window.Show();

        }
        #endregion

        #region Chart
        public SeriesCollection BlodP { get; set; }
        public String[] Labels { get; set; }
        List<String> labelL;

        ColumnSeries SystolicLine;
        ColumnSeries DiastolicLine;
        void grafLoad()
        { 
            BlodP = new SeriesCollection();
            SystolicLine = new ColumnSeries {Title= "Systolic", Values = new ChartValues<int>() };
            DiastolicLine = new ColumnSeries { Title = "Diastolic", Values = new ChartValues<int>() };
            labelL = new List<string>();
            foreach (DTO_BPressure item in logic_Lay.getBPressureData(""))
            {
                SystolicLine.Values.Add(item.Systolic_);
                DiastolicLine.Values.Add(item.Diastolic_);
                labelL.Add(item.Date_.ToString().Substring(0,16));
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

