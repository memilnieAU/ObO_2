﻿using System;
using System.Collections.Generic;
using D_Layer;
using DTOs;

namespace L_Layer
{
    public class Logic
    {
        DataFile dataFile;

        public Logic()
        {
            dataFile = new DataFile();
        }

        
        public string LoginSucceeded { get; set; }
        public int CheckLogin(String socSecNb, String pw)
        {
            if (dataFile.isUserRegistered(socSecNb, pw))
            {
                LoginSucceeded = socSecNb;
                return 1;

            }
            int test = dataFile.GetHeight(socSecNb);

            return 0;
        }
        public List<DTO_BPressure> getBPressureData(string socSecNb)
        {
            return dataFile.getBPressureData(LoginSucceeded);
        }

        public List<DTO_BSugar> GetBSugarData(string socSecNb)
        {
            return dataFile.GetBSugarData(LoginSucceeded);
        }


        public List<DTO_Weight> getWeightAndBMIData(string socSecNb)
        {
            List<DTO_Weight> målinger = dataFile.getWeightData(LoginSucceeded);
            foreach (DTO_Weight måling in målinger)
            {
                double højde = Convert.ToDouble(dataFile.GetHeight(LoginSucceeded)) / 100;
                måling.BMI_ = (int)(måling.Weight_ / (højde * højde));
            }
            return målinger;
        }


    }
}
