using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int money = 0;
    Rigidbody rb;
     
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        money = GameInstance.instance.currentmoney;
        Debug.Log(money);
    }

    public void SetPlayerSpeed(float speed)
    {
        rb.velocity *= speed;
    }
}
