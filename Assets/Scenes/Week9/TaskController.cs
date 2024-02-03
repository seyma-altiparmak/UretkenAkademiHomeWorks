using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    DayController dayController;
    Tasks task;
    private void Awake()
    {
        dayController = GameObject.Find("DayController").GetComponent<DayController>();
        task = GameObject.Find("Tasker").GetComponent<Tasks>();
    }

    void TakeTask(bool isTaked)
    {
        if (!isTaked)
        {
            TakeTaskW_Day(dayController.dateTime);
        }
        else
        {

        }
    }

    void TakeTaskW_Day(int date)
    {
        switch (date)
        {
            case 1:
                if (task.JapanesseHousePray())
                {
                    MoneyController.money += 10;

                }
                break;
            case 2:
                if (task.PlayDrum())
                {
                    MoneyController.money += 20;

                }
                break;
            case 3:
                if (task.CollectApple())
                {
                    MoneyController.money += 20;

                }
                break;
            case 4:
                if (task.WantSomething())
                {
                    MoneyController.money += 50;

                }
                break;
            default:
                break;
        }
    }

}

    
