using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCXD : MonoBehaviour
{

    public float base_speed = 1f;
    public float acceleration = 0.01f;
    public float max_speed = 10f;
    public float handling = 5f;


    private float prevSteeringAmount = 0f;

    public Rigidbody2D rb;

    private float rotationAngle = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<SkidmarkHandler>().toggleSkidmarks(false);
    }

    // Update is called once per frame
    void Update()
    {
        var steeringAmount = Input.GetAxis("Horizontal");
        Vector2 speedVector = transform.up * base_speed;
        rb.AddForce(speedVector, ForceMode2D.Force);
        if (base_speed < max_speed) { base_speed += acceleration; }


        rotationAngle -= steeringAmount * handling;

        rb.MoveRotation(rotationAngle);


        // Even if the logic here seems overcomplex, it is to preserve performance.
        // Rather than running "transform.GetChild(0).GetComponent<SkidmarkHandler>().toggleSkidmarks(true);" several tims a second,
        // this code checks if the value of the steering input has changed, which helps with performance and lowers the overall fetches.
        if (steeringAmount != 0 && prevSteeringAmount != steeringAmount)  // When you first pressing the button, turn on skidmarks
        {
            transform.GetChild(0).GetComponent<SkidmarkHandler>().toggleSkidmarks(true);
        }
        else if ( prevSteeringAmount == steeringAmount ) { }  // Once you've started holding down the button, do nothing.
        else  // When you release the button, turn off skidmarks.
        {
            transform.GetChild(0).GetComponent<SkidmarkHandler>().toggleSkidmarks(false);
        }


        prevSteeringAmount = steeringAmount;
    }
}
