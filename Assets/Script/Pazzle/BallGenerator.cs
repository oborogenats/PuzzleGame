using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Diagnostics;
using UnityEditor.Rendering;

public class BallGenerator : MonoBehaviour
{
    [SerializeField]
    AnimalAssets animalAssets;

    public static BallGenerator Instance { get; private set; }
    public bool isNext { get; set; }
    public int MaxBallNo { get; private set; }

    private List<GameObject> prefabList = new List<GameObject>();
    public List<GameObject> generatedObjects = new List<GameObject>();

    public float moveSpeed = 5f; // �ړ����x�̒����p
    public float leftLimit = -5f; // ���̐����ʒu
    public float rightLimit = 5f; // �E�̐����ʒu

    public bool isDragging = true;

    [SerializeField] 
    private Transform seedPosition;


    void Start()
    {
        prefabList = animalAssets.prefabList;
        GenerateRandomObject();
        Instance = this;
        isNext = false;
        MaxBallNo = animalAssets.prefabLis.Length;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // �}�E�X�̍��N���b�N��������Ă��邩�m�F
        {
            if (isDragging == false)
            {
                isDragging = true;
                DropObjects();
                Invoke("GenerateRandomObject", 2.0f);

            }
            else
            {
                UnityEngine.Debug.Log(Time.time + ":�Ăяo���Ȃ��c");
            }



        }
        // A�L�[�������ꂽ�獶�Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        // D�L�[�������ꂽ��E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

    }

    void MoveLeft()
    {
        // ���Ɉړ�����O�ɐ����ʒu���m�F
        if (transform.position.x > leftLimit)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    void MoveRight()
    {
        // �E�Ɉړ�����O�ɐ����ʒu���m�F
        if (transform.position.x < rightLimit)
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
        isDragging = false;


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

    public void OnObjectCollision()
    {
        if (isDragging == true)
        {
            isDragging = false;
            UnityEngine.Debug.Log("isDragging set to true");
            GenerateRandomObject();
        }
    }

    
}
