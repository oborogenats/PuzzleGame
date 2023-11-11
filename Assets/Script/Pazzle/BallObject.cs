using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    [SerializeField]
    public Renderer myrenderer;

    ScoreManager scoreManager;
    public BallGenerator generator; // ObjectGeneratorÇ÷ÇÃéQè∆

    [SerializeField]
    public bool isCollided = false;

    public int ballNo;
    public bool isMergeFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("ScoreManager");
        scoreManager = go.GetComponent<ScoreManager>();
        GameObject b = GameObject.Find("BallGenerator");
        generator = b.GetComponent<BallGenerator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject colobj = collision.gameObject;
        if (colobj.CompareTag("Ball"))
        {
            seed colball = collision.gameObject.GetComponent<BallObject>();
            if (ballNo == colball.ballNo &&
                !isMergeFlag &&
                !colseed.isMergeFlag &&
                ballNo < generator.Instance.MaxBallNo - 1)
            {
                isMergeFlag = true;
                ballseed.isMergeFlag = true;
                generator.Instance.MergeNext(transform.position, ballNo);
                Destroy(gameObject);
                Destroy(colball.gameObject);
            }
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
