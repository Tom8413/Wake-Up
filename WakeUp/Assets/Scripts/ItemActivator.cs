﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    [SerializeField]
    private int distanceFromPlayer;

    private GameObject player;

    public List<ActivatorItem> activatorItems;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        activatorItems = new List<ActivatorItem>();

        StartCoroutine("CheckActivation");
    }

    IEnumerator CheckActivation()
    {
        List<ActivatorItem> removeList = new List<ActivatorItem>();

        if ( activatorItems.Count >0)
        {
            foreach(ActivatorItem item in activatorItems)
            {
                if (Vector3.Distance(player.transform.position, item.itemPos) > distanceFromPlayer) //sprawdzamy odległość między Player a gameobject z listy
                {
                    if( item.item == null) //jeżeli z listy item (naszje listy acvivationItems) nasz object item nie istnieje ( po sprawdzeniu)
                    {
                        removeList.Add(item); // dodajemy go do listy gdzie znajdują się obiekty do usnięcia (albo deaktywacji)
                    }
                    else
                    {
                        item.item.SetActive(false); //jeżeli item wciąż istnieje
                    }
                }
                else // jeżeli nie niest tak daleko od Player
                {
                    if (item.item == null)
                    {
                        removeList.Add(item);
                    }
                    else
                    {
                        item.item.SetActive(true);
                    }
                }
                    
            }
        }
        yield return new WaitForSeconds(0.01f);

        if (removeList.Count > 0)
        {
            foreach (ActivatorItem item in removeList)
            {
                activatorItems.Remove(item);
            }
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("CheckActivation");
    } 


}

public class ActivatorItem
{
    public GameObject item;
    public Vector3 itemPos;
}