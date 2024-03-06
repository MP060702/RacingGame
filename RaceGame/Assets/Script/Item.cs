using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemType;

    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += 1f;
        transform.rotation = Quaternion.Euler(rot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);       
        }
    }
}
