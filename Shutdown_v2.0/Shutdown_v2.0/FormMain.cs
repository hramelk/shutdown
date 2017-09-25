using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_v2._0 {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e) {

        }

        private bool shutdown_command(string command_str) {
            try {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "shutdown.exe";
                startInfo.Arguments = command_str;
                process.StartInfo = startInfo;
                process.Start();
            } catch (Exception e) {
                // process exception
            }
            return true;
        }

        private void time_number_Enter(object sender, EventArgs e) {
            time_number.Select(0, time_number.Text.Length);
        }

        private void buttonShutdown_Click(object sender, EventArgs e) {

            int time_value_int = Convert.ToInt32(time_number.Value);

            if (time_value_int == 0) {
                //time_number.BackColor = Color.Red;
                time_number.BackColor = Color.Pink;
                return;
            } else {
                time_number.BackColor = Color.White;
            }

            string arguments = "/s /t ";
            if (checkBoxForce.Checked == true) {
                arguments = "/s /f /t ";
            }

            if (radioButtonMinutes.Checked == true) {
                time_value_int = time_value_int * 60;
            } else if (radioButtonHours.Checked == true) {
                time_value_int = time_value_int * 60 * 60;
            }

            string time_value_str = time_value_int.ToString();

            shutdown_command(arguments + time_value_str);
        }

        private void buttonRestart_Click(object sender, EventArgs e) {
            int time_value_int = Convert.ToInt32(time_number.Value);

            if (time_value_int == 0) {
                //time_number.BackColor = Color.Red;
                time_number.BackColor = Color.Pink;
                return;
            } else {
                time_number.BackColor = Color.White;
            }

            string arguments = "/r /t ";
            if (checkBoxForce.Checked == true) {
                arguments = "/r /f /t ";
            }
            
            if (radioButtonMinutes.Checked == true) {
                time_value_int = time_value_int * 60;
            } else if (radioButtonHours.Checked == true) {
                time_value_int = time_value_int * 60 * 60;
            }
            
            string time_value_str = time_value_int.ToString();

            shutdown_command(arguments + time_value_str);
        }

        private void buttonAbort_Click(object sender, EventArgs e) {
            shutdown_command("/a");
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void time_number_ValueChanged(object sender, EventArgs e) {
            int time_value_int = Convert.ToInt32(time_number.Value);

            if (time_value_int == 0) {
                time_number.BackColor = Color.Pink;
                return;
            } else {
                time_number.BackColor = Color.White;
            }
        }

        //private void time_number_ValueChanged(object sender, EventArgs e) {
        //    int time_value_int = Convert.ToInt32(time_number.Value);

        //    if (time_value_int == 0) {
        //        buttonShutdown.Enabled = false;
        //        buttonRestart.Enabled = false;
        //    } else {
        //        buttonShutdown.Enabled = true;
        //        buttonRestart.Enabled = true;
        //    }
        //}



    }
}
