using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int money = 0;
    public int Lap = 0;
    Rigidbody rb;
     
    void Start()
    {
        GameManager.instance.SpawnItem();
        rb = GetComponent<Rigidbody>();
        money = GameInstance.instance.currentmoney;
        Debug.Log(money);
        AddBuyItems();
    }
    private void Update()
    {
        GameInstance.instance.currentmoney = money;
    }

    public void SetPlayerSpeed(float speed)
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    public void AddBuyItems()
    {   
        for(int i = 0; i < GameInstance.instance.Items.Count; i++)
        {
            var itemObjs = Instantiate(GameInstance.instance.Items[i], transform.position, transform.rotation);
            itemObjs.transform.parent = gameObject.transform;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {

            if(GetComponent<wheel>().CanTouchFinishLine == true)
            {
                GetComponent<wheel>().CanTouchFinishLine = false;
                GameManager.instance.SpawnItem();
                Lap++;

                if(Lap >= 3)
                {
                    Debug.Log("You Win");
                }
            }
        }
    }
}
