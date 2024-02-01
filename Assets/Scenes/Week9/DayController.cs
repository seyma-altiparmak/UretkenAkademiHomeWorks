using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayController : MonoBehaviour
{
    public float dayLengthInSeconds = 10f;
    private float currentTime = 0f;
    private int dateTime = 0;
    [SerializeField] TextMeshProUGUI dateTxt;
    public Material sunnySkybox, nightSkybox;

    void Update()
    {
        currentTime += Time.deltaTime / dayLengthInSeconds;

        if (currentTime >= 1f)
        {
            currentTime = 0f;
            UpdateDate();
        }
        print("devam");
        if (currentTime < 0.75f) SunAndMoonController(true);
        else SkyboxTimeController.ChangeSkybox(false);
    }

    void SunAndMoonController(bool isSunny)
    {
        print("deiþtim");
        SkyboxTimeController.ChangeSkybox(isSunny);
        SkyboxTimeController.ChangeSong(isSunny);
    }

    void UpdateDate()
    {
        dateTime++;
        dateTxt.text = "Date - " + dateTime;
    }
}
