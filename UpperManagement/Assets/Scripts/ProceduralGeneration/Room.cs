using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform lastRoomPoint;
    public Transform nextRoomPoint;


    public List<Transform> spawnPoints;

    public enum _RoomSize
    {
        small,
        medium,
        large
    }

    public _RoomSize roomSize;
}
