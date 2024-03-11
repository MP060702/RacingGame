using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();
    public static GameInstance instance;
    public int currentmoney = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
