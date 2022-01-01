using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current;

    private GameEvents() => Current = this;

    public event Action<int> OnColorSwapTrigger;
    public event Action<bool> OnButtonTrigger;

    public void ColorSwapTrigger(int id) => OnColorSwapTrigger?.Invoke(id);
    
    public void ButtonTrigger(bool state) => OnButtonTrigger?.Invoke(state);
}