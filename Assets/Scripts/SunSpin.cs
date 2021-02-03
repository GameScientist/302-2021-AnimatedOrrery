using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpin : MonoBehaviour
{
    // Rotates the sun around its axis.
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime, 0, Space.Self);
    }
}
