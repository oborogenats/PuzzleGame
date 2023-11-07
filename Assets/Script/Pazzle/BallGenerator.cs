using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Diagnostics;

public class BallGenerator : MonoBehaviour
{

    public List<GameObject> prefabList = new List<GameObject>();

    int cnt = 0;
    const int MAXCNT = 10;

    int generateCount = 0;

    void Start()
    {

    }

    void Update()
    {
        cnt++;
        cnt %= MAXCNT;
        if (cnt == 0)
        {
            generateCount++;
            generateCount %= 10;

            if (generateCount == 0)
            {
                InstantiateRandomPrefab();
            }
        }
    }

    void InstantiateRandomPrefab()
    {
        // ���X�g����łȂ����m�F
        if (prefabList.Count > 0)
        {
            // �����_���ɃC���f�b�N�X��I��
            int randomIndex = UnityEngine.Random.Range(0, prefabList.Count);

            // �����_���ɑI��Prefab�𐶐�
            GameObject randomPrefab = prefabList[randomIndex];
            GameObject spawnedObject = Instantiate(randomPrefab, transform.position, Quaternion.identity);

            // Rigidbody�R���|�[�l���g���擾�܂��͒ǉ�
            Rigidbody rigidbody = spawnedObject.GetComponent<Rigidbody>();
            if (rigidbody == null)
            {
                rigidbody = spawnedObject.AddComponent<Rigidbody>();
            }

            // �����_���Ȋp�x�Ɨ͂�t���ė��Ƃ�
            rigidbody.AddForce(Quaternion.Euler(0, 0, UnityEngine.Random.Range(-60.0f, 60.0f)) * Vector3.down * 10f, ForceMode.Impulse);
        }
        else
        {
        }
    }
}
