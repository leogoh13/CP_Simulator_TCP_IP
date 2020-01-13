using System;
using System.Text;


namespace CP_Simulator_TCP_IP
{
    static class Utils
    {
        public static byte[] Int2BCD(int number, int bcdByteLen)
        {
            string numberString = number.ToString().PadLeft(bcdByteLen * 2, '0');
            byte[] numberBCD = new byte[bcdByteLen];
            byte[] temp = null;

            for (int i = 0; i < bcdByteLen; i++)
            {
                string oneByte = numberString.Substring(i * 2, 2);
                int high = (int.Parse(oneByte[0].ToString()) << 4);
                high = high + 15;
                int low = int.Parse(oneByte[1].ToString());
                low = low + 240;

                int BCDformat = high & low;
                temp = BitConverter.GetBytes(BCDformat);
                numberBCD[i] = temp[0];
            }
            return numberBCD;
        }
        public static string Hex2Ascii(string hexStr)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexStr.Length; i += 2)
                {
                    string hs = string.Empty;

                    hs = hexStr.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }
        public static string Ascii2Hex(byte[] asciiStr)
        {
            try
            {
                string temp = BitConverter.ToString(asciiStr);
                temp.Replace('-', '\x00');
                return BitConverter.ToString(asciiStr);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }

            return string.Empty;
        }
        public static byte[] Str2Byte(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
        public static string Byte2StrAscii(byte[] value)
        {
            return Encoding.ASCII.GetString(value);
        }
        public static string GetSystemTime()
        {
            string systime = DateTime.Now.ToString("yyMMddhhmmss");
            return systime;
        }
        public static byte[] Str2BCD(string value)
        {
            var bcd = new byte[value.Length / 2];
            for (var i = 0; i < bcd.Length; i++)
            {
                bcd[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
            }
            return bcd;
        }
        public static string BCD2Str(byte[] bcd)
        {
            return Encoding.ASCII.GetString(bcd);
        }
        public static string Byte2StrHex(byte[] value)
        {
            string temp = BitConverter.ToString(value);
            temp = temp.Replace("-", string.Empty);
            int lenOfEOF = temp.LastIndexOf("0D") + 2;
            return temp.Substring(0, lenOfEOF);
        }
    }
}
