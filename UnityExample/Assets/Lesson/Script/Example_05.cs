//#define EXAMPLE_TYPE_CLASS
#define EXAMPLE_TYPE_METHOD
//#define EXAMPLE_TYPE_PROPERTY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ŭ���� / �޼��� / ������Ƽ

#endregion

public class Example_05 : MonoBehaviour
{
    private int m_nValue = 100;

    public void Awake()
    {
#if EXAMPLE_TYPE_CLASS
        var DerivedA = new CDerived("HellFire", this);
        var DerivedB = new CDerived(10, 3.14f, "Hello", this);

        // 0 0 Hellfire 100 ���
        DerivedA.ShowInfo(); // �θ� 1��, �ڽ� 1��
        
        // 10 3.14 Hello this
        DerivedB.ShowInfo(); // ���� ����� �θ� 1��, �ڽ� 1��


#elif EXAMPLE_TYPE_METHOD

        int nLhs = 10;
        int nRhs = 20;

        SwapByValue(nLhs, nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        SwapByReference(ref nLhs, ref nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        int nValueA;
        int nValueB;

        // out�̴ϱ� �ʱ�ȭ������ϴµ�
        // ���߿� �Ҵ��ϰ� ���� �� out�� �ٿ��� �ѱ�� �ȴ�.
        this.InitValue(out nValueA, out nValueB);
        Debug.LogFormat("nValueA: {0}, nValueB: {1}", nValueA, nValueB);

        CBase oBase = new CLeaf();

        oBase.ShowInfo();

        int nSumValueA = this.GetSumValue(1, 2, 3, 4, 5, 1.0f, 2.0f, 3.0f, 4.0f);
        int nSumValueB = this.GetSumValue(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        Debug.LogFormat("SumValueA {0}, SumValueB {1}", nSumValueA, nSumValueB);
#else

#endif
    }

#if EXAMPLE_TYPE_CLASS
    /* ���� ���� / ���� ����
     * C# Ŭ������ �ᱹ ���� ����
     * 
     */

    // ���� Ŭ����
    class CBase
    {
        protected int m_nValue = 0;
        protected float m_fValue = 0.0f;

        // ������ / ��ǥ ������
        public CBase(int nValue, float fValue)
        {
            m_nValue = nValue;
            m_fValue = fValue;
        }

        public void ShowInfo()
        {
            Debug.LogFormat("����: {0}, �Ǽ�: {1}", m_nValue, m_fValue);
        }
    }

    class CDerived : CBase, System.ICloneable
    {
        private string m_oString = "";
        private Example_05 m_oExample = null;

        public CDerived(string a_oString, Example_05 a_oExample) : this(0, 0.0f, a_oString, a_oExample)
        {

        }

        public CDerived(int a_nValue, float a_fValue, string a_oString, Example_05 a_oExample) : base(a_nValue, a_fValue)
        {
            m_oString = a_oString;
            m_oExample = a_oExample;
        }

        // ��ü ����
        public object Clone()
        {
            var oDerived = new CDerived(m_nValue, m_fValue, m_oString, m_oExample);

            return oDerived;
        }

        public new void ShowInfo()
        {
            base.ShowInfo();

            Debug.LogFormat("���ڿ�: {0}, ����Ŭ����: {1}", m_oString, m_oExample.m_nValue);
        }


    }

#elif EXAMPLE_TYPE_METHOD

    class CBase
    {
        public virtual void ShowInfo()
        {
            Debug.Log("Base ���� ���");
        }
    }

    class CDerived : CBase
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Derived ���� ���");
        }

    }

    class CLeaf : CDerived
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Leaf ���� ���");
        }
    }

    private int GetSumValue(params object[] a_oParams)
    {
        int nSumValue = 0;
        float fSumValue = 0.0f;

        CBase oBase = new CDerived();
        // as / is
        // ����ȯ�� �������� �˻� (�� ĳ����, �ٿ� ĳ������ �������� �ƴ��� Ȯ��)
        CDerived oDerived = oBase as CDerived;

        if(oDerived != null)
        {
            Debug.Log("�ٿ� ĳ���ÿ� ����");
        }

        for(int i = 0; i < a_oParams.Length; ++i)
        {
            if(a_oParams[i] is int)
            {
                nSumValue += (int)a_oParams[i];
            }
            else
            {
                fSumValue += (float)a_oParams[i];
            }
        }

        return nSumValue;
    }

    private void InitValue(out int a_nValueA, out int a_nValueB)
    {
        a_nValueA = 10;
        a_nValueB = 20;
    }

    // call by value
    private void SwapByValue(int a_nLhs, int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }

    // call by reference
    private void SwapByReference(ref int a_nLhs, ref int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }

#else

#endif
}
