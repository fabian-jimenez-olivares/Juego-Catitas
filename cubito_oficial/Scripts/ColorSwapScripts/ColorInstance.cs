using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class ColorInstance : MonoBehaviour
{
    [SerializeField] protected ColorMaterial colorMaterial;
    protected SpriteRenderer SpriteRenderer;
    
    protected bool Spawned;
    
    private void Awake()
    {
        VarInit();
        GameEvents.Current.OnColorSwapTrigger += ColorSwap;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    protected virtual void VarInit(){}

    private void OnDisable() => GameEvents.Current.OnColorSwapTrigger -= ColorSwap;

    private void ColorSwap(int newColor)
    {
        if (newColor == c.Monocromia.ID)
        {
            Swap(colorMaterial._monochromia);
        }
        else if (newColor == c.Protonopia.ID)
        {
            Swap(colorMaterial._protonopia);
        }
        else if (newColor == c.Tritonopia.ID)
        {
            Swap(colorMaterial._tritonopia);
        }
    }

    protected void Swap(Material newMaterial)
    {
        if (newMaterial != null)
        {
            SpriteRenderer.color = newMaterial.color;
            
            if (!Spawned)
                Spawn();
        }

        else
            Despawn();
    }

    protected virtual void Spawn()
    {
        SpriteRenderer.enabled = true;
        Spawned = true;
    }

    protected virtual void Despawn()
    {
        SpriteRenderer.enabled = false;
        Spawned = false;
    }
}
