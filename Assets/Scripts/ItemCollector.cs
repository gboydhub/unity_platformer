using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesLabel;
    private int cherries = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Cherry"))
        {
            Destroy(other.gameObject);
            cherries ++;
            cherriesLabel.text = "Cherries: " + cherries;
        }
    }
}
