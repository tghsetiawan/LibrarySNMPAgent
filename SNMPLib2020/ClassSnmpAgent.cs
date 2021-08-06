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
        //private nsoftware.IPWorksSNMP.Snmpagent snmpagentGate = new Snmpagent();
        //private nsoftware.IPWorksSNMP.Snmpagent snmpagentPos = new Snmpagent();
        private System.ComponentModel.IContainer components;

        private Gate gateDevice = new Gate();
        private Pos posDevice = new Pos();
        private Vending vendingDevice = new Vending();
        private AcPos acPosDevice = new AcPos();

        private string strDeviceName, strStasionCode, strUpTime;
        private string strConMbc, strConReaderIn, strConReaderOut, strConReader, strStatMbc, strStatReaderIn, srtStatReaderOut, strStatReader;
        private string strEpcStatus, strDbStatus, strOnlineStatus, strQrsInStatus, strQrsOutStatus, strReaderInStatus, strReaderOutStatus, strControllerStatus;

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
            this.snmpagent.OnBadPacket += new nsoftware.IPWorksSNMP.Snmpagent.OnBadPacketHandler(this.snmpagent_OnBadPacket);
            //this.snmpagent.OnDiscoveryRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnDiscoveryRequestHandler(this.snmpagent_OnDiscoveryRequest);
            this.snmpagent.OnError += new nsoftware.IPWorksSNMP.Snmpagent.OnErrorHandler(this.snmpagent_OnError);
            //this.snmpagent.OnGetBulkRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetBulkRequestHandler(this.snmpagent_OnGetBulkRequest);
            //this.snmpagent.OnGetNextRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagent_OnGetNextRequest);
            this.snmpagent.OnGetRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetRequestHandler(this.snmpagent_OnGetRequest);
            //this.snmpagent.OnGetUserPassword += new nsoftware.IPWorksSNMP.Snmpagent.OnGetUserPasswordHandler(this.snmpagent_OnGetUserPassword);
            this.snmpagent.OnPacketTrace += new nsoftware.IPWorksSNMP.Snmpagent.OnPacketTraceHandler(this.snmpagent_OnPacketTrace);
            //this.snmpagent.OnReport += new nsoftware.IPWorksSNMP.Snmpagent.OnReportHandler(this.snmpagent_OnReport);
            //this.snmpagent.OnSetRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnSetRequestHandler(this.snmpagent_OnSetRequest);

            #region Gate

            #endregion

            #region Pos

            #endregion

            #region Vending

            #endregion

            #region AcPos

            #endregion
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

        //public bool snmpagentGateStart()
        //{
        //    try
        //    {
        //        snmpagentGate.Active = !snmpagentGate.Active;
        //        Console.WriteLine("SNMP Agent is : " + snmpagentGate.Active.ToString());
        //        snmpagentGate.RuntimeLicense = "314E4E4241413153554252413153554235504A39323833380000000000000000000000000000000044543435555A454400004443365343435A544E4339330000";
        //        snmpagentGate.LocalEngineId = "NI_JakPro_e-Tix_SNMP";
        //        return snmpagentGate.Active;
        //    }
        //    catch (IPWorksSNMPException ex1)
        //    {
        //        if (ex1.Code == 10048)
        //        {
        //            Console.WriteLine("The component is unable to bind to port " + snmpagentGate.LocalPort.ToString() + ", you probably already have an agent listening there.  Stop the other agent or use a different port for this demo.");
        //        }
        //        Console.WriteLine("Exception " + ex1.Code.ToString() + ": " + ex1.Message);
        //        return false;
        //    }
        //}

        //public void set1(string _strDeviceName, string _strStasionCode, string _strUpTime)
        //{
        //    DeviceName = _strDeviceName;
        //    StasionCode = _strStasionCode;
        //    UpTime = _strUpTime;
        //}

        //public void set2(string _strConMbc, string _strConReaderIn, string _strConReaderOut, string _strConReader)
        //{
        //    ConnectionMbc = _strConMbc;
        //    ConnectionReaderIn = _strConReaderIn;
        //    ConnectionReaderOut = _strConReaderOut;
        //    ConnectionReader = _strConReader;
        //}

        //public void set3(string _strStatMbc, string _strStatReaderIn, string _strStatReaderOut, string _strStatReader)
        //{
        //    StatusMbc = _strStatMbc;
        //    StatusReaderIn = _strStatReaderIn;
        //    StatusReaderOut = _strStatReaderOut;
        //    StatusReader = _strStatReader;
        //}

        //public void setAll(string _strDeviceName, string _strStasionCode, string _strUpTime, string _strConMbc, string _strConReaderIn, string _strConReaderOut, string _strConReader, string _strStatMbc, string _strStatReaderIn, string _strStatReaderOut, string _strStatReader)
        //{
        //    DeviceName = _strDeviceName;
        //    StasionCode = _strStasionCode;
        //    UpTime = _strUpTime;

        //    ConnectionMbc = _strConMbc;
        //    ConnectionReaderIn = _strConReaderIn;
        //    ConnectionReaderOut = _strConReaderOut;
        //    ConnectionReader = _strConReader;

        //    StatusMbc = _strStatMbc;
        //    StatusReaderIn = _strStatReaderIn;
        //    StatusReaderOut = _strStatReaderOut;
        //    StatusReader = _strStatReader;
        //}

        private void resetOnGetNextRequest(string device)
        {
            switch (device)
            {
                case "Gate":
                    snmpagent.OnGetNextRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentGate_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentPos_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentVending_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentAcPos_OnGetNextRequest);
                    break;
                case "Pos":
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentGate_OnGetNextRequest);
                    snmpagent.OnGetNextRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentPos_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentVending_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentAcPos_OnGetNextRequest);
                    break;
                case "Vending":
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentGate_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentPos_OnGetNextRequest);
                    snmpagent.OnGetNextRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentVending_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentAcPos_OnGetNextRequest);
                    break;
                case "AcPos":
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentGate_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentPos_OnGetNextRequest);
                    snmpagent.OnGetNextRequest -= new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentVending_OnGetNextRequest);
                    snmpagent.OnGetNextRequest += new nsoftware.IPWorksSNMP.Snmpagent.OnGetNextRequestHandler(this.snmpagentAcPos_OnGetNextRequest);
                    break;
                default:
                    break;
            }
        }

        public void setVarGate(string _strDeviceName, string _strStasionCode, string _strUpTime, string _strEpcStatus, string _strDbStatus, string _strOnlineStatus, string _strQrsInStatus, string _strQrsOutStatus, string _strReaderInStatus, string _strReaderOutStatus, string _strControllerStatus)
        {
            gateDevice.TerminalNameGate = _strDeviceName;
            gateDevice.StationCodeGate = _strStasionCode;
            gateDevice.UpTimeGate = _strUpTime;
            gateDevice.EpcStatus = _strEpcStatus;
            gateDevice.DbStatus = _strDbStatus;
            gateDevice.OnlinePaymentStatus = _strOnlineStatus;
            gateDevice.QrsInStatus = _strQrsInStatus;
            gateDevice.QrsOutStatus = _strQrsOutStatus;
            gateDevice.ReaderInStatus = _strReaderInStatus;
            gateDevice.ReaderOutStatus = _strReaderOutStatus;
            gateDevice.ControllerStatus = _strControllerStatus;
            resetOnGetNextRequest("Gate");
        }

        public void setVarPos(string _strDeviceName, string _strStasionCode, string _strUpTime, string _strEpcStatus, string _strDbStatus, string _strOnlinePaymentStatus, string _strPrinterStatus, string _strQrsStatus, string _strReaderStatus)
        {
            posDevice.TerminalNamePos = _strDeviceName;
            posDevice.StationCodePos = _strStasionCode;
            posDevice.UpTimePos = _strUpTime;
            posDevice.EpcStatus = _strEpcStatus;
            posDevice.DbStatus = _strDbStatus;
            posDevice.OnlinePaymentStatus = _strOnlinePaymentStatus;
            posDevice.PrinterStatus = _strPrinterStatus;
            posDevice.QrsStatus = _strQrsStatus;
            posDevice.ReaderStatus = _strReaderStatus;
            resetOnGetNextRequest("Pos");
        }

        public void setVarVending(string _strDeviceName, string _strStasionCode, string _strUpTime, string _strEpcStatus, string _strDbStatus, string _strOnlinePaymentStatus, string _strPrinterStatus, string _strQrsStatus, string _strReaderStatus)
        {
            vendingDevice.TerminalNameVending = _strDeviceName;
            vendingDevice.StationCodeVending = _strStasionCode;
            vendingDevice.UpTimeVending = _strUpTime;
            vendingDevice.EpcStatus = _strEpcStatus;
            vendingDevice.DbStatus = _strDbStatus;
            vendingDevice.OnlinePaymentStatus = _strOnlinePaymentStatus;
            vendingDevice.PrinterStatus = _strPrinterStatus;
            vendingDevice.QrsStatus = _strQrsStatus;
            vendingDevice.ReaderStatus = _strReaderStatus;
            resetOnGetNextRequest("Vending");
        }

        public void setVarAcPos(string _strDeviceName, string _strStasionCode, string _strUpTime, string _strEpcStatus, string _strDbStatus, string _strPrinterStatus, string _strQrsStatus, string _strReaderStatus)
        {
            acPosDevice.TerminalNameAcPos = _strDeviceName;
            acPosDevice.StationCodeAcPos = _strStasionCode;
            acPosDevice.UpTimeAcPos = _strUpTime;
            acPosDevice.EpcStatus = _strEpcStatus;
            acPosDevice.DbStatus = _strDbStatus;
            acPosDevice.PrinterStatus = _strPrinterStatus;
            acPosDevice.ReaderStatus = _strReaderStatus;
            resetOnGetNextRequest("AcPos");
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

        #region Default

        private void snmpagent_OnGetNextRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetNextRequestEventArgs e)
        {
            Console.WriteLine("GetNextRequest");

            e.Respond = true;

            if (string.IsNullOrEmpty(strStatReaderIn) || string.IsNullOrEmpty(strConReaderIn))
            {
                for (int i = 0; i < snmpagent.Objects.Count; i++)
                {
                    //set objType and objValue to send get response
                    switch (snmpagent.Objects[i].Oid)
                    {
                        case "1.3.6.1.2.1.1":
                        case "1.3.6.1.2.1.1.1":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1":
                        case "1.3.6.1.2.1.1.3":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].Value = strDeviceName;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.2":
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].Value = strStasionCode;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.5":
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].Value = strUpTime;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.2.1.1.6":
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].Value = strConMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.7":
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].Value = strConReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.8":
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].Value = strConReader;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.9":
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].Value = strStatMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.10":
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].Value = srtStatReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].Value = strStatReader;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        default:
                            e.ErrorStatus = 2;
                            break;
                    }
                }
            }
            else if (string.IsNullOrEmpty(strConReaderOut) || string.IsNullOrEmpty(srtStatReaderOut))
            {
                for (int i = 0; i < snmpagent.Objects.Count; i++)
                {
                    //set objType and objValue to send get response
                    switch (snmpagent.Objects[i].Oid)
                    {
                        case "1.3.6.1.2.1.1":
                        case "1.3.6.1.2.1.1.1":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1":
                        case "1.3.6.1.2.1.1.3":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].Value = strDeviceName;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.4":
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].Value = strStasionCode;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.5":
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].Value = strUpTime;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.2.1.1.6":
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].Value = strConMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.7":
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.2.0";
                            snmpagent.Objects[i].Value = strConReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.8":
                        case "1.3.6.1.4.1.17.1.4.1.4.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].Value = strConReader;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.9":
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].Value = strStatMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.10":
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.2.0";
                            snmpagent.Objects[i].Value = strStatReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].Value = strStatReader;
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
                            snmpagent.Objects[i].Value = "1.3.6.1.4.1.17.1";
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.4.1.17.1":
                        case "1.3.6.1.2.1.1.3":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                            snmpagent.Objects[i].Value = strDeviceName;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.4":
                        case "1.3.6.1.4.1.17.1.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                            snmpagent.Objects[i].Value = strStasionCode;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                        case "1.3.6.1.2.1.1.5":
                        case "1.3.6.1.4.1.17.1.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                            snmpagent.Objects[i].Value = strUpTime;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                        case "1.3.6.1.2.1.1.11":
                        case "1.3.6.1.4.1.17.1.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.1.0";
                            snmpagent.Objects[i].Value = strConMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.12":
                        case "1.3.6.1.4.1.17.1.4.1.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.2.0";
                            snmpagent.Objects[i].Value = strConReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.13":
                        case "1.3.6.1.4.1.17.1.4.1.4.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.3.0";
                            snmpagent.Objects[i].Value = strConReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.14":
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.4.0";
                            snmpagent.Objects[i].Value = strConReader;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.15":
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.1.0";
                            snmpagent.Objects[i].Value = strStatMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.16":
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.2.0";
                            snmpagent.Objects[i].Value = strStatReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.2.1.1.17":
                        case "1.3.6.1.4.1.17.1.4.2.4.2.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.3.0";
                            snmpagent.Objects[i].Value = srtStatReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.4.0";
                            snmpagent.Objects[i].Value = strStatReader;
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

            if (string.IsNullOrEmpty(strConReaderIn) || string.IsNullOrEmpty(strStatReaderIn))
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
            else if (string.IsNullOrEmpty(strConReaderOut) || string.IsNullOrEmpty(srtStatReaderOut))
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
                        case "1.3.6.1.4.1.17.1.4.1.4.2.0":
                            snmpagent.Objects[i].Value = strConReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.3.0":
                            snmpagent.Objects[i].Value = strConReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.1.4.4.0":
                            snmpagent.Objects[i].Value = strConReader;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.1.0":
                            snmpagent.Objects[i].Value = strStatMbc;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.2.0":
                            snmpagent.Objects[i].Value = strStatReaderIn;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.3.0":
                            snmpagent.Objects[i].Value = srtStatReaderOut;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        case "1.3.6.1.4.1.17.1.4.2.4.4.0":
                            snmpagent.Objects[i].Value = strStatReader;
                            snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                        default:
                            e.ErrorStatus = 2;
                            break;
                    }
                }
            }
        }

        private void snmpagent_OnPacketTrace(object sender, nsoftware.IPWorksSNMP.SnmpagentPacketTraceEventArgs e)
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

        private void snmpagent_OnBadPacket(object sender, nsoftware.IPWorksSNMP.SnmpagentBadPacketEventArgs e)
        {
            Console.WriteLine("BadPacket: " + e.ErrorDescription);
        }

        private void snmpagent_OnError(object sender, nsoftware.IPWorksSNMP.SnmpagentErrorEventArgs e)
        {
            Console.WriteLine("Error: " + e.Description);
        }

        #endregion

        #region Gate
        private void snmpagentGate_OnGetNextRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetNextRequestEventArgs e)
        {
            Console.WriteLine("GetNextRequest");

            e.Respond = true;

            for (int i = 0; i < snmpagent.Objects.Count; i++)
            {
                //set objType and objValue to send get response
                switch (snmpagent.Objects[i].Oid)
                {
                    case "1.3.6.1.4.1.17.1":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                        snmpagent.Objects[i].Value = gateDevice.TerminalNameGate;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                    case "1.3.6.1.4.1.17.1.1.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                        snmpagent.Objects[i].Value = gateDevice.StationCodeGate;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                    case "1.3.6.1.4.1.17.1.2.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                        snmpagent.Objects[i].Value = gateDevice.UpTimeGate;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                    case "1.3.6.1.4.1.17.1.3.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.1.0";
                        snmpagent.Objects[i].Value = gateDevice.EpcStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.1.1.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.2.0";
                        snmpagent.Objects[i].Value = gateDevice.DbStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.1.2.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.3.0";
                        snmpagent.Objects[i].Value = gateDevice.OnlinePaymentStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.1.3.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.4.0";
                        snmpagent.Objects[i].Value = gateDevice.QrsInStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.1.4.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.5.0";
                        snmpagent.Objects[i].Value = gateDevice.QrsOutStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.1.5.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.6.0";
                        snmpagent.Objects[i].Value = gateDevice.ReaderInStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.1.6.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.7.0";
                        snmpagent.Objects[i].Value = gateDevice.ReaderOutStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.1.7.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.1.8.0";
                        snmpagent.Objects[i].Value = gateDevice.ControllerStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    default:
                        e.ErrorStatus = 2;
                        break;
                }
            }
        }
        #endregion

        #region Pos
        private void snmpagentPos_OnGetNextRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetNextRequestEventArgs e)
        {
            Console.WriteLine("GetNextRequest");

            e.Respond = true;

            for (int i = 0; i < snmpagent.Objects.Count; i++)
            {
                //set objType and objValue to send get response
                switch (snmpagent.Objects[i].Oid)
                {
                    case "1.3.6.1.4.1.17.1":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.1.0";
                        snmpagent.Objects[i].Value = posDevice.TerminalNamePos;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                    case "1.3.6.1.4.1.17.1.1.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.2.0";
                        snmpagent.Objects[i].Value = posDevice.StationCodePos;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otOctetString; break;
                    case "1.3.6.1.4.1.17.1.2.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.3.0";
                        snmpagent.Objects[i].Value = posDevice.UpTimePos;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otTimeTicks; break;
                    case "1.3.6.1.4.1.17.1.3.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.1.0";
                        snmpagent.Objects[i].Value = posDevice.EpcStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.2.1.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.2.0";
                        snmpagent.Objects[i].Value = posDevice.DbStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.2.2.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.3.0";
                        snmpagent.Objects[i].Value = posDevice.OnlinePaymentStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.2.3.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.4.0";
                        snmpagent.Objects[i].Value = posDevice.PrinterStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.2.4.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.5.0";
                        snmpagent.Objects[i].Value = posDevice.QrsStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    case "1.3.6.1.4.1.17.1.4.2.5.0":
                        snmpagent.Objects[i].Oid = "1.3.6.1.4.1.17.1.4.2.6.0";
                        snmpagent.Objects[i].Value = posDevice.ReaderStatus;
                        snmpagent.Objects[i].ObjectType = SNMPObjectTypes.otUnsignedInteger32; break;
                    default:
                        e.ErrorStatus = 2;
                        break;
                }
            }
        }
        #endregion

        #region Vending
        private void snmpagentVending_OnGetNextRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetNextRequestEventArgs e)
        {

        }
        #endregion

        #region AcPos
        private void snmpagentAcPos_OnGetNextRequest(object sender, nsoftware.IPWorksSNMP.SnmpagentGetNextRequestEventArgs e)
        {

        }
        #endregion
    }
}
