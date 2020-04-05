using NLog;

namespace Arduino_IR_Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Program started");

            Controller controller = new Controller();
            controller.ReadData();
        }
    }
}
