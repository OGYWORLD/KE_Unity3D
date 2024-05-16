using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region ������

#endregion

public class CPrefabExample : MonoBehaviour
{
    #region
    public GameObject BulletObject = null;


    #endregion
 
    void Update()
    {
        FireSample_03();
    }

    void FireSample_01()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // prefab�� ������ �� ģ���� ���´�.
            // Instantiate(): ������Ʈ�� �����Ѵ� (��ü�� �������� ����)
            // ���� ������Ʈ�� �����Ͽ� Ŭ�� ��ȯ���ִ� �޼���
            // Instantiate�� �����ε��� ������ ���� ���¸� �������!
            // �μ�: ��� ������Ʈ, ������Ʈ ��ġ, ������Ʈ ȸ����
            //Instantiate(BulletObject, transform.position, transform.rotation);
            // Destroy(BulletObject); �ڽ�Ʈ�� ū Destroy

            // ������ �ٵ�: ���� ��� ��ü�� �ʿ��ϴ�.
            // Instantiate�� ���� ����� �������� �ʴ´�.
            GameObject bullet = Instantiate(BulletObject, transform.position, transform.rotation);
            float bulletPower = 1000.0f;
            Vector3 direction = new(0.0f, 0.3f, 0.5f);

            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletPower);
        }
    }

    void FireSample_02()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �����Ǵ� ��ġ�� ��ġ�� �Ѿ��� ������ �����Ƿ� ��ġ�� ����
            GameObject bullet = Instantiate(BulletObject, transform.position + transform.forward * 0.7f, transform.rotation);
            float bulletPower = 1500.0f;
            Vector3 direction = new(0.0f, 0.3f, 0.5f);

            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletPower);
            bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Destroy(bullet, 3.0f); // clone ����
        }
    }

    void FireSample_03()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletObject, transform.position + transform.forward * 0.7f, transform.rotation);
            float bulletPower = 4000.0f;

            // �߻�밡 �ٶ󺸸� �������� �Ѿ��� ���� �� �ֵ���
            // TransformDirection: ������Ʈ�� � ������ �ٶ� �������� ������ ����� �� �� ����Ѵ�.
            Vector3 shootForward = bullet.transform.TransformDirection(Vector3.forward);

            bullet.GetComponent<Rigidbody>().AddForce(bulletPower * shootForward);
            bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Destroy(bullet, 5.0f); // clone ����
        }
    }
}
