using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ƽ ��ũ��Ʈ -> �������

/// <summary>
/// Assert�� ��ó���� �޽���(Pragma Message)
/// �����鿩�� ���� ����
/// </summary>


/// <summary>
/// ���� Ŭ����
/// </summary>
/// <param name= "���� ����"> MonoBehaviour�� ��ӹ޴� �⺻Ŭ����.</param>

public class Example_02 : MonoBehaviour
{
    void Awake()
    {
        print("Awake Call");
    }


    // Start is called before the first frame update
    void Start()
    {
        print("Start Call");
        Debug.Log(this.gameObject.name + " �Դϴ�.");
    }

    // Update is called once per frame
    void Update()
    {
        print("Update Call");

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(this.gameObject);
        }
    }

    void LateUpdate()
    {
        
    }

    void FixedUpdate()
    {
        // �⺻ �ð�
    }

    void OnDisable()
    {
        
    }

    void OnDestroy()
    {
        
    }

    void OnBecameInvisible()
    {
        
    }

    void OnBecameVisible()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));

        Gizmos.DrawWireSphere(this.transform.position, 1.0f);
    }

    IEnumerator StartCorutine()
    {
        yield return new WaitForSeconds(10.0f);
        yield return new WaitForSeconds(10.0f);
        yield return new WaitForSeconds(10.0f);
        yield return new WaitForSeconds(10.0f);
    }
}
