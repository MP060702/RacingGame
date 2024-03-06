using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 들어온 콜라이더의 방향을 가져옴
        Vector3 direction = (collision.transform.position - transform.position).normalized;

        // 콜라이더의 방향을 기준으로 앞, 뒤, 오른쪽, 왼쪽을 판별함
        float dotForward = Vector3.Dot(transform.forward, direction);
        float dotRight = Vector3.Dot(transform.right, direction);

        // 방향을 기준으로 판별된 결과를 출력
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
