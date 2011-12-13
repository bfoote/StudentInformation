using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformation.OB
{
    public enum AddressType : byte
    {
        Permanent,
        Local
    }

    public class CAddress
    {
        AddressType _AddressType;

        public AddressType AddressType
        {
            get { return _AddressType; }
            set { _AddressType = value; }
        }

        string _sStAddress;

        public string StAddress
        {
            get { return _sStAddress; }
            set { _sStAddress = value; }
        }
        string _sCity;

        public string City
        {
            get { return _sCity; }
            set { _sCity = value; }
        }
        string _sState;

        public string State
        {
            get { return _sState; }
            set { _sState = value; }
        }
        string _sZIP;

        public string ZIP
        {
            get { return _sZIP; }
            set { _sZIP = value; }
        }
    }
}
