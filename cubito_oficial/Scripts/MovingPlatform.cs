using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    
    [SerializeField] private Transform origin;
    [SerializeField] private Transform destiny;

    private void Awake()
    {
        GameEvents.Current.OnButtonTrigger += ButtonAction;
    }

    private void ButtonAction(bool value)
    {
        StopAllCoroutines();

        StartCoroutine(value ? MovePlatform() : ReturnPlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (transform.position != destiny.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, destiny.position, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    
    private IEnumerator ReturnPlatform()
    {
        while (transform.position != origin.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, origin.position, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }
    }
}