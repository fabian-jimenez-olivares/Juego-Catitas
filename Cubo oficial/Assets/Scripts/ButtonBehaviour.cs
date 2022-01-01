using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    private Animator _animator;
    private GameObject pressingObject;
    private GameObject secondPressingObject;

    private void Start() => _animator = GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Player")){
            if (pressingObject == null)
            {
                GameEvents.Current.ButtonTrigger(true);
                _animator.SetBool("ButtonPressed", true);
                pressingObject = other.gameObject;
            }
            else
            {
                secondPressingObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject == pressingObject)
            {
                if (secondPressingObject == null)
                {
                    GameEvents.Current.ButtonTrigger(false);
                    _animator.SetBool("ButtonPressed", false);
                } 
                pressingObject = secondPressingObject;
                secondPressingObject = null;
            }
            else
            {
                secondPressingObject = null;
            }
        }
    }
}
