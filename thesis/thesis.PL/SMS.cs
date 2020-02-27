using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.PL
{
    public class SMS
    {

        static SerialPort port;


        public bool SendSMS(string textsms, string telnumber)
        {
            port = new SerialPort();
            OpenPort();

            if (!port.IsOpen) return false;

            try
            {
                System.Threading.Thread.Sleep(500);
                port.WriteLine("AT\r\n");
                System.Threading.Thread.Sleep(500);

                port.Write("AT+CMGF=1\r\n");
                System.Threading.Thread.Sleep(500);
            }
            catch
            {
                return false;
            }

            try
            {
                port.Write("AT+CMGS=\"" + telnumber + "\"" + "\r\n");
                System.Threading.Thread.Sleep(500);

                port.Write(textsms + char.ConvertFromUtf32(26) + "\r\n");
                System.Threading.Thread.Sleep(500);
            }
            catch
            {
                return false;
            }

            try
            {
                string recievedData;
                recievedData = port.ReadExisting();

                if (recievedData.Contains("ERROR"))
                {
                    return false;
                }

            }
            catch { }

            port.Close();

            return true;


            
        }

        private static void OpenPort()
        {

            port.BaudRate = 2400;
            port.DataBits = 7;

            port.StopBits = StopBits.One;
            port.Parity = Parity.Odd;

            port.ReadTimeout = 500;
            port.WriteTimeout = 500;


            port.Encoding = Encoding.GetEncoding("windows-1251");

            port.PortName = EL.Transactions.Initialization.port;


            if (port.IsOpen)
                port.Close();
            try
            {
                port.Open();
            }
            catch { }

        }
    }
}
