using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidmarkHandler : MonoBehaviour
{
    public GameObject BLW;
    public GameObject BRW;
    public GameObject TLW;
    public GameObject TRW;
    public bool visSkidmarks = false;

    private GameObject[] wheels;

    void Start()
    {
        wheels = new GameObject[] {BLW, BRW, TLW, TRW };
    }

    // Update is called once per frame
    public void toggleSkidmarks(bool state)
    {
        foreach(GameObject wheel in wheels)
		{
            wheel.gameObject.GetComponent<TrailRenderer>().emitting = state;
            visSkidmarks = state;
		}
    }
}
