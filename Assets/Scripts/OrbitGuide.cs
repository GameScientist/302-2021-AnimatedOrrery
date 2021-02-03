using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Builds a line to represent the orbit of each planet.
/// </summary>
public class OrbitGuide : MonoBehaviour
{
    // Variables
    public float radius; // How far away an object is from the center of the screen.
    public Transform barycenter;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the positions of all of the points within a line to create a circle.
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var points = new Vector3[360];
        for (int i = 0; i < 360; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / 360);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }
        lineRenderer.SetPositions(points);
    }

    void Update() // Makes the circle follow an object.
    {
        transform.position = barycenter.position;
    }
}
