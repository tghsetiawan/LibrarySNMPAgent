using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nsoftware.IPWorksSNMP;

namespace SNMPLib
{
    public class SnmpAgentLib
    {
        private nsoftware.IPWorksSNMP.Snmpagent snmpagent;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.snmpagent = new nsoftware.IPWorksSNMP.Snmpagent(this.components);
            // 
            // snmpagent
            // 
            this.snmpagent.About = "IP*Works! SNMP 2016 [Build 6588]";
            //this.snmpagent.InvokeThrough = this;
            this.snmpagent.OnBadPacket += new nsoftware.IPWorksSNMP.Snmpagent.OnBadPacketHandler(this.snmpagent_OnBadPacket);
            this.snmpagent.OnDiscoveryRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnDiscoveryRequestHandler(this.snmpagent_OnDiscoveryRequest);
            this.snmpagent.OnError += new nsoftware.IPWorksSNMP.Snmpagent.OnErrorHandler(this.snmpagent_OnError);
            this.snmpagent.OnGetBulkRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetBulkRequestHandler(this.snmpagent_OnGetBulkRequest);
            //this.snmpagent.OnGetNextRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagent_OnGetNextRequest);
            this.snmpagent.OnGetRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetRequestHandler(this.snmpagent_OnGetRequest);
            this.snmpagent.OnGetUserPassword += new nsoftware.IPWorksSNMP.Snmpagent.OnGetUserPasswordHandler(this.snmpagent_OnGetUserPassword);
            this.snmpagent.OnGetUserSecurityLevel += new nsoftware.IPWorksSNMP.Snmpagent.OnGetUserSecurityLevelHandler(this.snmpagent_OnGetUserSecurityLevel);
            this.snmpagent.OnPacketTrace += new nsoftware.IPWorksSNMP.Snmpagent.OnPacketTraceHandler(this.snmpagent_OnPacketTrace);
            this.snmpagent.OnReport += new nsoftware.IPWorksSNMP.Snmpagent.OnReportHandler(this.snmpagent_OnReport);
            //this.snmpagent.OnSetRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnSetRequestHandler(this.snmpagent_OnSetRequest);
        }

        public void snmpagent_Start()
        {
            try
            {
                snmpagent.Active = !snmpagent.Active;
                Console.WriteLine(snmpagent.Active.ToString());
            }
            catch (IPWorksSNMPException ex1)
            {
                if (ex1.Code == 10048)
                {
                    Console.WriteLine("The component is unable to bind to port " + snmpagent.LocalPort.ToString() + ", you probably already have an agent listening there.  Stop the other agent or use a different port for this demo.");
                }
                Console.WriteLine("Exception " + ex1.Code.ToString() + ": " + ex1.Message);
            }
            snmpagent.RuntimeLicense = "314E4E4241413153554252413153554235504A39323833380000000000000000000000000000000044543435555A454400004443365343435A544E4339330000";
            snmpagent.LocalEngineId = "NI_JakPro_e-Tix_SNMP";
        }

        public void snmpagent_OnReport(object sender, nsoftware.IPWorksSNMP.SnmpagentReportEventArgs e)
        {
            Console.WriteLine("Report");
        }

        public void snmpagent_OnGetBulkRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetBulkRequestEventArgs e)
        {
            Console.WriteLine("GetBulkRequest");
        }

        public void snmpagent_OnError(object sender, nsoftware.IPWorksSNMP.SnmpagentErrorEventArgs e)
        {
            Console.WriteLine("Error: " + e.Description);
        }

        public void snmpagent_OnDiscoveryRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentDiscoveryRequestEventArgs e)
        {
            Console.WriteLine("DiscoveryRequest");
        }

        public void snmpagent_OnBadPacket(object sender, nsoftware.IPWorksSNMP.SnmpagentBadPacketEventArgs e)
        {
            Console.WriteLine("BadPacket: " + e.ErrorDescription);
        }

        public void snmpagent_OnPacketTrace(object sender, nsoftware.IPWorksSNMP.SnmpagentPacketTraceEventArgs e)
        {
            try
            {
                switch (e.Direction)
                {
                    case 1:
                        Console.WriteLine("Packet received from: " + e.PacketAddress + ":" +
                            e.PacketPort); break;
                    case 2:
                        Console.WriteLine("Packet sent to: " + e.PacketAddress + ":" +
                            e.PacketPort); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

        }

        public void snmpagent_OnGetUserPassword(object sender, nsoftware.IPWorksSNMP.SnmpagentGetUserPasswordEventArgs e)
        {
            Console.WriteLine("User: " + e.User + " password: " + e.Password + " passtype: " + e.PasswordType.ToString());
        }

        public void snmpagent_OnGetUserSecurityLevel(object sender, nsoftware.IPWorksSNMP.SnmpagentGetUserSecurityLevelEventArgs e)
        {

        }

        private void snmpagent_OnGetNextRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetNextRequestEventArgs e)
        {
            Console.WriteLine("GetNextRequest");

            e.Respond = true;
        }

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
    }
}
