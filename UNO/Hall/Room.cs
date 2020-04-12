using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNO.Common;

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
    }
}
