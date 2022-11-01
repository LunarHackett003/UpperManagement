using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eclipse.Dungeon
{
    [CreateAssetMenu(fileName = "Default Dungeon List", menuName = "Dungeons!/Dungeon Room List")]
    public class RoomListScriptObj : ScriptableObject
    {
        public List<RoomScriptableObject> RoomList;
    }
}