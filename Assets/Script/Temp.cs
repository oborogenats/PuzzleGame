using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp : MonoBehaviour
{
    //�e�ƂȂ�I�u�W�F�N�g
    [SerializeField] Transform root;
    [SerializeField] Image[] img;

    private void OnValidate()
    {
        //Null�`�F�b�N
        if (root != null)
        {
            //�q�̐���z��̒����Ƃ��đ��
            img = new Image[root.childCount];
            //Image��Hierarchy�̏��ɑ��
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
