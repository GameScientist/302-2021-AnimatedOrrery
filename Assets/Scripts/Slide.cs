using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public static float Slider(float current, float target, float percentLeftAfter1Second) // The camera eases into new positions.
    {
        float p = 1 - Mathf.Pow(percentLeftAfter1Second, Time.deltaTime);
        if (p < 0) p = 0;
        if (p > 1) p = 1;

        return (target - current) * p + current;
    }
}
