using DTOs;
using System;
using System.Collections.Generic;
using System.IO;

namespace D_Layer
{
    public class DataFile : IData
    {
        private FileStream input;
        private StreamReader reader;
        
        public DataFile() { }


        public int isUserRegistered(String socSecNb, String pw)
        {
            int result = 2;
            
            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);
            string path = input.ToString();
            string inputRecord;
            string[] inputFields;

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb && inputFields[1] == pw)
                {

                    result = 1;
                    break;
                }
                else if (inputFields[0] == socSecNb)
                {
                    result = 3;
                }
            }

            reader.Close();

            return result;
        }

       
        
        public int GetHeight(string socSecNb)
        {
            int result = 0;

            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);
            string path = input.ToString();
            string inputRecord;
            string[] inputFields;

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');
                if (inputFields[0] == socSecNb)
                {
                    if (inputFields[2] != null)
                    {
                        result = Convert.ToInt32(inputFields[2]);
                        break;
                    }

                }
            }

            reader.Close();

            return result;
        }

        public List<DTO_Weight> getWeightData(string socSecNb)  //Virker
        {
            List<DTO_Weight> personWeight = new List<DTO_Weight>();

            // string-objekter til at gemme det som læses fra filen
            string inputRecord;
            string[] inputFields;


            // opret de nødvendige stream-objekter
            FileStream input = new FileStream("Weight Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);


            // indlæs sålænge der er data i filen
            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                // split data op i fornavn, efternavn og telefonnummer
                inputFields = inputRecord.Split(';');
                if (inputFields[0] == socSecNb)
                {

                    // gem data i listen
                    personWeight.Add(new DTO_Weight(Convert.ToDouble(inputFields[1]), 0, Convert.ToDateTime(inputFields[2])));
                }
            }

            // luk adgang til filen
            fileReader.Close();


            return personWeight;
        }

        public List<DTO_BSugar> GetBSugarData(string socSecNb)
        {
            List<DTO_BSugar> personBSuger = new List<DTO_BSugar>();

            // string-objekter til at gemme det som læses fra filen
            string inputRecord;
            string[] inputFields;


            // opret de nødvendige stream-objekter
            FileStream input = new FileStream("Blood Sugar Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);


            // indlæs sålænge der er data i filen
            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                // split data op i fornavn, efternavn og telefonnummer
                inputFields = inputRecord.Split(';');
                if (inputFields[0] == socSecNb)
                {

                    // gem data i listen
                    personBSuger.Add(new DTO_BSugar(Convert.ToDouble(inputFields[1]), Convert.ToDateTime(inputFields[2])));
                }
            }

            // luk adgang til filen
            fileReader.Close();


            return personBSuger;
        }

        public List<DTO_BPressure> getBPressureData(string socSecNb)
        {
            List<DTO_BPressure> personBPressure = new List<DTO_BPressure>();

            // string-objekter til at gemme det som læses fra filen
            string inputRecord;
            string[] inputFields;


            // opret de nødvendige stream-objekter
            FileStream input = new FileStream("Blood Pressure Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);


            // indlæs sålænge der er data i filen
            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                // split data op i fornavn, efternavn og telefonnummer
                inputFields = inputRecord.Split(';');
                if (inputFields[0] == socSecNb)
                {

                    // gem data i listen
                    personBPressure.Add(new DTO_BPressure(Convert.ToInt32(inputFields[1]), Convert.ToInt32(inputFields[2]), Convert.ToDateTime(inputFields[3])));
                }
            }

            // luk adgang til filen
            fileReader.Close();


            return personBPressure;
        }
        
    }
}
