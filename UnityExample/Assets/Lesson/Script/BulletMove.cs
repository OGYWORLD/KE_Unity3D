using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    IEnumerable func;
    UnityEngine.Coroutine BulletCoroutine;
    bool isFlying = true;
    Transform playerPos;

    void Awake()
    {
        // ȣ�� ������ start�� �и� �� �־ Awake�� �־��ش�.
        playerPos = FindObjectOfType<PoolPlayer>().gameObject.transform;
        transform.position = playerPos.position; // ����Ƽ�� transform�� ���� �������� ���� �Ұ���


    }

    // ������Ʈ Ǯ���� Ȱ��ȭ/��Ȱ��ȭ�� ���� ����
    // ������Ʈ Ǯ���� GC�� ���� ã�ƺ���
    void OnEnable()
    {
        func = Move();
        BulletCoroutine = StartCoroutine("func");
        transform.position = playerPos.position;
    }

    void OnDisenable()
    {
        StopCoroutine("func"); // �ڷ�ƾ ���ֱ�
    }

    IEnumerable Move()
    {
        StartCoroutine("Stop");

        while(isFlying)
        {
            transform.Translate(transform.forward * 10.0f * Time.deltaTime);
            yield return new WaitForEndOfFrame(); // �� �����Ӹ� ���۽�Ű�� while ������
        }

        gameObject.SetActive(false);
        isFlying = true;
    }

    IEnumerable Stop()
    {
        yield return new WaitForSeconds(2.0f);
        isFlying = false;
    }
}
