using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayController : MonoBehaviour
{
    public float dayLengthInSeconds = 5f;
    private float currentTime = 0f;
    public int dateTime = 1;
    [SerializeField] TextMeshProUGUI dateTxt;
    public Material sunnySkybox, nightSkybox;
    SkyboxTimeController skyboxTimeController;

    private void Awake()
    {
        skyboxTimeController = transform.gameObject.GetComponent<SkyboxTimeController>();
        skyboxTimeController.ChangeSkybox(true);
    }

    void Update()
    {
        currentTime += Time.deltaTime / dayLengthInSeconds;

        if (currentTime >= 1f)
        {
            currentTime = 0f;
            UpdateDate();
        }
        print("devam");
        if (currentTime > 0.50f) SunAndMoonController(true);
        else SunAndMoonController(false);
    }

    void SunAndMoonController(bool isSunny)
    {
        print("deiþtim");
        skyboxTimeController.ChangeSkybox(isSunny);
        skyboxTimeController.ChangeSong(isSunny);
    }

    void UpdateDate()
    {
        dateTime++;
        dateTxt.text = "Day - " + dateTime;
    }
}
