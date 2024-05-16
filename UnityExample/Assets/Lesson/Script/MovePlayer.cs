using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 0.0f;

    // ����Ƽ �̺�Ʈ �޼ҵ�� �޸� �����ϴϱ�(�ݹ��Լ���) �� ���Ÿ� �����
    // �ּ��� �� ����

    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(-hori * Time.deltaTime * speed, upDown * Time.deltaTime * speed, 0.0f);

        transform.Translate(move);
    }
}
