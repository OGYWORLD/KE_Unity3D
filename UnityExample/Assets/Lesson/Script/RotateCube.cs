using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ȸ��
/*
 * 
 * 
 * 
 * 
 * 
 */
#endregion

public class RotateCube : MonoBehaviour
{
    #region ���� ����

    public GameObject target = null;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RotateSample_01();
        RotationAroundSample();
    }

    void RotateSample_01()
    {
        // ���ڸ� ȸ��

        // 1. ���Ϸ���: ���� �������� ���� ��ŭ ȸ�� (�⺻������ ������ �����Ǿ� �ִ�)
        this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);

        // 2. ���� ����
        // ���ڷ� ���� ������ ���Ϸ� ���� ���ʹϾ����� ��ȯ -> �Ķ���ʹ� �ַ� �Ǽ� / ����
        // ���ʹϾ��� �ܵ����� ������ �� ����. -> ���ʿ��� ���� ���谡 �����.(���߿� ������ �غ�����)
        Quaternion target = Quaternion.Euler(45.0f, 45.0f, 45.0f); // ������Ƽ�� �ƴұ� �ǽ�
        this.transform.rotation = target;

        // 3. 
        // Rotate vs rotation ������
        this.transform.Rotate(Vector3.up * 60.0f);
    }

    void RotationSample_02()
    {
        // AngelAxis:�� ������ �ޱ۸�ŭ ȸ���� �����̼��� �����ϰ� ��ȯ
        // �߽� ���� �Ǵ� axis�� y���� ��� y�࿡ ���� ȸ������ ������ �ʰ�
        // x, z�� ���� ���Ѵ�.

        this.transform.rotation *= Quaternion.AngleAxis(1.5f, Vector3.up);
    }

    void RotationAroundSample()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 100 * Time.deltaTime);
    }
}
