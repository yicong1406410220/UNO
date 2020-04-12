using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNO.Common;
using UNO.Net;
using UNO.Net.Protocol;

namespace UNO.Hall
{
    class Room
    {
        //玩家列表
		static Dictionary<string, Player> players = new Dictionary<string, Player>();
        static Dictionary<string, Player> Lookplayers = new Dictionary<string, Player>();

        //房间id
        public string id = "";
        //密码房
        public string pw = "";

        public RoomStatus roomStatus = RoomStatus.Ready;

        public enum RoomStatus
        {
            Ready,   //准备
            Battle,   //战斗
        }

        public enum UserType
        {
            All,
            Look,   //旁观
            Game,   //战斗
        }

        public bool Join(string id, string pw)
        {
            if (this.pw != "" && this.pw != pw)
            {
                return false;
            }
            if (roomStatus == RoomStatus.Ready)
            {
                return false;
            }
            players.Add(id, PlayerManager.GetPlayer(id));
            return true;

        }

        public bool Leave(string id)
        {
            if (players.ContainsKey(id))
            {
                players.Remove(id);
                return true;
            }
            if (Lookplayers.ContainsKey(id))
            {
                Lookplayers.Remove(id);
                return true;
            }
            return false;
        }
        public void Send(ProtocolBase obj, UserType userType)
        {
            if(userType == UserType.All || userType == UserType.Game)
            {
                foreach (KeyValuePair<string, Player> item in players)
                {
                    item.Value.Send(obj);
                }
            }
            if (userType == UserType.All || userType == UserType.Look)
            {
                foreach (KeyValuePair<string, Player> item in Lookplayers)
                {
                    item.Value.Send(obj);
                }
            }
        }
    }
}
