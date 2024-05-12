using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    #region ���� ����
    public GameObject target = null;
    #endregion

    // Update is called once per frame
    void Update()
    {
        LookAtSample();
    }

    void LookAtSample()
    {
        // 3d���� �Ÿ��� ���ϴ� ����: ���� - ����
        Vector3 directionalToTarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(directionalToTarget, Vector3.up);
    }
}
