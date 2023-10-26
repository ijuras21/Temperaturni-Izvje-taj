using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperaturni_Izvještaj {

    enum Unit {
        Celsius,
        Fahrenheit
    }

    internal class Converter {
        private Unit from;
        private Unit to;

        public Converter(Unit from, Unit to) {
            this.from = from;
            this.to = to;
        }

        public double[] Convert(double[] temperatures) {
            double[] convertedData = new double[temperatures.Length];
            if(from == Unit.Fahrenheit && to == Unit.Celsius) {
                for(int i=0; i<temperatures.Length; i++) {
                    convertedData[i] = (temperatures[i] - 32) * 5 / 9;
                }
            } else {
                throw new NotSupportedException();
            }
            return convertedData;
        }
    }
}
