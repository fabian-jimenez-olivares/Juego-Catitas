using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlatformColor : ColorInstance
{
    private BoxCollider2D _boxCollider2D;
    
    private bool _isSpawnable;

    protected override void VarInit()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
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
        _boxCollider2D.isTrigger = false;
        gameObject.layer = 6;
        Spawned = true;
    }

    protected override void Despawn()
    {
        StopAllCoroutines();
        SpriteRenderer.enabled = false;
        _boxCollider2D.isTrigger = true;
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
