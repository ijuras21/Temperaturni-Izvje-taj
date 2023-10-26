using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperaturni_Izvještaj {
    internal class Sensor {
        public string Identifier { get; set; }

        public Sensor (string identifier) {
            Identifier = identifier;
        }

        public double[] FetchData() {
            double[] data = new double[24];
            var r = new Random();
            for(int i=0; i<24; i++) {
                data[i] = r.Next(30, 60) + r.NextDouble();
            }
            return data;
        }

    }
}
