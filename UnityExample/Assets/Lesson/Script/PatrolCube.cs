using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PatrollSample();
    }

    void PatrollSample()
    {
        // PingPong = �ּҰ��� �ִ밪�� ���̸� �ݺ����ִ� �Լ�
        // PingPong(float t, float length)
        // Time.time -> ������ �� �������� ī��Ʈ�� �����Ѵ� (Play �ð� ����)
        transform.position = new Vector3(Mathf.PingPong(Time.time, 4), transform.position.y, transform.position.z);
    }
}
