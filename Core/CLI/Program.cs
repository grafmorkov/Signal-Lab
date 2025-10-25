using SignalLab.Core.CLI.Commands;
using SignalLab.Core.Logging;

namespace SignalLab.Core.CLI;

    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Welcome to the SignalLab Core!");
                Console.ResetColor();
                Console.WriteLine("0 - Generate a signal\n1 - Exit");

                var number = int.Parse(Console.ReadLine() ?? "1",System.Globalization.CultureInfo.InvariantCulture);

                if (number == 0)
                {
                    GenerateSignalCommand.GenerateSignal();
                }
                else  if (number == 1)
                {
                    Console.WriteLine("Bye bye!");
                }
                else
                {
                    logger.Log("Wrong input, Restart core!", LogType.Error);
                }
            }
            catch (Exception e)
            {
                logger.Log(e.Message, LogType.Error);
                throw;
            }
        }
    }