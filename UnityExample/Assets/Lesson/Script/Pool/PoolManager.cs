using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ���� ����� ���, �׷��� ����Ƽ���� ���� ���� �̶�� ������ ����
    // �̷��� ���� start�� awake���� �����������
    ObjectPooling instancePool;
    PoolPlayer player;
    bool pressed = false;
    

    void Start()
    {
        // �̰� ���� ���� ����
        // FindObjectOfType�� ���̾��Ű���� ã�ڴٴ� ��
        instancePool = FindObjectOfType<ObjectPooling>();
        player = FindObjectOfType<PoolPlayer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !pressed)
        {
            player.pressed = true;
            pressed = true;
        }

        if(player.pressed)
        {
            StartCoroutine("Shoot");
            player.pressed = false;
        }
    }

    // transform, coroutine, animation �� �Ű�Ἥ ������ �ֱ�

    // Enumerable => ����ī���� ����ϰڴ�
    IEnumerable Shoot()
    {
        while (true)
        {
            instancePool.SpawnObj();

            // tuple�� ��� -> n�� �̻��� ��ȯ���� �� �� �ֱ� ����
            // �񵿱��̱� ������ update�� ������ ���ư�
            // �񵿱�� ���⸦ ����� ���� ���� �ʴ�
            yield return new WaitForSeconds(0.3f);
        }
    }
}

