using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Cherry"))
        {
            Destroy(other.gameObject);
            cherries ++;
            Debug.Log("Cherries: " + cherries);
        }
    }
}
