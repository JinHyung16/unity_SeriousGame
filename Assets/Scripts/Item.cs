using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
        else if(other.CompareTag("Box"))
        {
            this.gameObject.SetActive(false);
        }
        else if(other.CompareTag("Decoration"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
