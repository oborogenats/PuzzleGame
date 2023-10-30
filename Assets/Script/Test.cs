using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int a = 0;
    public Color color;
    public MeshRenderer Mesh;

    void OnValidate()
    {
        switch (a)
        {
            
            case 1: color = Color.green; break;
            case 2: color = Color.blue; break;
            case 3: color = Color.yellow; break;
            default: color = Color.white; break;

        }


        if (Mesh != null)
        {
            Mesh.sharedMaterial.color = color;
        }
    }
    
}
