using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nsoftware.IPWorksSNMP;
using SNMPLib2020;

namespace TesterSNMPLib
{
    public partial class Form1 : Form
    {
        //private SnmpAgentLib snmpAgent = new SnmpAgentLib();
        private SNMPLib2020.ClassSnmpAgent snmpagent2020 = new ClassSnmpAgent();

        private nsoftware.IPWorksSNMP.Snmpagent snmpagent = new Snmpagent();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdListen_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    snmpagent.Active = !snmpagent.Active;
            //    txtOIDVal2.Text = "0";
            //    timer1.Enabled = snmpagent1.Active;
            //    if (cmdListen.Text == "Start") lstEvents.Items.Clear();
            //    cmdListen.Text = snmpagent.Active ? "Stop" : "Start";
            //    logEvents("SNMP Agent is : " + snmpagent.Active.ToString());
            //}
            //catch (IPWorksSNMPException ex1)
            //{
            //    if (ex1.Code == 10048)
            //    {
            //        MessageBox.Show("The component is unable to bind to port " + snmpagent1.LocalPort.ToString() + ", you probably already have an agent listening there.  Stop the other agent or use a different port for this demo.");
            //    }
            //    else MessageBox.Show("Exception " + ex1.Code.ToString() + ": " + ex1.Message);
            //}

            //snmpagent2020.snmpagent_Start();
            cmdListen.Text = snmpagent2020.snmpagentStart() ? "Stop" : "Start";
        }

        private void logEvents(string msg)
        {
            if (lstEvents.Items.Count >= 15)
            {
                lstEvents.Items.Clear();
            }

            lstEvents.Items.Add(msg);
            lstEvents.SelectedIndex = lstEvents.Items.Count - 1;
            //if (check_log_walk == "on")
            //{
            //    LogApp(msg);
            //}
        }

        private void btnSet1_Click(object sender, EventArgs e)
        {
            snmpagent2020.set1(txtOIDVal2.Text, txtOIDVal3.Text, txtOIDVal4.Text);
        }
    }
}
