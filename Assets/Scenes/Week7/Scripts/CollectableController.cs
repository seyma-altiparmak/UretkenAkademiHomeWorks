using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableController : MonoBehaviour
{
    public static int eggCount;
    public GameObject eggCountDisplay;
    public GameObject eggEndDisplay;
   
    void Update()
    {
        eggCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + eggCount;
        eggEndDisplay.GetComponent<TextMeshProUGUI>().text = "" + eggCount;
    }
}
