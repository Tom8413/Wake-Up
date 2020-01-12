using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CheckPoint;
    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    public void RespawnPlayer()
    {
        Player.transform.position = CheckPoint.transform.position;
    }

   
}
