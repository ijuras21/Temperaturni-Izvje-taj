using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temperaturni_Izvještaj {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DisplayButton_Click(object sender, EventArgs e) {
            var reportGenerator = new ReportGenerator();
            string report = reportGenerator.GenerateReport();
            DisplayReport(report);
        }
        private void DisplayReport(string report) {
            DisplayTextBox.Text = report;
        }
    }
}
