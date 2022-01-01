using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewColorScript1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<ColorController>().tritonopiaEnabled = true;
            Destroy(gameObject);
        }
    }
}
