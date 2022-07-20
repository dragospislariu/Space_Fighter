using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject player;
    public bool gameOver = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        if (!player)
        {
            gameOver = true;
            SceneManager.LoadScene(2);
            Debug.Log("Game is over!!");
        }
    }
}
