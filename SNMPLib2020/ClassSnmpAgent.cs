using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nsoftware.IPWorksSNMP;

namespace SNMPLib2020
{
    public class ClassSnmpAgent
    {
        private nsoftware.IPWorksSNMP.Snmpagent snmpagent = new Snmpagent();
        private System.ComponentModel.IContainer components;

        private string strDeviceName, strStasionCode, strUpTime, strConMbc, strConReaderIn, strConReaderOut, strConReader, strStatMbc, strStatReaderIn, srtStatReaderOut, strStatReader;

        public string DeviceName
        {
            get { return strDeviceName; }
            set { strDeviceName = value; }
        }

        public string StasionCode
        {
            get { return strStasionCode; }
            set { strStasionCode = value; }
        }

        public string UpTime
        {
            get { return strUpTime; }
            set { strUpTime = value; }
        }

        public string ConnectionMbc
        {
            get { return strConMbc; }
            set { strConMbc = value; }
        }

        public string ConnectionReaderIn
        {
            get { return strConReaderIn; }
            set { strConReaderIn = value; }
        }
        public string ConnectionReaderOut
        {
            get { return strConReaderOut; }
            set { strConReaderOut = value; }
        }
        public string ConnectionReader
        {
            get { return strConReader; }
            set { strConReader = value; }
        }
        public string StatusMbc
        {
            get { return strStatMbc; }
            set { strStatMbc = value; }
        }
        public string StatusReaderIn
        {
            get { return strStatReaderIn; }
            set { strStatReaderIn = value; }
        }
        public string StatusReaderOut
        {
            get { return srtStatReaderOut; }
            set { srtStatReaderOut = value; }
        }
        public string StatusReader
        {
            get { return strStatReader; }
            set { strStatReader = value; }
        }

        public ClassSnmpAgent()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //
            // init
            //
            this.snmpagent = new nsoftware.IPWorksSNMP.Snmpagent(this.components);
            // 
            // snmpagent
            // 
            this.snmpagent.About = "IPWorks SNMP 2020 [Build 7721]";
            this.snmpagent.InvokeThrough = null;
            //this.snmpagent.OnBadPacket += new nsoftware.IPWorksSNMP.Snmpagent.OnBadPacketHandler(this.snmpagent_OnBadPacket);
            //this.snmpagent.OnDiscoveryRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnDiscoveryRequestHandler(this.snmpagent_OnDiscoveryRequest);
            //this.snmpagent.OnError += new nsoftware.IPWorksSNMP.Snmpagent.OnErrorHandler(this.snmpagent_OnError);
            //this.snmpagent.OnGetBulkRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetBulkRequestHandler(this.snmpagent_OnGetBulkRequest);
            this.snmpagent.OnGetNextRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagent_OnGetNextRequest);
            this.snmpagent.OnGetRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetRequestHandler(this.snmpagent_OnGetRequest);
            //this.snmpagent.OnGetUserPassword += new nsoftware.IPWorksSNMP.Snmpagent.OnGetUserPasswordHandler(this.snmpagent_OnGetUserPassword);
            //this.snmpagent.OnPacketTrace += new nsoftware.IPWorksSNMP.Snmpagent.OnPacketTraceHandler(this.snmpagent_OnPacketTrace);
            //this.snmpagent.OnReport += new nsoftware.IPWorksSNMP.Snmpagent.OnReportHandler(this.snmpagent_OnReport);
            //this.snmpagent.OnSetRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnSetRequestHandler(this.snmpagent_OnSetRequest);
        }

        //public void snmpagent_Start()
        //{
        //    try
        //    {
        //        snmpagent.Active = !snmpagent.Active;
        //        //Console.WriteLine(snmpagent.Active.ToString());
        //        Console.WriteLine("SNMP Agent is : " + snmpagent.Active.ToString());
        //    }
        //    catch (IPWorksSNMPException ex1)
        //    {
        //        if (ex1.Code == 10048)
        //        {
        //            Console.WriteLine("The component is unable to bind to port " + snmpagent.LocalPort.ToString() + ", you probably already have an agent listening there.  Stop the other agent or use a different port for this demo.");
        //        }
        //        Console.WriteLine("Exception " + ex1.Code.ToString() + ": " + ex1.Message);
        //    }
        //    snmpagent.RuntimeLicense = "314E4E4241413153554252413153554235504A39323833380000000000000000000000000000000044543435555A454400004443365343435A544E4339330000";
        //    snmpagent.LocalEngineId = "NI_JakPro_e-Tix_SNMP";
        //}

        public bool snmpagentStart()
        {
            try
            {
                snmpagent.Active = !snmpagent.Active;
                //Console.WriteLine(snmpagent.Active.ToString());
                Console.WriteLine("SNMP Agent is : " + snmpagent.Active.ToString());
                snmpagent.RuntimeLicense = "314E4E4241413153554252413153554235504A39323833380000000000000000000000000000000044543435555A454400004443365343435A544E4339330000";
                snmpagent.LocalEngineId = "NI_JakPro_e-Tix_SNMP";
                return snmpagent.Active;
            }
            catch (IPWorksSNMPException ex1)
            {
                if (ex1.Code == 10048)
                {
                    Console.WriteLine("The component is unable to bind to port " + snmpagent.LocalPort.ToString() + ", you probably already have an agent listening there.  Stop the other agent or use a different port for this demo.");
                }
                Console.WriteLine("Exception " + ex1.Code.ToString() + ": " + ex1.Message);
                return false;
            }
        }

        public void set1(string _strDeviceName, string _strStasionCode, string _strUpTime)
        {
            strDeviceName = _strDeviceName;
            strStasionCode = _strStasionCode;
            strUpTime = _strUpTime;
        }

        //public void snmpagent_OnReport(object sender, nsoftware.IPWorksSNMP.SnmpagentReportEventArgs e)
        //{
        //    Console.WriteLine("Report");
        //}

        //public void snmpagent_OnGetBulkRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetBulkRequestEventArgs e)
        //{
        //    Console.WriteLine("GetBulkRequest");
        //}

        //public void snmpagent_OnError(object sender, nsoftware.IPWorksSNMP.SnmpagentErrorEventArgs e)
        //{
        //    Console.WriteLine("Error: " + e.Description);
        //}

        //public void snmpagent_OnDiscoveryRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentDiscoveryRequestEventArgs e)
        //{
        //    Console.WriteLine("DiscoveryRequest");
        //}

        //public void snmpagent_OnBadPacket(object sender, nsoftware.IPWorksSNMP.SnmpagentBadPacketEventArgs e)
        //{
        //    Console.WriteLine("BadPacket: " + e.ErrorDescription);
        //}

        //public void snmpagent_OnPacketTrace(object sender, nsoftware.IPWorksSNMP.SnmpagentPacketTraceEventArgs e)
        //{
        //    try
        //    {
        //        switch (e.Direction)
        //        {
        //            case 1:
        //                Console.WriteLine("Packet received from: " + e.PacketAddress + ":" +
        //                    e.PacketPort); break;
        //            case 2:
        //                Console.WriteLine("Packet sent to: " + e.PacketAddress + ":" +
        //                    e.PacketPort); break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex);
        //    }

        //}

        //public void snmpagent_OnGetUserPassword(object sender, nsoftware.IPWorksSNMP.SnmpagentGetUserPasswordEventArgs e)
        //{
        //    Console.WriteLine("User: " + e.User + " password: " + e.Password + " passtype: " + e.PasswordType.ToString());
        //}

        private void snmpagent_OnGetNextRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetNextRequestEventArgs e)
        {
            Console.WriteLine("GetNextRequest");

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
                        case "1.3.6.1.2.1.1":
                        case "1.3.6.1.2.1.1.1":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].Value = "Nutech Integrasi";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1":
                        case "1.3.6.1.2.1.1.3":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].Value = "GATEKGB01";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.2":
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].Value = "KGB";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.5":
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].Value = "3141";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.2.1.1.6":
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.7":
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].Value = "1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.8":
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.9":
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].Value = "1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.10":
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].Value = "1";
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
                        case "1.3.6.1.2.1.1":
                        case "1.3.6.1.2.1.1.1":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].Value = "Nutech Integrasi";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1":
                        case "1.3.6.1.2.1.1.3":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].Value = "GATEKGB01";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.2":
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].Value = "KGB";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.5":
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].Value = "3141";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.2.1.1.6":
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.7":
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].Value = "1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.8":
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.9":
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].Value = "1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.10":
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].Value = "1";
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
                        case "1.3.6.1.2.1.1":
                        case "1.3.6.1.2.1.1.1":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].Value = "Nutech Integrasi";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1":
                        case "1.3.6.1.2.1.1.3":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].Value = "GATEKGB01";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.2":
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].Value = "KGB";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.5":
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].Value = "3141";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.2.1.1.6":
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.7":
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].Value = "1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.8":
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.9":
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].Value = "1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.10":
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].Value = "0";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].Value = "1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        default:
                            e.ErrorStatus = 2;
                            break;
                    }
                }
            }
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
                            snmpagent.Objects[i].Value = strDeviceName;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Value = strStasionCode;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Value = strUpTime;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Value = strConMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Value = strConReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Value = strConReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Value = strStatMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Value = strStatReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.4.0":
                            snmpagent.Objects[i].Value = srtStatReaderOut;
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
                            snmpagent.Objects[i].Value = strDeviceName;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Value = strStasionCode;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Value = strUpTime;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Value = strConMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Value = strConReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Value = strConReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Value = strStatMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Value = strStatReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.4.0":
                            snmpagent.Objects[i].Value = srtStatReaderOut;
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
                            snmpagent.Objects[i].Value = strDeviceName;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Value = strStasionCode;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Value = strUpTime;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Value = strConMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Value = strConReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Value = strConReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Value = strStatMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Value = strStatReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.4.0":
                            snmpagent.Objects[i].Value = srtStatReaderOut;
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
