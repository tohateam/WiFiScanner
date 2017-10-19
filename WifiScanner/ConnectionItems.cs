using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiScanner
{
    public class ConnectionItems
    {
        public ConnectionItems()
        { }

        public ConnectionItems(string ssid, string quality, int chanel)
        {
            SsId = ssid;
            Quality = quality;
            Chanel = chanel;
        }

        public string SsId { get; set; }

        public string Quality { get; set; }

        public int Chanel { get; set; }
    }
}