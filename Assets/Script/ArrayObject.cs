using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayObject : MonoBehaviour
{
    public Transform[] Objects;
    public float Range = 1f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i< Objects.Length; i++)
        {
            var pos = Vector3.zero;
            pos.x = i * Range;
            Objects[i].position = pos;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
