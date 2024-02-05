using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public static bool isJapanDone,
        isDrumPlay, isCollectApple, isWantSomething = false;
    public AudioClip JaponClip;
    private TaskController tc;
    private void Start()
    {
        tc = GameObject.Find("TaskController").GetComponent<TaskController>();
    }
    public void JapanesseHousePray()
    {
        isJapanDone = true;
        tc.TakeTaskW_Day(1);
    }

    public void PlayDrum()
    {
        isDrumPlay = true;
        tc.TakeTaskW_Day(2);
    }

    public void CollectApple()
    {
        isCollectApple = true;
        tc.TakeTaskW_Day(3);
    }

    public void WantSomething()
    {
        isWantSomething = true;
        tc.TakeTaskW_Day(4);
    }
}
