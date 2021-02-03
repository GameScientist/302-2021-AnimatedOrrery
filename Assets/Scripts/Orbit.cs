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
    [Range(0, 1)] private float percent = 0; // Represents the current position of the cursor within the timeline.

    public int playState = 3;
    private float cycleLength = 60;
    private float playhead = 0;
    private float orbitAge = 0;
    public float radius; // How far away an object is from the center of the screen.
    public float speed; // How many times an object will spin over the span of a minute.

    public Transform barycenter; // Defines the object a planet is orbiting around.
    public UI ui;

    public AnimationCurve animationCurve;

    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        switch (ui.playState) // The passage of time is determined by the script's play state.
        {
            case 0: // Skip to Start
                playhead = 0;
                break;

            case 1: // Rewind
                playhead -= Time.deltaTime*2;
                transform.Rotate(0, (183960 - (26280 * speed)) * -2, 0, Space.Self);
                break;

            case 2: // Pause
                break;

            case 3: // Play
                playhead += Time.deltaTime;
                transform.Rotate(0, ((183960 - (26280 * speed))), 0, Space.Self);
                break;

            case 4: // Fast Forward
                playhead += Time.deltaTime * 2;
                transform.Rotate(0, (183960 - (26280 * speed)) * 2, 0, Space.Self);
                break;

            case 5: // Skip to End
                playhead = 1;
                break;
        }
        // The amount of time passed is recorded.
        percent = playhead / cycleLength;
        percent = Mathf.Clamp(percent, 0, 1);
        UpdatePosition(percent);
        // Percent must be between 0% and 100%.
        if (percent <= 0) percent = 0;
        if (percent >= 1) percent = 1;
        slider.SetValueWithoutNotify(percent);
    }

    public void UpdatePosition(float percent)
    {
        // Spins the object around an orbit and rotates it along its axis over a period of sixty seconds.
        // The begining and end positions are the same, creating a loop.
        orbitAge = percent * speed * 2 * Mathf.PI;
        Vector3 offset = new Vector3();
        offset.x = Mathf.Sin(orbitAge) * radius;
        offset.z = Mathf.Cos(orbitAge) * radius;
        transform.position = barycenter.position + offset;
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