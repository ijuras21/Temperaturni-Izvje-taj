using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperaturni_Izvještaj {
    internal class ReportGenerator {

        public string GenerateReport() {
            var sensorSystem = new SensorSystem();
            double[] temperatures = sensorSystem.GetHourlyTemperatures();

            string report = PrepareReport(temperatures);
            return report;
        }

        private string PrepareReport(double[] temperatures) {
            string report = "";
            report += PrepareHeader();
            report += PrepareHourlyData(temperatures);
            report += PrepareAverageTemperature(temperatures);
            report += PrepareMinimalTemperature(temperatures);
            report += PrepareMaximalTemperature(temperatures);
            return report;
        }
        private string PrepareMaximalTemperature(double[] temperatures) {
            return $"Maximal temperature is {Math.Round(temperatures.Max(), 2)} °C" +
           Environment.NewLine;
        }
        private string PrepareMinimalTemperature(double[] temperatures) {
            return $"Minimal temperature is {Math.Round(temperatures.Min(), 2)} °C" +
           Environment.NewLine;
        }
        private string PrepareAverageTemperature(double[] temperatures) {
            return $"Average temperature is {Math.Round(temperatures.Average(), 2)} °C" +
           Environment.NewLine;
        }
        private string PrepareHourlyData(double[] temperatures) {
            string hourlyData = "";
            for (int i = 0; i < 24; i++) {
                hourlyData += $"{i} - {i + 1} h = {Math.Round(temperatures[i],2)}" + Environment.NewLine;
            }
            return hourlyData;
        }
        private string PrepareHeader() {
            string header = "";
            header += "REPORT" + Environment.NewLine;
            header += "****************" + Environment.NewLine;
            return header;
        }
    }
}
