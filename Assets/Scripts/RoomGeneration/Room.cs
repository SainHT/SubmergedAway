using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] floorTiles;
    [SerializeField] private GameObject[] leftWallTiles;
    [SerializeField] private GameObject[] rightWallTiles;
    [SerializeField] private GameObject[] topWallTiles;
    [SerializeField] private GameObject[] floorColiders;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private int maxRooms;
    private GameObject[] tiles;
    int initPriority = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDungeon();
    }

    private void GenerateDungeon(){
        initPriority = (maxRooms * 2) * 30;

        int randRoomWidth = Random.Range(10, 16);
        int randRoomHeight = Random.Range(10, 16);
        bool goRight = Random.Range(0, 2) >= .5f; //True = Right | False = Left
        int conect = 0;
        if(goRight) conect = 2;
        else conect = 1;
        GenerateRoom(0, 0, randRoomWidth, randRoomHeight, conect, initPriority);

        int corridorLength = 7;
        if (goRight){
            GenerateRoom((corridorLength - 16) *.3f, (corridorLength - 6) * .15f, 3, 5, 0, initPriority - 25);
        }
        else{
            GenerateRoom((corridorLength +  3) *.3f, (corridorLength - 7) * .15f, 5, 3, 0, initPriority - 25);
        }
        
        int roomOffsetX = 0;
        int roomOffsetY = 0;
        
        int count_priority = 2;
        int goFrom = 0;
        for (int i = 0; i < maxRooms; i++){
            randRoomWidth = Random.Range(10, 16);
            randRoomHeight = Random.Range(10, 16);

            if (goRight){
                roomOffsetX += -randRoomHeight - 9;
                roomOffsetY += randRoomHeight + 1;
                goFrom = 1;
            }
            else{
                roomOffsetX += randRoomWidth + 10;
                roomOffsetY += randRoomWidth;
                goFrom = 2;
            }
            
            goRight = Random.Range(0, 2) >= .5f; //True = Right | False = Left
            if(goRight) conect = 2;
            else conect = 1;

            if (goRight){
                GenerateRoom(.3f * roomOffsetX, .15f * roomOffsetY, randRoomWidth, randRoomHeight, conect, initPriority - 25 * count_priority, goFrom);
                count_priority++;
                GenerateRoom((corridorLength - 16 + roomOffsetX) *.3f, (corridorLength - 6 + roomOffsetY) * .15f, 3, 5, 0, initPriority - 25 * count_priority);
            }
            else{
                GenerateRoom(.3f * roomOffsetX, .15f * roomOffsetY, randRoomWidth, randRoomHeight, conect, initPriority - 25 * count_priority, goFrom);
                count_priority++;
                GenerateRoom((corridorLength + 3 + roomOffsetX) *.3f, (corridorLength - 7 + roomOffsetY) * .15f, 5, 3, 0, initPriority - 25 * count_priority);
            }
            count_priority++;
        }

        randRoomWidth = Random.Range(10, 16);
        randRoomHeight = Random.Range(10, 16);

        if (goRight){
            roomOffsetX += -randRoomHeight - 9;
            roomOffsetY += randRoomHeight + 1;
            goFrom = 1;
        }
        else{
            roomOffsetX += randRoomWidth + 10;
            roomOffsetY += randRoomWidth;
            goFrom = 2;
        }

        GenerateRoom(.3f * roomOffsetX, .15f * roomOffsetY, randRoomWidth, randRoomHeight, 0, initPriority - 25 * count_priority, goFrom);
    }

    private void GenerateRoom(float xPos, float yPos, int roomWidth, int roomHeight, int connector, int prioring, int connectorFrom = 0){ //connector 0 = None | 1 = Right | 2 = Left ; connectorFrom 0 = None | 1 = Right | 2 = Left
        //print($"Generating room with width: {roomWidth} and height: {roomHeight}");

        GameObject parent = new GameObject("TilesParent");
        parent.transform.SetParent(transform);

        int priority = prioring;
        for (int x = 0; x < roomHeight; x++) {
            for (int y = 0; y < roomWidth; y++) {
                tiles = floorTiles;
                float fixWalls = 0;
                priority ++;

                if (x == 0 && y == 0){
                    if(roomHeight == 3){
                        tiles = leftWallTiles;
                    }
                    else if (roomWidth == 3){
                        tiles = rightWallTiles;
                    }
                    else{
                        tiles = topWallTiles;
                    }
                    fixWalls = .27f;
                }
                else if (x == 0 && roomWidth != 3) {
                    if (!(connector == 2 && y > 3 && y < 7)){
                        tiles = leftWallTiles;
                        fixWalls = .27f;
                    }
                }
                else if (y == 0 && roomHeight != 3){
                    if (!(connector == 1 &&  x > 4 && x < 8)){
                        tiles = rightWallTiles;
                        fixWalls = .27f;
                    }
                }

                int randomIndex = Random.Range(0, tiles.Length);
                //int randomIndex = 0;
                GameObject tile = Instantiate(tiles[randomIndex], new Vector3(xPos + .3f * (x - y), yPos - 0.15f * (x + y) + fixWalls, 0), Quaternion.identity);
                tile.GetComponent<SpriteRenderer>().sortingOrder = priority;
                tile.transform.SetParent(parent.transform);

                //add enemy spawnpoint to the room
                if (x == (int)(roomHeight) / 2 && y == (int)(roomWidth / 2) && roomHeight != 3 && roomWidth != 3 && connector != 0 && connectorFrom != 0){
                    GameObject enemy = Instantiate(enemySpawner, new Vector3(xPos + .3f * (x - y), yPos - 0.15f * (x + y), 0), Quaternion.Euler(60f, 0f, 45f));
                    enemy.GetComponent<BoxCollider2D>().size = new Vector2(roomWidth * .3f , roomHeight * .3f);
                    enemy.transform.SetParent(parent.transform);
                }

                if (x == roomHeight - 1 && ((roomWidth != 3) && !(connectorFrom == 1 && y > -1 && y < 3))){
                    GameObject collider = Instantiate(floorColiders[0], new Vector3(xPos + .3f * (x - y) + .227f, yPos - 0.15f * (x + y) - .491f, .089f), Quaternion.identity);
                    collider.transform.Rotate(-8.949f, -57.388f, 15.948f);
                    collider.transform.SetParent(tile.transform);
                }
                
                if (y == roomWidth - 1 && (roomHeight != 3) && !(connectorFrom == 2 && x > -1 && x < 3)){
                    GameObject collider = Instantiate(floorColiders[1], new Vector3(xPos + .3f * (x - y) - .225f, yPos - 0.15f * (x + y) - .473f, .287f), Quaternion.identity);
                    collider.transform.Rotate(13.502f, -126.343f, 17.556f);
                    collider.transform.SetParent(tile.transform);
                }
            }
            priority = x + 1 + prioring;
        }
    }
}
