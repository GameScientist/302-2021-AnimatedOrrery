using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControls : MonoBehaviour
{
    // Transform parameters.
    float pitch = 0;
    float targetPitch = 45;
    float yaw = 0;
    float targetYaw = 0;
    float dollyDis = 240;
    float targetDollyDis;

    // Sensitivity Controls
    //private float mouseSensitivityX = 1;
    private float mouseSensitivityY = 1;
    private float mouseScrollMultiplier = 24;

    

    private Camera cam;

    

    public Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        // The scroll wheel controls the distance between the subject and the camera.
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        targetDollyDis += scroll * mouseScrollMultiplier;
        targetDollyDis = Mathf.Clamp(targetDollyDis, 30f, 240f);

        dollyDis = Slide.Slider(dollyDis, targetDollyDis, .05f);

        cam.transform.localPosition = new Vector3(0, dollyDis, -dollyDis);
    }
}
