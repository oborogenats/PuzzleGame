using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    [SerializeField]
    public Renderer myrenderer;

    [SerializeField]
    public bool isTouch = false;

    [SerializeField]
    public GameResources.BallColor color;

    ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
         GameObject go = GameObject.Find("ScoreManager");
        scoreManager = go.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_SubColor", new Color(0.5f, 0.5f, 0f,0.5f));
        }
        else
        {
            GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_SubColor", new Color(0.0f, 0.0f, 0f,0f));
        }
    }

 public void ChangeColor()
    {
        switch (color)
        {
            case GameResources.BallColor.red:
                GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_MainColor", Color.red);
                break;
            case GameResources.BallColor.blue:
                GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_MainColor", Color.blue);
                break;
            case GameResources.BallColor.green:
                GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_MainColor", Color.green);
                break;
            case GameResources.BallColor.purple:
                GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_MainColor", new Color(1, 0, 1));
                break;
            case GameResources.BallColor.bomb:
                GetComponent<BallObject>().GetComponent<Renderer>().material.SetColor("_MainColor", new Color(0, 0, 0));
                break;
        }
    }
public void Explosion(GameObject deleteObject)
    {

        var h = Physics.SphereCastAll(transform.position, 5.0f, Vector3.forward);

        foreach(var hit in h)
        {
            //Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (hit.collider.tag == "Ball")
            {
                var delObj = Instantiate(deleteObject);
                delObj.transform.position = hit.collider.gameObject.transform.position;
                //ì_êî
                scoreManager.AddScore((int)Mathf.Pow(2, 1));
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
