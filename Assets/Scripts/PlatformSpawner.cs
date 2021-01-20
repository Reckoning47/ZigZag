using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    Vector3 lastPos;
    float size;
    BallController player;
    // Start is called before the first frame update
    void Start()
    {

        lastPos = platformPrefab.transform.position;
        size = platformPrefab.transform.localScale.x;

        player = GameObject.Find("Player").GetComponent<BallController>();

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
            
        }
        // infinite mazerunner component
        InvokeRepeating("SpawnPlatforms", 2f, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            SpawnX();

        }
        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {

        Vector3 pos = lastPos;
        Instantiate(platformPrefab, pos, Quaternion.identity, this.transform);
        pos.x += size;
        lastPos = pos;
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        Instantiate(platformPrefab, pos, Quaternion.identity, this.transform);
        pos.z += size;
        lastPos = pos;
    }



}
