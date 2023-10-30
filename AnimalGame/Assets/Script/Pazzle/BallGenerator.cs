using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject ballObj;

    int cnt = 0;
    const int MAXCNT = 120;

    void Start()
    {
        
    }

    void Update()
    {
        cnt++;
        cnt%= MAXCNT;
        if (cnt == 0)
        {
            GameObject gameObject = Instantiate(ballObj);
            gameObject.transform.parent = this.transform;
            gameObject.transform.localPosition = Vector3.zero;
        }
    }
}
