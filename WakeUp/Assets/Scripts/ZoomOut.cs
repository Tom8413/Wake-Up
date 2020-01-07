using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public string parametr;

    public Animator camAnim;

    public BoxCollider2D trigger;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider == trigger)
        {
            camAnim.SetBool(parametr, true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider == trigger)
        {
            camAnim.SetBool(parametr, false);
        }
    }
}
