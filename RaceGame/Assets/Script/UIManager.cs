using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void Buy(GameObject item)
    {   
        if(GameInstance.instance.Items.Contains(item) == false)
        {
            Debug.Log(item + "아이템 추가 ");
            GameInstance.instance.Items.Add(item);
        }
    }
    
    public void GoBackGame()
    {
        SceneManager.LoadScene("Sample Scene");
    }
}
