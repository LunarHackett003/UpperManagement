using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomGenerator : MonoBehaviour
{




    [SerializeField]
    private Transform FirstRoomStartPoint;


    [SerializeField]
    private MainRoomScriptableObject smallRooms, medRooms, largeRooms;

    [SerializeField]
    private bool smallFlag, medFlag, largeFlag;

    [SerializeField]
    private List<GameObject> smallRoomList, medRoomList, largeRoomList;

    public List<Room> rooms;

    [SerializeField]
    private int roomNumbers;

    private Transform nextRoomPos, lastRoomPos;


    [SerializeField]
    private int ranRoomInt;
    public Slider counterSlider;
    public TextMeshProUGUI roomCounter;

    public void Start()
    {
        if(smallRooms != null)
        {
            if(smallRooms.roomObject.Count != 0)
            {
                smallRoomList.AddRange(smallRooms.roomObject);
                smallFlag = true;
            }
            else
            {
                LogEmpty(smallRooms);
            }
        }
        else
        {
            LogEmpty(smallRooms);
        }        
        if(medRooms != null)
        {
            if(medRooms.roomObject.Count != 0)
            {
                medRoomList.AddRange(smallRooms.roomObject);
                medFlag = true;
            }
            else
            {
                LogEmpty(medRooms);
            }
        }
        else
        {
            LogEmpty(medRooms);
        }
        if (largeRooms != null)
        {
            if(largeRooms.roomObject.Count != 0)
            {
                largeRoomList.AddRange(largeRooms.roomObject);
                largeFlag = true;
            }
            else
            {
                LogEmpty(largeRooms);
            }
        }
        else
        {
            LogEmpty(largeRooms);
        }


        lastRoomPos = FirstRoomStartPoint;



    }

    public void WorldGeneration()
    {
        int roomSize;

        if (GameObject.FindObjectOfType<Room>() != null)
        {
            DestroyRooms();
        }

        

        for (int i = 0; i < roomNumbers; i++)
        {
            Random.InitState(System.DateTime.Now.Millisecond);

            roomSize = Random.Range(0, 2);

            switch (roomSize)
            {
                case (0):
                    RoomCreation(smallRooms);
                    break;

                case (1):
                    RoomCreation(medRooms);
                    break;

                case (2):
                    RoomCreation(largeRooms);
                    break;

                default:
                    Debug.Log("No rooms being made? Check your code!");
                    break;
            }



        }



    }


    public void DestroyRooms()
    {

        Debug.Log("Destroying Current Rooms!");
        

        rooms.AddRange(GameObject.FindObjectsOfType<Room>());

        if (rooms.Count > 0)
        {

            for (int i = 0; i < rooms.Count; i++)
            {
                Destroy(rooms[i].gameObject);

            }
        }

        
    }

    public void RoomCreation(MainRoomScriptableObject roomCollection)
    {
        Transform roomPoint;

        GameObject nextRoom;
        GameObject managedRoom;


        int roomIndex;

        roomIndex = Random.Range(0, roomCollection.roomObject.Count);


        if (GameObject.FindObjectsOfType<Room>() == null)
        {

            Debug.Log("Generating Room! Standby!");
            roomPoint = lastRoomPos;

            roomIndex = Random.Range(0, roomNumbers);

            nextRoom = roomCollection.roomObject[roomIndex];

            managedRoom = Instantiate(nextRoom);
            managedRoom.transform.position = managedRoom.GetComponent<Room>().lastRoomPoint.localPosition + lastRoomPos.position;

            roomPoint = managedRoom.GetComponent<Room>().nextRoomPoint;

        }


    }

    public void LogEmpty(Object emptyObj)
    {
        Debug.LogWarning($"{emptyObj} is either empty or null. Check references.");
    }


    public void UpdateRoomCounter(float value)
    {


        roomNumbers = (int)counterSlider.value;
        value = roomNumbers;


        roomCounter.text = $"Rooms:" +
            $"{value}";
    }
}
