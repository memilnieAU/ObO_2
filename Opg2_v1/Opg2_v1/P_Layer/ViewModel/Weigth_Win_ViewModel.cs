using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Opg2_v1.Interface;
using Prism.Commands;
using System.Windows.Input;
using Logic_tier;
using LiveCharts;
using LiveCharts.Wpf;
using DTO;

namespace Opg2_v1.ViewModel
{
    class Weigth_Win_ViewModel
    {
        Logic logic_Lay;
        public int WindowCount { get; set; }
       
        public Weigth_Win_ViewModel(Logic logicRef)
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
        public SeriesCollection WeigthGraf { get; set; }
        public String[] Labels { get; set; }

        public AxesCollection AxisYCollection { get; set; }


        List<String> labelL;

        LineSeries WeigthLine;
        LineSeries BmiLine;
        void grafLoad()
        {
            WeigthGraf = new SeriesCollection();
            WeigthLine = new LineSeries { Title = "Vægt", Values = new ChartValues<double>(), ScalesYAt = 0 };
            BmiLine = new LineSeries { Title = "Bmi", Values = new ChartValues<int>(), ScalesYAt = 1 };
            labelL = new List<string>();
            foreach (DTO_Weight item in logic_Lay.getWeightAndBMIData(""))
            {
                WeigthLine.Values.Add(item.Weight_);
                BmiLine.Values.Add(item.BMI_);
                labelL.Add(item.Date_.ToString().Substring(0, 16));
            }

            Labels = labelL.ToArray();
            
            WeigthGraf.Add(BmiLine);
            WeigthGraf.Add(WeigthLine);

            AxisYCollection = new AxesCollection
            {
                new Axis { }, new Axis { }
            };


        }
        /*Series="{Binding BlodP}"
         * Grid.Column="0" Grid.Row="1" Grid.RowSpan="2"
         * */
        #endregion

    }
}
