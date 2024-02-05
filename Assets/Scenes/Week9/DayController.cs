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
    TaskController taskController;

    private void Awake()
    {
        skyboxTimeController = GetComponent<SkyboxTimeController>();
        taskController = GameObject.Find("TaskController").GetComponent<TaskController>();
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

        StartCoroutine(DayControl());
    }

    IEnumerator DayControl()
    {
        if (currentTime < 0.50f) SunAndMoonController(true);
        else SunAndMoonController(false);

        yield return new WaitForSeconds(5f);
    }

    void SunAndMoonController(bool isSunny)
    {
        skyboxTimeController.ChangeSkybox(isSunny);
        skyboxTimeController.ChangeSong(isSunny);
    }

    void UpdateDate()
    {
        dateTime++;
        dateTxt.text = "Day - " + dateTime;
        StartNewDay();
    }

    public void StartNewDay()
    {
        // Reset task status for the new day
        taskController.isTaked = false;

        // Enable the task button
        taskController.takeTaskButton.interactable = true;

        // Optionally, update the date or any other relevant information
        // ...
    }
}