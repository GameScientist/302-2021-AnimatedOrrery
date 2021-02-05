using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySpeedText : MonoBehaviour
{
    private Text text;
    private float speed;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    public void DisplaySpeed(float value)
    {
        speed = (int)(value * 100f);
        text.text = speed.ToString() + "%";
    }
}
