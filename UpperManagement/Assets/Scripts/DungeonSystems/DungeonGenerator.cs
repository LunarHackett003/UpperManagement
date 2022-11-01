using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eclipse.Dungeon
{
    public class DungeonGenerator : MonoBehaviour
    {
        [System.Serializable]
        public class Cell
        {
            public bool visited = false;
            public bool[] status = new bool[4];
        }

        [System.Serializable]
        public class Rule
        {
            public GameObject room;
            public Vector2Int minPosition, maxPosition;

            public bool essential;

            public int SpawnProbability(int x, int y)
            {
                if (x >= minPosition.x && x <= maxPosition.x && y >= minPosition.y && y <= maxPosition.y)
                {

                    //0 - no spawn, 1 - potential spawn, 2 - definite spawn
                    return essential ? 2 : 1;
                }

                return 0;
            }
        }

        public Vector2Int size;
        public int startPosition = 0;
        public RoomScriptableObject[] roomList;
        public int maxDungeonIterations;
        public Vector2Int offset;
        public List<Cell> board;
        List<GameObject> boardRooms;



        // Start is called before the first frame update
        void Start()
        {
            GenerateBoard();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Generates the physical rooms in the dungeon. Each room is a 1x1 tile and large rooms will generate purely by chance when a doorless room is generated.
        /// "Doorless" rooms are those where, rather than a door being placed there, there is an empty gameObject to fulfill the door being needed in the array.
        /// </summary>
        public void GenerateDungeon()
        {
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {

                    Cell currentCell = board[ (i + j * size.x)];
                    if (currentCell.visited)
                    {
                        int randomRoom = -1;

                        List<int> availableRooms = new List<int>();
                        for (int k = 0; k < roomList.Length; k++)
                        {
                            int p = roomList[k].RoomAndRule.SpawnProbability(i, j);

                            switch (p)
                            {
                                case 0:
                                    //Do nothing.
                                    break;

                                case 1:
                                    availableRooms.Add(k);
                                    break;

                                case 2:
                                    randomRoom = k;
                                    break;
                                default:

                                    break;
                            }

                        }

                        if(randomRoom == -1)
                        {
                            if (availableRooms.Count > 0) { randomRoom = availableRooms[Random.Range(0, availableRooms.Count)]; }
                            else { randomRoom = 0; }
                        }



                        var newRoom = Instantiate(roomList[randomRoom].RoomAndRule.room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity,transform).GetComponent<RoomBehaviour>();


                        newRoom.UpdateRoom(currentCell.status);
                        newRoom.name += $" {i}-{j}";

                        
                    }


                }
            }
        }

        /// <summary>
        /// Generates the dungeon layout. The dungeon is currently 2-Dimensional. 3D dungeons and boards will be implemented when rules are implemented.
        /// </summary>
        public void GenerateBoard()
        {

            board = new List<Cell>();

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    board.Add(new Cell()); //Creates a "board" of cells, containing the rooms of the dungeon.
                }
            }

            int currentCell = startPosition;

            Stack<int> path = new Stack<int>();

            int k = 0; //Current generation iteration

            while (k < 1000)
            {
                k++;


                board[currentCell].visited = true;


                if (currentCell == board.Count - 1)
                {
                    break;
                }

                List<int> neighbours = new List<int>();

                neighbours = CheckNeighbours(currentCell);

                if(neighbours.Count == 0)
                {
                    if(path.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        currentCell = path.Pop();
                    }
                }
                else
                {
                    path.Push(currentCell);

                    int newCell = neighbours[Random.Range(0, neighbours.Count)];

                    //Check Down or Right
                    if (newCell > currentCell)
                    {
                        //down or right
                        if (newCell - 1 == currentCell)
                        {
                            board[currentCell].status[2] = true;
                            currentCell = newCell;
                            board[currentCell].status[3] = true;
                        }
                        else
                        {
                            board[currentCell].status[1] = true;
                            currentCell = newCell;
                            board[currentCell].status[0] = true;
                        }
                    }
                    else
                    {
                        //up or left
                        if (newCell + 1 == currentCell)
                        {
                            board[currentCell].status[3] = true;
                            currentCell = newCell;
                            board[currentCell].status[2] = true;
                        }
                        else
                        {
                            board[currentCell].status[0] = true;
                            currentCell = newCell;
                            board[currentCell].status[1] = true;
                        }
                    }
                }
            }


            GenerateDungeon();
        }

        public List<int> CheckNeighbours(int cell)
        {
            List<int> neighbors = new List<int>();

            //check up neighbor
            if (cell - size.x >= 0 && !board[(cell - size.x)].visited)
            {
                neighbors.Add((cell - size.x));
            }

            //check down neighbor
            if (cell + size.x < board.Count && !board[(cell + size.x)].visited)
            {
                neighbors.Add((cell + size.x));
            }

            //check right neighbor
            if ((cell + 1) % size.x != 0 && !board[(cell + 1)].visited)
            {
                neighbors.Add((cell + 1));
            }

            //check left neighbor
            if (cell % size.x != 0 && !board[(cell - 1)].visited)
            {
                neighbors.Add((cell - 1));
            }

            return neighbors;
        }
    }
}