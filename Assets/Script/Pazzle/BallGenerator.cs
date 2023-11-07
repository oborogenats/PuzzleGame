using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Diagnostics;
using UnityEditor.Rendering;

public class BallGenerator : MonoBehaviour
{

    public List<GameObject> prefabList = new List<GameObject>();

    public List<GameObject> generatedObjects = new List<GameObject>();

    public float moveSpeed = 5f; // 移動速度の調整用
    private bool isDragging = false;


    void Start()
    {
        GenerateRandomObject();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // マウスの左クリックが押されているか確認
        {
            if (isDragging == false)
            {
                isDragging = true;
                DropObjects();
                Invoke("GenerateRandomObject", 2f);
                isDragging = false;
                
            }
            else if (isDragging == true)
            {
                UnityEngine.Debug.Log(Time.time + ":呼び出せない…");
            }



        }
        // Aキーが押されたら左に移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        // Dキーが押されたら右に移動
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

    }

   

    void GenerateRandomObject()
    {
        if (prefabList.Count == 0)
        {
            UnityEngine.Debug.Log("No object prefabs available for generation.");
            return;
        }


        // ランダムにオブジェクトを選択
        int randomIndex = UnityEngine.Random.Range(0, prefabList.Count);
        GameObject selectedPrefab = prefabList[randomIndex];
        GameObject newObject = Instantiate(selectedPrefab);
        newObject.transform.parent = this.transform;
        newObject.transform.localPosition = Vector3.zero;

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 重力を有効にしてオブジェクトを落とす
            rb.useGravity = false;
        }

        // 生成したオブジェクトをリストに追加
        generatedObjects.Add(newObject);
    }

    void DropObjects()
    {
        foreach (GameObject obj in generatedObjects)
        {
            // Rigidbodyがアタッチされているか確認
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 重力を有効にしてオブジェクトを落とす
                rb.useGravity = true;

                
                
            }
            StartCoroutine(UnparentAfterDrop(obj.transform, transform));

        }



    }

    IEnumerator UnparentAfterDrop(Transform child, Transform parent)
    {
        // 1フレーム待ってから親子関係を解除
        yield return null;
        child.parent = null;
    }
}
