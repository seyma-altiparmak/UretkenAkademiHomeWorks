using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private AudioSource gameAudio;
    private bool isPlaying { get; set; }
    public UIController()
    {
        isPlaying = false;
    }
    private void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }
    public void TogglePlayPause()
    {
        isPlaying = !isPlaying;
    }
   public void MusicControl()
    {
        TogglePlayPause();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("7");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
