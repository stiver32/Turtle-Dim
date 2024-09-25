using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement pm;


    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if (pm.moveDir.x > 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(42, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(42, 0, 0);  //Right
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-42, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-42, 0, 0);    //Left
                SpawnChunk();
            }
        }
        else if (pm.moveDir.y > 0 && pm.moveDir.x == 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, 24, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, 24, 0); //Up
                SpawnChunk();
            }
        }
        else if (pm.moveDir.y < 0 && pm.moveDir.x == 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -24, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, -24, 0);    //Down
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(42, 24, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(42, 24, 0);   //Right up
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(42, -24, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(42, -24, 0);  //Right down
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-42, 24, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-42, 24, 0);  //Left up
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-42, -24, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-42, -24, 0); //Left down
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);

    }
}