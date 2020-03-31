using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_Layer
{
    public interface IData
    {
        int isUserRegistered(String socSecNb, String pw);
        int GetHeight(String socSecNb);
        List<DTO_Weight> getWeightData(String socSecNb);
        List<DTO_BSugar> GetBSugarData(String socSecNb);
        List<DTO_BPressure> getBPressureData(String socSecNb);
        


    }
}
