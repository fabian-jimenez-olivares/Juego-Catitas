using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColor : ColorInstance
{
    private bool _isSpawnable;

    protected override void VarInit()
    {
        _isSpawnable = true;
    }

    protected override void Spawn()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitUntil(() => _isSpawnable);
        SpriteRenderer.enabled = true;
        gameObject.layer = 6;
        Spawned = true;
    }

    protected override void Despawn()
    {
        StopAllCoroutines();
        SpriteRenderer.enabled = false;  
        gameObject.layer = 7;
        Spawned = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            _isSpawnable = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            _isSpawnable = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            _isSpawnable = false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            _isSpawnable = true;
    }
}
