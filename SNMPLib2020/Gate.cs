using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNMPLib2020
{
    class Gate
    {
        public string TerminalNameGate { get; set; }
        public string StationCodeGate { get; set; }
        public string UpTimeGate { get; set; }
        public string EpcStatus { get; set; }
        public string DbStatus { get; set; }
        public string OnlinePaymentStatus { get; set; }
        public string QrsInStatus { get; set; }
        public string QrsOutStatus { get; set; }
        public string ReaderInStatus { get; set; }
        public string ReaderOutStatus { get; set; }
        public string ControllerStatus { get; set; }
    }
}
