using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHit : MonoBehaviour
{
    public Collider Front;
    public Collider Back;
    public Collider Middle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collison)
    {
        if (Front.CompareTag("Car"))
        {

        }
    }
}
