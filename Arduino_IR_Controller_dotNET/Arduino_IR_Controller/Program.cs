using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arduino_IR_Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.ReadData();
        }
    }
}
