using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public int Loopcount = 3;
    public Color Color = Color.white;
    public Color AddColor = Color.black;
    public MeshRenderer Mesh;

    void OnValidate()
    {
        Color = Color.black;

        if(Loopcount < 0) Loopcount = 0;

        for(int i = 0; i < Loopcount; i++)
        {
            Color += AddColor;

            if (Color.r >= 1) break;
        }

        if (Mesh != null) Mesh.sharedMaterial.color = Color;
    }
}
