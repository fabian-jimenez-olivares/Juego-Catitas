using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public static bool InputEnabled;
    public static int CurrentColor = 1;
    
    public bool protonopiaEnabled;
    public bool tritonopiaEnabled;

    private void Start() => GameEvents.Current.ColorSwapTrigger(CurrentColor);

    private void Update()
    {
        if (InputEnabled)
            GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameEvents.Current.ColorSwapTrigger(c.Monocromia.ID);
            CurrentColor = c.Monocromia.ID;
        }
        if (Input.GetKeyDown(KeyCode.K) && protonopiaEnabled)
        {
            GameEvents.Current.ColorSwapTrigger(c.Protonopia.ID);
            CurrentColor = c.Protonopia.ID;
        }
        if (Input.GetKeyDown(KeyCode.L) && tritonopiaEnabled)
        {
            GameEvents.Current.ColorSwapTrigger(c.Tritonopia.ID);
            CurrentColor = c.Tritonopia.ID;
        }
    }
}
