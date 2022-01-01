using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "Color Palette", order = 1)]
public class ColorPalette : ScriptableObject
{
    public Material[] colors;
}
