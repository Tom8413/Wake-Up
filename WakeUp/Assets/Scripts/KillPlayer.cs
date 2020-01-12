using System.Collections;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            levelManager.RespawnPlayer();
        }
    }
}
