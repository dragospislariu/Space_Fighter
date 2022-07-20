using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private MainManager mainManager;
    public float speed = 5;
    public float zDestroy = -10;
    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (mainManager.gameOver == false)
        {
            transform.Translate(Vector3.forward * (-speed) * Time.deltaTime);
        }
           
        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }

    }
    
}
