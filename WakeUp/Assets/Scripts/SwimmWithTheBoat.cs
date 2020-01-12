using UnityEngine;

public class SwimmWithTheBoat : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }

}
