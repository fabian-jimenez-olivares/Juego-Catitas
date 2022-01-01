using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewColorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<ColorController>().protonopiaEnabled = true;
            Destroy(gameObject);
        }
    }
}
