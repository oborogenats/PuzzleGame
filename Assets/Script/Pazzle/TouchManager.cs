using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> touchBallList;

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
            touchBallList = new List<GameObject>();

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            var h = Physics.RaycastAll(ray, 100.0f);
            if (h.Length > 0)
            {
                //タッチしたボールが選択状態でないとき
                if (h[0].collider.tag == "Ball" && !h[0].collider.GetComponent<BallObject>().isTouch)
                {
                    h[0].collider.GetComponent<BallObject>().isTouch = true;
                    touchBallList.Add(h[0].collider.gameObject);
                }
                    
            }
        }

        if (Input.GetMouseButton(0)) 
        {
            if (touchBallList.Count != 0)
            {
                //選択しているボールが0個でないとき→タッチしたとき
                Ray ray = Camera.main.ScreenPointToRay(mousePos);
                var h = Physics.RaycastAll(ray, 100.0f);
                if (h.Length > 0)
                {
                    if (h[0].collider.tag == "Ball"&& !h[0].collider.GetComponent<BallObject>().isTouch)
                    {
                        h[0].collider.GetComponent<BallObject>().isTouch = true;
                        touchBallList.Add(h[0].collider.gameObject);
                    }

                }
            }
           

        }

        if(Input.GetMouseButtonUp(0))
        {
            ReleaseObject();
        }
    }

    public void ReleaseObject()
    {
        var cnt = touchBallList.Count;

        foreach(GameObject go in touchBallList)
        {
            go.GetComponent<BallObject>().isTouch = false;

            if (cnt >= 3)
            {
                Destroy(go);
            }
        }
        touchBallList.Clear();
    }
}
