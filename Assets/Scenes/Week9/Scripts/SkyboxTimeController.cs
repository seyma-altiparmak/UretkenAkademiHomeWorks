using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTimeController : MonoBehaviour
{

    [SerializeField]
    private Material sunnySkybox, nightSkybox;
    [SerializeField]
    private AudioClip sunny, night;
    DayController dayController;
    AudioSource audioController;

    private void Awake()
    {
        dayController = GameObject.Find("DayController").GetComponent<DayController>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioSource>();

        if (dayController.sunnySkybox != null)
            sunnySkybox = dayController.sunnySkybox;

        if (dayController.nightSkybox != null)
            nightSkybox = dayController.nightSkybox;
    }

    public void ChangeSkybox(bool isSunny)
    {
        Debug.Log("Changing Skybox: " + (isSunny ? sunnySkybox.name : nightSkybox.name));

        if (isSunny)
            RenderSettings.skybox = sunnySkybox;
        else
            RenderSettings.skybox = nightSkybox;
        DynamicGI.UpdateEnvironment();

    }

    public void ChangeSong(bool isSunny)
    {
        if ((isSunny && audioController.clip != sunny) || (!isSunny && audioController.clip != night))
        {
            if (isSunny)
                audioController.clip = sunny;
            else
                audioController.clip = night;

            // Play the audio only if it's not already playing
            if (!audioController.isPlaying)
            {
                audioController.Play();
            }

        }

    }
}
