using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            var h = Physics.RaycastAll(ray, 100.0f);
            if (h.Length > 0)
            {
                if (h[0].collider.tag == "Ball")
                {
                    h[0].collider.GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_SubColor", new Color(1f, 1f, 0, 1f));
                }
                    
            }
        }

        if (Input.GetMouseButton(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            var h = Physics.RaycastAll(ray, 100.0f);
            if (h.Length > 0)
            {
                if (h[0].collider.tag == "Ball")
                {
                    h[0].collider.GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_SubColor", new Color(1f, 1f, 0, 1f));
                }
                
            }

        }

        if(Input.GetMouseButtonUp(0))
        {

        }
    }
}
