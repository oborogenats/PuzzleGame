using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    [SerializeField]
    public Renderer myrenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Debug.Log("�Ԃ������I");
        }
        else
        {
            Debug.Log("�{�[������Ȃ��Ƃ���ɂԂ������I");
        }
    }
        

}
