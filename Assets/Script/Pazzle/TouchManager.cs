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
                    if (h[0].collider.GetComponent<BallObject>().color == GameResources.BallColor.bomb)
                    {
                        //爆発！
                        h[0].collider.GetComponent<BallObject>().Explosion(deleteObj);
                    }
                    else
                    {
                        h[0].collider.GetComponent<BallObject>().isTouch = true;
                        touchBallList.Add(h[0].collider.gameObject);
                    }
                    
                }
                    
            }
        }

        if (Input.GetMouseButton(0)) 
        {
            if (touchBallList.Count != 0)
            {
                if (touchBallList.Count != 0)
                {
                    Ray ray = Camera.main.ScreenPointToRay(mousePos);
                    var h = Physics.RaycastAll(ray, 100.0f);
                    if (h.Length > 0)
                    {
                        if (h[0].collider.tag == "Ball"
                            && !h[0].collider.GetComponent<BallObject>().isTouch
                            && touchBallList[0].GetComponent<BallObject>().color == h[0].collider.GetComponent<BallObject>().color)
                        {
                            h[0].collider.GetComponent<BallObject>().isTouch = true;
                            touchBallList.Add(h[0].collider.gameObject);
                        }
                        else if(h[0].collider.tag == "Ball"
                            && touchBallList[0].GetComponent<BallObject>().color != h[0].collider.GetComponent<BallObject>().color)
                        {
                            ReleaseObject();
                        }
                    }
                    else
                    {
                        //ボールをタッチしていない時は消去判定を行う
                        ReleaseObject();
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
                GameObject delObj = Instantiate(deleteObj);
                delObj.transform.position = go.transform.position;
                Destroy(go);
            }
        }
        touchBallList.Clear();
        if(cnt>= 3)
        {
            scoreManager.AddScore((int)Mathf.Pow(2, cnt));
        }
    }
}
