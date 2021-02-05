using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls the travel of each planet.
/// </summary>
public class Orbit : MonoBehaviour
{
    // Variables

    [Range(-1, 1)] private float playSpeed = 0;
    private float angle = 0;
    private float orbitAge = 0;
    public float radius; // How far away an object is from the center of the screen.
    public float speed; // How many times an object will spin over the span of a minute.

    public Transform barycenter; // Defines the object a planet is orbiting around.
    public UI ui;

    public AnimationCurve animationCurve;

    public Slider slider;

    void Start()
    {
        angle = Random.Range(-360, 360);
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * playSpeed;
        // The amount of time passed is recorded.
        UpdatePosition(angle);
    }

    public void UpdatePosition(float playhead)
    {
        // Spins the object around an orbit and rotates it along its axis over a period of sixty seconds.
        // The begining and end positions are the same, creating a loop.
        orbitAge = (playhead * speed);
        Vector3 offset = new Vector3();
        offset.x = Mathf.Sin(orbitAge) * radius;
        offset.z = Mathf.Cos(orbitAge) * radius;
        transform.position = barycenter.position + offset;
    }

    public void ChangePlaySpeed(float value)
    {
        playSpeed = value;
    }
}
// Orbits
// Polar Planet: 1
// Continental Planet: 2
// Temperate Planet: 3
// Tropical Planet: 4
// Arid Planet: 5
// Outer Moon: 6
// Inner Moon: 7

// Rotations
// Inner Moon 73
// Outter Moon 146
// Arid Planet 219
// Tropical Planet 292
// Temperate Planet 365
// Continental Planet 438
// Polar Planet 511
// Sun 594