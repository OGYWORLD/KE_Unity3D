using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ObjectController : MonoBehaviour
{
    #region ���� ����

    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;

    #endregion

    public void Awake()
    {
        Debug.Log("Your Light, Unity");

        // GetComponent<T> Ȱ��
        // var�� auto ���� �� (���� ���� �˻�(����) - ���� ���� �˻�� ������Ÿ���� ���(�Ǽ� ����) -> C#���� ����)
        // var�� ���� �����θ� �����ؾߵ� -> ����� ���ÿ� �ݵ�� �ʱ�ȭ�� �����ؾ� �Ѵ�.
        var transformObject = cubeObject.GetComponent<Transform>(); 
        transformObject.position = new Vector3(4.0f, 8.0f, -4.0f);

        var selfTransform = gameObject.GetComponent<Transform>();
        selfTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // ��� ������ ��� - ������Ƽ�� ���� ����
        //this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //cubeObject.transform.position = new Vector3(0.1f, 0.1f, 0.1f);

        //
        var oCubeObject = GameObject.Find("MoveCube");
        oCubeObject.AddComponent<CMoveFoward>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
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
