using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; 
    public bool bTimeMove = true;
    public GameObject shopUI;
    public Image[] BuyItemIcons;
    public Sprite[] BuyItemImages;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Buy(GameObject item)
    {   
        if(GameInstance.instance.currentmoney >= item.GetComponent<BuyItemInfo>().NeedMoney)
        {
            if (GameInstance.instance.Items.Contains(item) == false)
            {
                GameInstance.instance.currentmoney -= item.GetComponent<BuyItemInfo>().NeedMoney;
                Debug.Log(GameInstance.instance.currentmoney);
                GameInstance.instance.Items.Add(item);
                Debug.Log(item + "아이템 추가 ");
            }
        }
    }

    public void Update()
    {
        
    }

    public void AddBuyItemImage()
    {
        int itemIconIndex = 0;

        string[] buyItemTags = { "DesertWheel", "MountainWheel", "CityWheel", "6Engine", "8Engine"};

        for (int i = 0; i < buyItemTags.Length; i++)
        {
            GameObject buyItem = GameObject.FindWithTag(buyItemTags[i]);

            if (buyItem != null)
            {
                Debug.Log(itemIconIndex);
                BuyItemIcons[itemIconIndex].sprite = BuyItemImages[i];

                if (itemIconIndex < BuyItemIcons.Length - 1)
                    itemIconIndex++;
            }
        }
    }

    public void GoBackGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Goshop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GoMain()
    {
       SceneManager.LoadScene("Main");
    }

    public void GoStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    
    public void InGameShop()
    {   
        TImeStop();
        shopUI.SetActive(true);
    }

    public void TImeStop()
    {
        bTimeMove = !bTimeMove;
        Time.timeScale = Convert.ToInt32(bTimeMove);
    }

    public void Return()
    {
        shopUI.SetActive(false);
        bTimeMove = true;
        Time.timeScale = Convert.ToInt32(bTimeMove);
    }
}
