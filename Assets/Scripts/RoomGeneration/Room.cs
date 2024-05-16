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
    private int roomWidth;
    private int roomHeight;

    private GameObject[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRoom(0, 0);
        for (int i = 0; i < 10; i++){
            float xRoom = Random.Range(-40, 40) * 0.3f;
            float yRoom = Random.Range(-40, 40) * 0.15f;
            //GenerateRoom(xRoom, yRoom);
        }
    }

    private void GenerateRoom(float xPos, float yPos){
        roomWidth = Random.Range(5, 10);
        roomHeight = Random.Range(5, 10);
        
        print($"Generating room with width: {roomWidth} and height: {roomHeight}");

        GameObject parent = new GameObject("TilesParent");
        parent.transform.SetParent(transform);

        int priority = 0;
        for (int x = 0; x < roomHeight; x++) {
            for (int y = 0; y < roomWidth; y++) {
                tiles = floorTiles;
                float fixWalls = 0;
                priority += 1;

                if (x == 0 && y == 0){
                    tiles = topWallTiles;
                    fixWalls = .27f;
                }
                else if (x == 0) {
                    tiles = leftWallTiles;
                    fixWalls = .27f;
                }
                else if (y == 0){
                    tiles = rightWallTiles;
                    fixWalls = .27f;
                }

                //int randomIndex = Random.Range(0, tiles.Length);
                int randomIndex = 0;
                GameObject tile = Instantiate(tiles[randomIndex], new Vector3(xPos + .3f * (x - y), yPos - 0.15f * (x + y) + fixWalls, 0), Quaternion.identity);
                tile.GetComponent<SpriteRenderer>().sortingOrder = priority;
                tile.transform.SetParent(parent.transform);

                if (x == roomHeight - 1 ){
                    GameObject collider = Instantiate(floorColiders[0], new Vector3(xPos + .3f * (x - y) + .227f, yPos - 0.15f * (x + y) - .491f, .089f), Quaternion.identity);
                    collider.transform.Rotate(-8.949f, -57.388f, 15.948f);
                    collider.transform.SetParent(tile.transform);
                }
                
                if (y == roomWidth - 1){
                    GameObject collider = Instantiate(floorColiders[1], new Vector3(xPos + .3f * (x - y) - .225f, yPos - 0.15f * (x + y) - .473f, .287f), Quaternion.identity);
                    collider.transform.Rotate(13.502f, -126.343f, 17.556f);
                    collider.transform.SetParent(tile.transform);
                }
            }
            //priority = x + 1;
        }
    }
}
