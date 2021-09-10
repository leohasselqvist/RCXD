using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCXD : MonoBehaviour
{

    public float baseSpeed = 1;
    public float speedMod = 1;
    public float acceleration = 1;

    public Rigidbody2D rb;

    private float currentSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < baseSpeed) {
            currentSpeed += acceleration / 100;
        }
        else { currentSpeed = baseSpeed; }
        var movement_v = currentSpeed * speedMod;
        rb.velocity = new Vector2(0, movement_v);
        

    }
}
