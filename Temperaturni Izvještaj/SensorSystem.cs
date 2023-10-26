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
    }
}
