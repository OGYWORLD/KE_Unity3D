//#define EXAMPLE_TYPE_VALUE // ��ũ�δ� �ֻ�ܿ� �����ؾ��� ������ ���� �� ��
//#define EXAMPLE_TYPE_REFERENCE
#define EXAMPLE_TYPE_NULLABLE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region C#

#endregion

public class Example_04 : MonoBehaviour
{
    public void Awake()
    {


#if EXAMPLE_TYPE_VALUE

        int nValue = 10;
        float fValue = 3.14f;
        double dValue = 3.14;
        decimal mValue = 3.14m;

        Debug.LogFormat("������ ��� {0} {1} {2} {3}", nValue, fValue, dValue, mValue);

#elif EXAMPLE_TYPE_REFERENCE

        object oValue = 10;
        string oString = "HelloFire";

        // $: C# 6.0���� �߰��� ��� -> ���ڿ� ���� (������ ���ڿ��� �ĺ�)
        // 2�̻��� �ε������� 2�� ���� �ε����� ���� �ؽ��ؼ� �����Ѵٴ� ��
        // 1. lengh�� ���Ѵ�
        // 2. 2�̻��� �ε������� 2�� ���� �ε��� ���� �����ؼ� �̰ɷ� ���ڿ��� �аڴٴ� ��
        Debug.Log($"������ ��� : {oValue}, {oString}");

#else

        int? nValue = null; // �ּ� ���� Ȯ��
        float? fValue = null;
        System.Nullable<int> nValueB = 10;

        if(nValue.HasValue)
        {
            Debug.Log("������ ���� ��ȿ");
        }
        else
        {
            Debug.Log("������ ���� ��ȿ���� ����");
        }

        if(fValue != null)
        {
            Debug.Log("�Ǽ��� ���� ��ȿ");
        }
        else
        {
            Debug.Log("�Ǽ��� ���� ��ȿ���� ����");
        }

        if(nValueB.HasValue)
        {
            Debug.Log("������ ���� ��ȿ");
        }
        else
        {
            Debug.Log("������ ���� ��ȿ���� ����");
        }

#endif


    }
}
