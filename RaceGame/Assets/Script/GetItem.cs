using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
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
                    playerInfo.SetPlayerSpeed(1.5f);
                    Debug.Log("SpeedUP");
                    break;
                case 5:
                    playerInfo.SetPlayerSpeed(2.0f);
                    Debug.Log("SpeedUP");
                    break;
            }
        }
    }
}
