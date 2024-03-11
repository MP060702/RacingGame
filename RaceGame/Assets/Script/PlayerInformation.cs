using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int money = 0;
    public int Lap = 0;
    Rigidbody rb;
    bool off = true;

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
        UIManager.instance.AddBuyItemImage();

    }

    public void FindEngine()
    {
        
        string[] EnginesString = { "6Engine", "8Engine" };
        GameObject Engine6 = GameObject.FindWithTag(EnginesString[0]);
        GameObject Engine8 = GameObject.FindWithTag(EnginesString[1]);
        if (off)
        {
            if (Engine6 != null)
            {
                SetPlayerSpeed(1.2f);
                Debug.Log("1.2f Speed");
            }
        }
        if(Engine8 != null)
        {
            off = false;
            SetPlayerSpeed(1.5f);
            Debug.Log("1.5f Speed");
        }

    }

    public void SetPlayerSpeed(float speed)
    {
        rb.velocity *= speed;
    }

    public void AddBuyItems()
    {   
        for(int i = 0; i < GameInstance.instance.Items.Count; i++)
        {
            var itemObjs = Instantiate(GameInstance.instance.Items[i], transform.position, transform.rotation);
            itemObjs.transform.parent = gameObject.transform;
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DesertSlow")
        {
            if (GameObject.Find("DesertWheel") == null)
            {
                SetPlayerSpeed(0.8f);
                Debug.Log("SpeedSlowed");
            }
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
