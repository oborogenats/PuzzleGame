using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    [SerializeField]
    public Renderer myrenderer;

    [SerializeField]
    public bool isTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_SubColor", new Color(0.5f, 0.5f, 0f,1f));
        }
        else
        {
            GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_SubColor", new Color(0.0f, 0.0f, 0f,0f));
        }
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
