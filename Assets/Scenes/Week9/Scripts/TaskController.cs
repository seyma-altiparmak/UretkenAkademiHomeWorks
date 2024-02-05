using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    public Button takeTaskButton; 
    DayController dayController;
    Tasks task;
    AudioSource alkis;

    [HideInInspector]public bool isTaked =false;
    [SerializeField] GameObject[] tasksScreens;
    //Japon:
    public GameObject[] JaponPray;
    private int currentPrayIndex = 0;

    public GameObject[] DrumSound;
    private int currentDrumIndex = 0;

    public GameObject[] Apple;
    private int currentAppleIndex = 0;

    public GameObject[] Beg;
    private int currentBeggingIndex = 0;

    public GameObject endTask;
    private void Awake()
    {
        dayController = GameObject.Find("DayController").GetComponent<DayController>();
        alkis = GameObject.Find("Alkýs").GetComponent<AudioSource>();
        task = GameObject.Find("Tasker").GetComponent<Tasks>();
    }

    public void TakeTask()
    {
        if (!isTaked)
        {
            TakeTaskW_Day(dayController.dateTime);
            takeTaskButton.interactable = false;
            isTaked = true;
        }
        else
        {
            // Optionally, you can add some feedback or a message for the player that they already took a task.
        }
    }
    
IEnumerator WaitForAnimAndClose(int date)
    {
        yield return new WaitForSeconds(.1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        alkis = JaponPray[currentPrayIndex].GetComponentInChildren<AudioSource>();
        JaponPray[currentPrayIndex].SetActive(true);
        currentPrayIndex++;
        alkis.PlayOneShot(alkis.clip);
        if (currentPrayIndex == 5)
        {
            tasksScreens[date - 1].SetActive(false);
        }
    
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs
       

        // Deactivate the current task screen

    }

    IEnumerator WaitForAnimAndClose_Drum(int date)
    {
        yield return new WaitForSeconds(.1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        alkis = DrumSound[currentDrumIndex].GetComponent<AudioSource>();
        DrumSound[currentDrumIndex].SetActive(true);
        currentDrumIndex++;
        alkis.PlayOneShot(alkis.clip);
        if (currentDrumIndex == 5)
        {
            tasksScreens[date - 1].SetActive(false);
        }
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs


        // Deactivate the current task screen

    }

    IEnumerator WaitForAnimAndClose_Apple(int date)
    {
        yield return new WaitForSeconds(.1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        alkis = Apple[currentAppleIndex].GetComponent<AudioSource>();
        Apple[currentAppleIndex].SetActive(true);
        currentAppleIndex++;
        alkis.PlayOneShot(alkis.clip);
        if (currentAppleIndex == 5)
        {
            tasksScreens[date - 1].SetActive(false);
        }

        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs

    }

    IEnumerator WaitForAnimAndClose_Want(int date)
    {
        yield return new WaitForSeconds(.1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        alkis = Beg[currentBeggingIndex].GetComponent<AudioSource>();
        Beg[currentBeggingIndex].SetActive(true);
        currentBeggingIndex++;
        alkis.PlayOneShot(alkis.clip);
        if (currentBeggingIndex == 4)
        {
            tasksScreens[date - 1].SetActive(false);
        }
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs

    }

    public void TakeTaskW_Day(int date)
    {
        if(!(tasksScreens[date-1].activeInHierarchy)) tasksScreens[date - 1].SetActive(true);
        
        switch (date)
        {
            case 1:
                if (Tasks.isJapanDone)
                {
                    MoneyController.money += 100;
                    isTaked = true;
                    StartCoroutine(WaitForAnimAndClose(date));

                }
                break;
            case 2:
                if (Tasks.isDrumPlay)
                {
                    MoneyController.money += 200;
                    isTaked = true;
                    StartCoroutine(WaitForAnimAndClose_Drum(date));

                }
                break;
            case 3:
                if (Tasks.isCollectApple)
                {
                    MoneyController.money += 500;
                    isTaked = true;
                    StartCoroutine(WaitForAnimAndClose_Apple(date));

                }
                break;
            case 4:
                if (Tasks.isWantSomething)
                {
                    MoneyController.money += 1000;
                    isTaked = true;
                    StartCoroutine(WaitForAnimAndClose_Want(date));
                    

                }
                break;
            default:
                endTask.SetActive(true);
                break;
        }
    }

}

    
