using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp : MonoBehaviour
{
    //親となるオブジェクト
    [SerializeField] Transform root;
    [SerializeField] Image[] img;

    private void OnValidate()
    {
        //Nullチェック
        if (root != null)
        {
            //子の数を配列の長さとして代入
            img = new Image[root.childCount];
            //ImageをHierarchyの順に代入
            for (int i = 0; i < img.Length; i++)
            {
                img[i] = root.GetChild(i).GetComponent<Image>();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
