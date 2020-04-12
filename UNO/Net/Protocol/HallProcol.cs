using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNO.Common;

namespace UNO.Net.Protocol
{
    //获得登录数据
    class GetHallLogin_C_Protocol : ProtocolBase
    {
        public GetHallLogin_C_Protocol()
        {
            protocolName = "GetHallLogin_C_Protocol";
        }
        public PlayerData playerData;
    }

    //获得登录数据回应
    class GetHallLogin_S_Protocol : ProtocolBase
    {
        public GetHallLogin_S_Protocol()
        {
            protocolName = "GetHallLogin_S_Protocol";
        }
        //(0-成功,1-失败)
        public int flag;
        public string msgtext;
    }

    //获得房间数据
    class GetRoomList_C_Protocol : ProtocolBase
    {
        public GetRoomList_C_Protocol()
        {
            protocolName = "GetRoomList_C_Protocol";
        }
    }

    //回应房间数据
    class GetRoomListACK_S_Protocol : ProtocolBase
    {
        public GetRoomListACK_S_Protocol()
        {
            protocolName = "GetRoomListACK_S_Protocol";
        }
    }

}

