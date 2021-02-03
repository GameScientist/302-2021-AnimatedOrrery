using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controls the visibility of UI elements.
/// </summary>
public class UI : MonoBehaviour
{
    public Transform focus;
    public Transform description;
    public Transform playback;
    public Transform playIcon;
    public Transform pauseIcon;
    private bool visible = false;
    private bool playing = true;
    public int playState = 3;
    private AudioSource confirm;

    // Start is called before the first frame update
    void Start()
    {
        confirm = GetComponent<AudioSource>(); // Each time an option is picked, a chime is played.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleVisibility() // Toggles the visibility of every UI element other than this one.
    {
        if (visible) // If the UI is visible, it will become invisibile.
        {
            focus.gameObject.SetActive(false);
            description.gameObject.SetActive(false);
            playback.gameObject.SetActive(false);
            visible = false;
        }

        else // If the UI is invisible, it will become visibile.
        {
            focus.gameObject.SetActive(true);
            description.gameObject.SetActive(true);
            playback.gameObject.SetActive(true);
            visible = true;
        }

        confirm.Play();
    }

    public void SkipToStart() // Sets the playhead at the beginning of the slider.
    {
        playState = 0;
        playing = false;
        playIcon.gameObject.SetActive(true);
        pauseIcon.gameObject.SetActive(false);
        confirm.Play();
    }

    public void Rewind() // Reverses the playhead two times as fast.
    {
        playing = false;
        playIcon.gameObject.SetActive(true);
        pauseIcon.gameObject.SetActive(false);
        playState = 1;
        confirm.Play();
    }

    public void TogglePlay()
    {
        if (playing) // If the orrery is playing, this will pause it.
        {
            playState = 2;
            playing = false;
            playIcon.gameObject.SetActive(true);
            pauseIcon.gameObject.SetActive(false);
        }

        else // If the orrery is paused, this will play it.
        {
            playing = true;
            playIcon.gameObject.SetActive(false);
            pauseIcon.gameObject.SetActive(true);
            playState = 3;
        }
        confirm.Play();
    }

    public void FastForward() // Plays the playhead two times as fast.
    {
        playing = false;
        playIcon.gameObject.SetActive(true);
        pauseIcon.gameObject.SetActive(false);
        playState = 4;
        confirm.Play();
    }

    public void SkipToEnd() // Sets the playhead at the end of the slider.
    {
        playing = false;
        playIcon.gameObject.SetActive(true);
        pauseIcon.gameObject.SetActive(false);
        playState = 5;
        confirm.Play();
    }
}
