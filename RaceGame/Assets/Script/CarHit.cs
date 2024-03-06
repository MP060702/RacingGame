using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // ���� �ݶ��̴��� ������ ������
        Vector3 direction = (collision.transform.position - transform.position).normalized;

        // �ݶ��̴��� ������ �������� ��, ��, ������, ������ �Ǻ���
        float dotForward = Vector3.Dot(transform.forward, direction);
        float dotRight = Vector3.Dot(transform.right, direction);

        // ������ �������� �Ǻ��� ����� ���
        if (dotForward > 0.5f)
        {
            Debug.Log("Entered from the front");
        }
        else if (dotForward < -0.5f)
        {
            Debug.Log("Entered from the back");
        }
        else if (dotRight > 0.5f)
        {
            Debug.Log("Entered from the right");
        }
        else if (dotRight < -0.5f)
        {
            Debug.Log("Entered from the left");
        }
    }
}
