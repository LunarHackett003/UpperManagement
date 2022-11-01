using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eclipse.Dungeon {
    [CreateAssetMenu(fileName = "Default Dungeon Room", menuName = "Dungeons!/Dungeon Room")]
    public class RoomScriptableObject : ScriptableObject
    {
        public DungeonGenerator.Rule RoomAndRule;
    }


}