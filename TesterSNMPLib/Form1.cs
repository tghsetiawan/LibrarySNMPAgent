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
            this.snmpagent.OnGetRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetRequestHandler(this.snmpagent_OnGetRequest);
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

        //private void OnGetRequest_Data(string a, string b, string c, )
        //{
        //    snmpagent_OnGetRequest(sender, e);
        //    cmdListen_Click(this, (EventArgs)e);
        //    //snmpagent_OnGetRequest(new object(), new EventArgs());
        //}

        private void snmpagent_OnGetRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetRequestEventArgs e)
        {
            Console.WriteLine("GetRequest");

            e.Respond = true;

            var a = "";
            var b = "";

            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                for (int i = 0; i < snmpagent.Objects.Count; i++)
                {
                    //set objType and objValue to send get response
                    switch (snmpagent.Objects[i].Oid)
                    {
                        case "1.3.6.1.4.1.17.1":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.4.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        default:
                            e.ErrorStatus = 2;
                            break;
                    }
                }
            }
            else if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                for (int i = 0; i < snmpagent.Objects.Count; i++)
                {
                    //set objType and objValue to send get response
                    switch (snmpagent.Objects[i].Oid)
                    {
                        case "1.3.6.1.4.1.17.1":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.4.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        default:
                            e.ErrorStatus = 2;
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < snmpagent.Objects.Count; i++)
                {
                    //set objType and objValue to send get response
                    switch (snmpagent.Objects[i].Oid)
                    {
                        case "1.3.6.1.4.1.17.1":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.4.0":
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        default:
                            e.ErrorStatus = 2;
                            break;
                    }
                }
            }
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
    }
}
