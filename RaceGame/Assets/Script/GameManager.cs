using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public Transform WayPoints;
    public GameObject[] Items;
    public static GameManager instance;
    public GameObject Enemy;


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

    public void SpawnItem()
    {
        foreach (Transform SpawnPoint in WayPoints.transform)
        {
            Vector3 randPos = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
            if (Random.Range(0, 3) == 0)
            {
                int ranItemIndex = Random.Range(0, Items.Length);
                Instantiate(Items[ranItemIndex], SpawnPoint.position + randPos, Quaternion.identity);
            }
        }

    }
    public void SpawnEnemy()
    {
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(Enemy);
            Debug.Log("SpawnEnemy");
        }
    }
}
