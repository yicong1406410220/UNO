using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNO.DB;
using UNO.Net;
using WebSocketSharp.Server;

namespace UNO
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!DbManager.Connect("wuziqi", "127.0.0.1", 3306, "root", ""))
            {
                return;
            }
            NetManager.Start(8888);

        }
    }
}
