using SNMPLib2020;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TesterSNMPLib
{
    public partial class Form2 : Form
    {
        private SNMPLib2020.ClassSnmpAgent snmpagent2020 = new ClassSnmpAgent();

        public Form2()
        {
            InitializeComponent();
        }

        private void cmdListen_Click(object sender, EventArgs e)
        {
            cmdListen.Text = snmpagent2020.snmpagentStart() ? "Stop" : "Start";
        }

        private void buttonGate_Click(object sender, EventArgs e)
        {
            snmpagent2020.setVarGate(txtTerminalName.Text, txtStationCode.Text, txtUpTime.Text, txtEpcStatus.Text, txtDbStatus.Text, txtOnlineStatus.Text, txtQrsIn.Text, txtQrsOut.Text, txtReaderIn.Text, txtReaderOut.Text, txtController.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = snmpagent2020.snmpagentStart() ? "Stop" : "Start";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            snmpagent2020.setVarPos(txtTerminalNamePos.Text, txtStationCodePos.Text, txtUpTimePos.Text, txtEpcStatusPos.Text, txtDbStatusPos.Text, txtOnlineStatusPos.Text, txtPrinterStatusPos.Text, txtQrsStatusPos.Text, txtReaderStatusPos.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = snmpagent2020.snmpagentStart() ? "Stop" : "Start";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = snmpagent2020.snmpagentStart() ? "Stop" : "Start";
        }
    }
}
