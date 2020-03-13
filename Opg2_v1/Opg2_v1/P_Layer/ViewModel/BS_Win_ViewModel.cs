using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Opg2_v1.Interface;
using Opg2_v1.View;
using Prism.Commands;
using Logic_tier;
using LiveCharts;
using LiveCharts.Wpf;
using DTO;

namespace Opg2_v1.ViewModel
{
    class BS_Win_ViewModel
    {
        Logic logic_Lay;
        public int WindowCount { get; set; }
        public BS_Win_ViewModel(Logic logicRef)
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
        public SeriesCollection BlodS { get; set; }
        public String[] Labels { get; set; }



        List<String> labelL;

        LineSeries SugerLine;
     
        void grafLoad()
        {
            BlodS = new SeriesCollection();
            SugerLine = new LineSeries { Title = "Suger", Values = new ChartValues<double>() };
           
            labelL = new List<string>();
            foreach (DTO_BSugar item in logic_Lay.getBSugarData(""))
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
