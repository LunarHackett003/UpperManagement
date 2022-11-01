using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Eclipse.Dungeon
{
    public class RoomBehaviour : MonoBehaviour
    {
        //0 - up, 1 - down, 2 - right, 3 - left
        [Tooltip("0 - up, 1 - down, 2 - right, 3 - left")]
        public GameObject[] walls;
        [Tooltip("0 - up, 1 - down, 2 - right, 3 - left")]
        public GameObject[] doors;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void UpdateRoom(bool[] status)
        {
            for (int i = 0; i < status.Length; i++)
            {
                doors[i].SetActive(status[i]);
                walls[i].SetActive(!status[i]);
            }
        }
    }
}