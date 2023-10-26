using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperaturni_Izvještaj {
    internal class SensorSystem {
        private Sensor primary = new Sensor("Sensor-01");
        private Sensor secondary = new Sensor("Sensor-02");

        public double[] GetHourlyTemperatures() {
            double[] primaryData = primary.FetchData();
            double[] secondaryData = secondary.FetchData();

            double[] combinedData = CombineData(primaryData, secondaryData);

            var converter = new Converter(Unit.Fahrenheit, Unit.Celsius);
            double[] temperatures = converter.Convert(combinedData);

            return temperatures;
        }

        private double[] CombineData(double[] primaryData, double[] secondaryData) {
            double[] combinedData = new double[24];
            for (int hourIndex = 0; hourIndex < 24; hourIndex++)
            {
                combinedData[hourIndex] = CalculateTemperature(primaryData, secondaryData, hourIndex);
            }
            return combinedData;
        }
        private double CalculateTemperature(double[] primaryData, double[] secondaryData, int
hourIndex) {
            double pTemp = primaryData[hourIndex];
            double sTemp = secondaryData[hourIndex];
            bool pTempValid = IsValid(pTemp);
            bool sTempValid = IsValid(sTemp);
            double calculatedTemp;

            if (pTempValid && sTempValid) {
                calculatedTemp = (pTemp + sTemp) / 2;
            } else if (pTempValid == true && sTempValid == false) {
                calculatedTemp = pTemp;
            } else if (pTempValid == false && sTempValid == true) {
                calculatedTemp = sTemp;
            } else {
                calculatedTemp = PerformInterpolation(primaryData, secondaryData, hourIndex);
            }
            return calculatedTemp;
        }
        private bool IsValid(double pTemp) {
            return pTemp != -1000;
        }        private double PerformInterpolation(double[] primaryData, double[] secondaryData, int hourIndex) {
            throw new NotImplementedException();
        }
    }
}
