using System;
using System.Text;
using System.Collections;
using System.Linq;



namespace CP_Simulator_TCP_IP
{
    partial class Program
    {
        class Carpark
        {
            public enum TerminalTypes
            {
                SupportTerminal,
                ComplementaryTerminal
            }

            public Carpark() // Terminaltypes
            {

            }

            public byte[] GetNormalFare() // Combine with complementary or separate?
            {
                // For now the reply for both support terminal and complementary terminal
                // is the same.
                int[] randAmountsInCents = new int[]
                {1000, 150, 250, 500, 10000, 15000, 5000, 1500, 300, 450,
                    1250, 350, 900, 600, 1300, 2500, 7000, 50000, 4500, 3000};
                Random rand = new Random();
                int min = 0;
                int max = 20;
                int randAmountRange = rand.Next(min, max - 1);
                int randAmountSelected = randAmountsInCents[randAmountRange];
                string status = string.Empty;
                string sysTime = Utils.GetSystemTime();

                status += Commands.successStatus;
                status += Encoding.ASCII.GetString(Utils.Int2BCD(randAmountSelected, 4));
                status += Encoding.ASCII.GetString(Utils.Str2BCD(sysTime));
                status += Commands.carriageReturn;

                Console.WriteLine("\n\nGet Fare >>");
                return Utils.Str2Byte(status);
            }
            public byte[] GetComplementaryFare() // Combine with complementary or separate?
            {
                // For now the reply for both support terminal and complementary terminal
                // is the same.
                int[] randAmounts = new int[]
                {5000, 10000};
                Console.WriteLine("\n\n<< Get Fare >>");
                Random rand = new Random();
                int min = 0;
                int max = 2;
                int randAmount = rand.Next(min, max - 1);
                string status = null;

                status += Commands.successStatus;
                status += Encoding.ASCII.GetString(Utils.Int2BCD(randAmounts[randAmount], 4));
                status += Commands.carriageReturn;

                return Encoding.ASCII.GetBytes(status);
            }
            public byte[] OpenGate2_0(string data)
            {
                Console.WriteLine("\n\nOpen Gate >>");
                // For now, just return success
                return Encoding.ASCII.GetBytes(Commands.successStatusFull);
            }
            public void ShowData(byte[] value)
            {
                string temp = BitConverter.ToString(value);
                temp = temp.Replace("-", string.Empty);
                Console.WriteLine("{0}", temp);
            }
        }
    }
}
