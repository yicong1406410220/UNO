using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO.Hall
{
    class RoomManager
    {
        //房间列表
        static Dictionary<string, Room> rooms = new Dictionary<string, Room>();

		//房间是否在线
		public static bool IsOnline(string id)
		{
			if (!rooms.ContainsKey(id))
			{
				return false;
			}
			return true;
		}

		//获取房间
		public static Room GetPlayer(string id)
		{
			if (rooms.ContainsKey(id))
			{
				return rooms[id];
			}
			return null;
		}

		//添加房间
		public static void AddPlayer(string id, Room room)
		{
			rooms.Add(id, room);
		}

		//删除房间
		public static void RemovePlayer(string id)
		{
			rooms.Remove(id);
		}

	}
}
