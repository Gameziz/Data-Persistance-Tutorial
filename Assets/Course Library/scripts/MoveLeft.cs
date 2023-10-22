using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private Controller ControllerScript;
    private float speed = 20f;


    private void Start()
    {
        ControllerScript = GameObject.Find("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < -6 && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }

     }




}
