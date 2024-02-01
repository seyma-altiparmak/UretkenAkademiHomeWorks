using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTimeController : MonoBehaviour
{
    [SerializeField]
    private static Material sunnySkybox,nightSkybox;
    DayController dayController;

    private void Awake()
    {
        dayController = GameObject.Find("DayController").GetComponent<DayController>();
        sunnySkybox = dayController.sunnySkybox;
        nightSkybox = dayController.nightSkybox;
    }

    public static void ChangeSkybox(bool isSunny)
    {
        if (isSunny) RenderSettings.skybox = sunnySkybox;
        else RenderSettings.skybox = nightSkybox;
    }

    public static void ChangeSong(bool isSunny)
    {
        
    }
}
