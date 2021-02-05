using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRigControl : MonoBehaviour
{
    // All of the planets referenced.
    public Transform ra;
    public Transform set;
    public Transform khonsu1;
    public Transform thoth1;
    public Transform hapi;
    public Transform khonsu2;
    public Transform thoth2;
    public Transform renenutet;
    public Transform khonsu3;
    public Transform thoth3;
    public Transform shu;
    public Transform khonsu4;
    public Transform thoth4;
    public Transform osiris;
    public Transform khonsu5;
    public Transform thoth5;

    public Transform subject; // The camera focuses on this location.
    public Text description;
    private AudioSource swoosh;
    private float pitch;
    private float targetPitch;
    private float yaw;
    private float targetYaw;
    private float mouseSensitivityX = 1;
    private float mouseSensitivityY = 1;

    // Start is called before the first frame update
    void Start()
    {
        swoosh = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2")) // Holding the right mouse button allows the player to change the camera.
        {
            // changing the pitch:
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            targetYaw += mouseX * mouseSensitivityX;
            targetPitch += mouseY * mouseSensitivityY;
        }
        transform.position = subject.position;
        yaw = Slide.Slider(yaw, targetYaw, .05f);
        transform.rotation = Quaternion.Euler(0, yaw, 0);


        // The user cannot flip the camera.
        if (targetPitch <= -89)
        {
            targetPitch = -89;
        }

        if (targetPitch >= 89)
        {
            targetPitch = 89;
        }

        pitch = Slide.Slider(pitch, targetPitch, .05f);
        yaw = Slide.Slider(yaw, targetYaw, .05f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }

    public void Focus(int planetID) // Switchs where the camera is focusing on and alters the text based on that area. These actions are accompinied by a sound effect.
    {
        switch (planetID)
        {
            case 0:
                subject = ra;
                description.text = "The central star of the Amun Galaxy, Ra. Similar to the sun of the Milky Way, it is large enough and warm enough to sustain life on other planets.";
                break;

            case 1:
                subject = set;
                description.text = "Being the closest to the sun, the majority of set is covered in scorching-hot deserts.";
                break;

            case 2:
                subject = khonsu1;
                description.text = "Being the closest to the sun, the majority of set is covered in scorching-hot deserts.";
                break;

            case 3:
                subject = thoth1;
                description.text = "Being the closest to the sun, the majority of set is covered in scorching-hot deserts.";
                break;

            case 4:
                subject = hapi;
                description.text = "Similar to Earth, most of Hapi is covered in water, possibly even more so! Floods are so frequent, that it makes one consider if this planet was a victim of climate change.";
                break;

            case 5:
                subject = khonsu2;
                description.text = "Similar to Earth, most of Hapi is covered in water, possibly even more so! Floods are so frequent, that it makes one consider if this planet was a victim of climate change.";
                break;

            case 6:
                subject = thoth2;
                description.text = "Similar to Earth, most of Hapi is covered in water, possibly even more so! Floods are so frequent, that it makes one consider if this planet was a victim of climate change.";
                break;

            case 7:
                subject = renenutet;
                description.text = "Much of Renenutet is occupied by dense forests and jungles, making it very hospitable...if it weren't for the infestation of snake-like aliens that roam the planet. These creatures will need to be contained before occupation is possible.";
                break;

            case 8:
                subject = khonsu3;
                description.text = "Much of Renenutet is occupied by dense forests and jungles, making it very hospitable...if it weren't for the infestation of snake-like aliens that roam the planet. These creatures will need to be contained before occupation is possible.";
                break;

            case 9:
                subject = thoth3;
                description.text = "Much of Renenutet is occupied by dense forests and jungles, making it very hospitable...if it weren't for the infestation of snake-like aliens that roam the planet. These creatures will need to be contained before occupation is possible.";
                break;

            case 10:
                subject = shu;
                description.text = "Shu very mountainous planet constantly undergoing strong winds. Tornados and hurricanes are very common on this planet, and are often strong enough to move mountains!";
                break;

            case 11:
                subject = khonsu4;
                description.text = "Shu very mountainous planet constantly undergoing strong winds. Tornados and hurricanes are very common on this planet, and are often strong enough to move mountains!";
                break;

            case 12:
                subject = thoth4;
                description.text = "Shu very mountainous planet constantly undergoing strong winds. Tornados and hurricanes are very common on this planet, and are often strong enough to move mountains!";
                break;

            case 13:
                subject = osiris;
                description.text = "Being the farthest planet from the sun, Osiris suffers from extremely cold tempertures. Even with these conditions, the lack of any life on this planet is very odd. Osiris should be migrated to with extreme caution!";
                break;

            case 14:
                subject = khonsu5;
                description.text = "Being the farthest planet from the sun, Osiris suffers from extremely cold tempertures. Even with these conditions, the lack of any life on this planet is very odd. Osiris should be migrated to with extreme caution!";
                break;

            case 15:
                subject = thoth5;
                description.text = "Being the farthest planet from the sun, Osiris suffers from extremely cold tempertures. Even with these conditions, the lack of any life on this planet is very odd. Osiris should be migrated to with extreme caution!";
                break;
        }
        swoosh.Play();
    }
}
