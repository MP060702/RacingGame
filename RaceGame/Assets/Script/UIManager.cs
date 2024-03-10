using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class UIManager : MonoBehaviour
{
    public Image[] BuyItemIcons;
    public Sprite[] BuyItemImages;
    public void Start()
    {

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
        AddBuyItemImage(); 
    }

    public void AddBuyItemImage()
    {
        int itemIconIndex = 0;

        string[] buyItemTags = { "BuyItem", "BuyItem1", "BuyItem2" };

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
}
