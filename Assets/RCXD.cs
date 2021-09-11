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

        if (steeringAmount != 0 && prevSteeringAmount != steeringAmount)
        {
            transform.GetChild(0).GetComponent<SkidmarkHandler>().toggleSkidmarks(true);
        }
        else if ( prevSteeringAmount == steeringAmount ) { }
        else
		{
            transform.GetChild(0).GetComponent<SkidmarkHandler>().toggleSkidmarks(false);
        }


        prevSteeringAmount = steeringAmount;
    }
}
