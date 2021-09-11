using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject follow_player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - follow_player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow_player.transform.position + offset;
    }
}
