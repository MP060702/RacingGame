using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform CarModel;
    //public Transform CarNormal;
    public Rigidbody sphere;

    float speed, currentSpeed;
    float rotate, currentRotate;
    public float steering = 80f;
    public float acceleration = 30f;
    public float gravity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = sphere.transform.position - new Vector3(0, -2f, 0);

        if(Input.GetAxis("Vertical") != 0)
        {
            int dir1 = Input.GetAxis("Vertical") > 0 ? 1 : -1;
            speed = acceleration * dir1;            
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            int dir2 = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs(Input.GetAxis("Horizontal"));
            Steer(dir2, amount);
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f); 
        speed = 0f;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);
        rotate = 0f;

    }

    private void FixedUpdate()
    {
        sphere.AddForce(CarModel.transform.forward * currentSpeed, ForceMode.Acceleration);

        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);

        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position, Vector3.down, out hitOn, 1.1f);
        Physics.Raycast(transform.position, Vector3.down, out hitNear, 2.0f);

        CarModel.parent.up = Vector3.Lerp(CarModel.parent.up, hitNear.normal, Time.deltaTime * 8.0f);
        CarModel.parent.Rotate(0, transform.eulerAngles.y, 0);
    }

    public void Steer(int dir, float amount)
    {
        rotate = (steering * dir) * amount;
    }
}
