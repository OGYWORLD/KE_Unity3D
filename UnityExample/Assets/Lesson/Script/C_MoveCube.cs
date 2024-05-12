using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MoveCube : MonoBehaviour
{
    #region ���� ����

    public GameObject cubeObject = null;
    public float moveSpeed = 5.0f;

    #endregion

    // Ÿ ������Ʈ�ʹ� ���������� �����ϴ� ��ü
    // Start is called before the first frame update
    void Start()
    {
        // MoveSmaple_01();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveSmaple_02();

        MoveSample_03();
        CubeJump();
    }

    void MoveSmaple_01()
    {
        // ���� ��ǥ�踦 ��ȯ�Ҷ� ���
        transform.position = new Vector3(0.0f, 5.0f, 0.0f);

        // ���� ��ǥ�踦 ��ȯ�Ҷ� ���
        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f)); // Translate�� ���� ���� ���� ��ǥ��
    }

    void MoveSmaple_02()
    {
        //float moveDelta = moveSpeed * Time.deltaTime;

        //Vector3 pos = this.transform.position; // ����

        //pos.z += moveDelta;

        //this.transform.position = pos;

        // ==========

        // ����
        float moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta); // ����ȭ ������ forward

        // ����Ƽ������ ����ȭ ���͸� �����Ѵ�.
        // ���� = ũ�� + ����
        // ����ȭ ���͵��� Ư¡�� ��� ��ֶ���� �Ǿ��ִ�. -> �븻������: ������ ����ȭ = ���� ����
        // Vector3(1, 1, 1) => ũ�Ⱑ 1�� ���� = ���� ���� = ���⸸ ����ִ� = ����Ƽ������ ����1�̶�� ���Ѵ�.

        // �� ����ȭ�� ��Ű�°�, �� ���� ���͸� ����ϴ°�
        // ������ ũ�Ⱑ ���߳����ϴ�, ������ ũ�Ⱑ ũ�� ���귮�� Ŀ���� -> �����
        // ���Ͱ� ��ø�� ������ ����� => ������ ũ�Ⱑ Ŀ����.

        /*
         * Vector3(1, 0, 0) // Vector3.Right
         * Vector3(-1, 0, 0) // Vector3.Left
         * 
         * Vector3(0, 1, 0) // Vector3.Up
         * Vector3(0, -1, 0) // Vector3.Down
         * 
         * Vector3(0, 0, 1) // Vector3.Forward
         * Vector3(0, 0, -1) // Vector3.Back
         * 
         * Vector3(0, 0, 0) // Vector3.zero (���� - �̵�x)
         * Vector3(1, 1, 1) // Vector3.one (�������� �̵� (�����̵�))
         * 
         * 
         * 
         * <���� Ŭ���� ���>
         * Vector3.Dot(A, B)        ����
         * Vector3.Cross(A, B)      ����
         * Vector3.Distance         �Ÿ����� (A�� B�� �Ÿ�����)
         * Vector3.Angle            ���� ����(Degree)
         * 
         * 
         * 
         * <���� �ν��Ͻ� ���>
         * Vector3.Normalize()      ����ȭ(�������ͷ� �����)
         * Vector3.Magintude()      ������ ���̸� ��ȯ�ϴ� ������Ƽ
         * Vector3.SqrMagnitude()   ������ ���� ������ �˷��ִ� ������Ƽ -> ������
         * 
         */

    }

    void MoveSample_03()
    {
        var cubePosition = cubeObject.transform.position;

        /* GetAxis / GetAxisRaw
         * �Ѱ� �޴� �Ű� ������ ���ڿ��� ���ؼ� Ű���峪 ���̽�ƽ�� �Է� ���� -1 ~ +1 ������ ������ ��ȯ
         * 
         * GetAxis:
         * �ﰢ���� ������ ���� ��(����)
         * -1, 0, 1�θ� ����
         * ������ ���� ���ӿ� ��
         * 
         * 
         * GetAxisRaw:
         * �ε巯�� ������ ���� ��(�Ǽ�)
         * 
         */

        float fDeltaX = Input.GetAxisRaw("Horizontal");
        float fDeltaZ = Input.GetAxisRaw("Vertical");

        Debug.LogFormat("DelatX: {0}", fDeltaX);
        Debug.LogFormat("DelatZ: {0}", fDeltaZ);

        cubePosition.x += fDeltaX * 5.0f * Time.deltaTime;
        cubePosition.z += fDeltaZ * 5.0f * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cubePosition.x -= 5.0f * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cubePosition.x += 5.0f * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            cubePosition.z += 5.0f * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cubePosition.z -= 5.0f * Time.deltaTime;
        }

        cubeObject.transform.position = cubePosition;
    }

    void CubeJump()
    {
        if(Input.GetMouseButtonDown(0)) // ���� ���콺
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 0.5f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;
        }

        if(Input.GetMouseButton(1)) // ������ ���콺
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 2.0f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().AddForce(velocity); // AddForce�� ���� �����Ǳ� ������ ���콺�� �������� ����ŭ �ö�
        }
    }
}
