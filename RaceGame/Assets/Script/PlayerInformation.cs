using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void Update()
    {
        AddBuyItems();
        if (Input.GetKeyDown(KeyCode.B)) SceneManager.LoadScene("Shop");
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
}
