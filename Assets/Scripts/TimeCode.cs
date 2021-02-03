using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Updates the text next to the slider to the current time.
/// </summary>
public class TimeCode : MonoBehaviour
{
    public Text text;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        text.text = (slider.value * 60) + "/60";
    }
}
