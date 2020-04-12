using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using UNO.Net.Protocol;

namespace UNO.Net
{
    class NetManager
    {
        public enum ServiceType
        {
            All,
            Login,
            Game,
        }
        public static void Start(int port)
        {
            WebSocketServer wssv = new WebSocketServer(port);
            wssv.AddWebSocketService<LoginWebSocketBehavior>("/Login");
            wssv.AddWebSocketService<GameWebSocketBehavior>("/Game");           
            wssv.Start();
            WebSocketServiceManager webSocketServer = wssv.WebSocketServices;
            GameSessionManager = webSocketServer["/Game"].Sessions;
            LoginSessionManager = webSocketServer["/Login"].Sessions;
        }

        static WebSocketSessionManager GameSessionManager = null;
        static WebSocketSessionManager LoginSessionManager = null;

        public static void Close(string ID, ServiceType serviceType)
        {
            if (GameSessionManager.IDs.Contains(ID) && (serviceType == ServiceType.All || serviceType == ServiceType.Game))
            {
                GameSessionManager[ID].Context.WebSocket.Close();
            }
            if (LoginSessionManager.IDs.Contains(ID) && (serviceType == ServiceType.All || serviceType == ServiceType.Login))
            {
                LoginSessionManager[ID].Context.WebSocket.Close();
            }
        }

        public static void Send(string ID, ProtocolBase obj, ServiceType serviceType)
        {
            string msg = Utils.Js.Serialize(obj);
            if (GameSessionManager.IDs.Contains(ID) && (serviceType == ServiceType.All || serviceType == ServiceType.Game))
            {
                Console.WriteLine("GameSessionSend " + ID + ":" + msg);
                GameSessionManager[ID].Context.WebSocket.Send(msg);
            }
            if (LoginSessionManager.IDs.Contains(ID) && (serviceType == ServiceType.All || serviceType == ServiceType.Login))
            {
                Console.WriteLine("GameSessionSend " + ID + ":" + msg);
                LoginSessionManager[ID].Context.WebSocket.Send(msg);
            }
        }
    }
}
