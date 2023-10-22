using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    private Controller playerControl;

    public GameObject obstacles;

    private Vector3 spawnPOS = new Vector3(30, 0.75f, -1.75f);
    private float delayTime =2;
    private float repeatTime =2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles" , delayTime, repeatTime);
        playerControl = GameObject.Find("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacles(){
        if (playerControl.gameOver == false){
            Instantiate(obstacles, spawnPOS, obstacles.transform.rotation);

        }
    }




}
