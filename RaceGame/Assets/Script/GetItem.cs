using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetItem : MonoBehaviour
{
    public GameObject EnemyAi;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Item"))
        {
            int type = other.GetComponent<Item>().ItemType;
            PlayerInformation playerInfo = gameObject.GetComponent<PlayerInformation>();           

            switch (type)
            {
                case 1:
                     playerInfo.money += 1000000;
                     Debug.Log(playerInfo.money);               
                     break;
                case 2:
                     playerInfo.money += 5000000;
                     Debug.Log(playerInfo.money);
                     break;
                case 3:
                    playerInfo.money += 10000000;
                    Debug.Log(playerInfo.money);
                    break;
                case 4:
                    Debug.Log("SpeedUP1");
                    break;
                case 5:
                    Debug.Log("SpeedUP2");
                    break;
                case 6:
                    UIManager.instance.InGameShop();
                    break;

            }
        }
    }
}
