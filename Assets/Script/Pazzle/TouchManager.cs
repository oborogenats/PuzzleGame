using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> touchBallList;

    [SerializeField]
    GameObject deleteObj;

    [SerializeField]
    ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
