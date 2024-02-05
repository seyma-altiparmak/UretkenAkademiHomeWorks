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

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(100f);
    }
    
IEnumerator WaitForAnimAndClose(int date)
    {
        yield return new WaitForSeconds(.1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        JaponPray[currentPrayIndex].SetActive(true);
        currentPrayIndex++;
        if (currentPrayIndex == 5)
        {
            tasksScreens[date - 1].SetActive(false);
        }
     AudioSource audioSource = JaponPray[currentPrayIndex].GetComponentInChildren<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitUntil(() => !audioSource.isPlaying);

        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs
       

        // Deactivate the current task screen

    }

    IEnumerator WaitForAnimAndClose_Drum(int date)
    {
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        DrumSound[currentDrumIndex].SetActive(true);
        AudioSource audioSource = DrumSound[currentDrumIndex].GetComponentInChildren<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitUntil(() => !audioSource.isPlaying);
        currentDrumIndex++;
        if (currentDrumIndex == 5)
        {
            tasksScreens[date - 1].SetActive(false);
        }
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs


        // Deactivate the current task screen

    }

    IEnumerator WaitForAnimAndClose_Apple(int date)
    {
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        Apple[currentAppleIndex].SetActive(true);
        AudioSource audioSource = Apple[currentAppleIndex].GetComponentInChildren<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitUntil(() => !audioSource.isPlaying);
        currentAppleIndex++;
        if (currentAppleIndex == 5)
        {
            tasksScreens[date - 1].SetActive(false);
        }
        
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs

    }

    IEnumerator WaitForAnimAndClose_Want(int date)
    {
        yield return new WaitForSeconds(1f); // Adjust the duration based on your needs

        //JaponPray Index Cause error:
        Beg[currentBeggingIndex].SetActive(true);
        AudioSource audioSource = Beg[currentBeggingIndex].GetComponentInChildren<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitUntil(() => !audioSource.isPlaying);

        currentBeggingIndex++;
        if (currentAppleIndex == 5)
        {
            tasksScreens[date - 1].SetActive(false);
        }
        alkis.PlayOneShot(alkis.clip);
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
                takeTaskButton.interactable = false;
                endTask.SetActive(true);
                break;
        }
    }

}

    
