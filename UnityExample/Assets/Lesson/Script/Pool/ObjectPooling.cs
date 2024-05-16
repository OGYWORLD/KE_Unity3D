using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������Ʈ Ǯ��
#endregion

#region �ν����� �Ӽ�
/*
 * 
 */
#endregion

public class ObjectPooling : MonoBehaviour
{
    int pointer;
    // List<T> Value = new List<>();
    // ���� �迭(��� �Լ��̰� �߰� �� ������ �����ϴ�.)
    // ���� ������ Ÿ�Ը� ���� �����ϴ� �̴� �� �ڽ̰� ��ڽ��� �������� �ʴ´ٴ� ���
    List<GameObject> pool; // ���� ī��� -> ����Ʈ ������
    [SerializeField]
    GameObject pooledObject;

    void Start()
    {
        // ����Ƽ ���� �Լ� �������� -> Max�� ���Ե��� �ʴ´�.
        // ������ ����
        int size = Random.Range(10, 15);

        pointer = 0;
        pool = new List<GameObject>();

        for(int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(pooledObject, Vector3.zero, pooledObject.transform.rotation);
            obj.SetActive(false);
            obj.transform.parent = transform;
            pool.Add(obj);
        }


    }

    public void SpawnObj()
    {
        // ����Ʈ ������ ã�Ƽ� �����ϱ�<shared, unique, weak>
        if(pointer != pool.Count) // ���� �ּ��� ������ ���� = ���� ī����
        {
            pool[pointer].SetActive(true);
            pointer++;
        }
        else
        {
            pointer = 0;
            pool[pointer].SetActive(true);
            pointer++;
        }
    }
}
