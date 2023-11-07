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

    public float moveSpeed = 5f; // �ړ����x�̒����p
    private bool isDragging = false;


    void Start()
    {
        GenerateRandomObject();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // �}�E�X�̍��N���b�N��������Ă��邩�m�F
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
                UnityEngine.Debug.Log(Time.time + ":�Ăяo���Ȃ��c");
            }



        }
        // A�L�[�������ꂽ�獶�Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        // D�L�[�������ꂽ��E�Ɉړ�
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


        // �����_���ɃI�u�W�F�N�g��I��
        int randomIndex = UnityEngine.Random.Range(0, prefabList.Count);
        GameObject selectedPrefab = prefabList[randomIndex];
        GameObject newObject = Instantiate(selectedPrefab);
        newObject.transform.parent = this.transform;
        newObject.transform.localPosition = Vector3.zero;

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // �d�͂�L���ɂ��ăI�u�W�F�N�g�𗎂Ƃ�
            rb.useGravity = false;
        }

        // ���������I�u�W�F�N�g�����X�g�ɒǉ�
        generatedObjects.Add(newObject);
    }

    void DropObjects()
    {
        foreach (GameObject obj in generatedObjects)
        {
            // Rigidbody���A�^�b�`����Ă��邩�m�F
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // �d�͂�L���ɂ��ăI�u�W�F�N�g�𗎂Ƃ�
                rb.useGravity = true;

                
                
            }
            StartCoroutine(UnparentAfterDrop(obj.transform, transform));

        }



    }

    IEnumerator UnparentAfterDrop(Transform child, Transform parent)
    {
        // 1�t���[���҂��Ă���e�q�֌W������
        yield return null;
        child.parent = null;
    }
}
