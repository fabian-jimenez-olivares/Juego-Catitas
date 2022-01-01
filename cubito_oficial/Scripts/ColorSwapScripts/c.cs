using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c : MonoBehaviour
{
    public struct ColorTag
    {
        public int ID;
        public String Name;
        
        public ColorTag(int id, String name)
        {
            ID = id;
            Name = name;
        }
    }

    public static readonly ColorTag Monocromia = new ColorTag(1, "Monocromia");
    public static readonly ColorTag Protonopia = new ColorTag(2, "Protonopia");
    public static readonly ColorTag Tritonopia = new ColorTag(3, "Tritonopia");
}
