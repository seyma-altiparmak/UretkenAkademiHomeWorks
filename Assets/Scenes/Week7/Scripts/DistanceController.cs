using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceController : MonoBehaviour
{
    public GameObject distanceDisplay;
    public GameObject distanceEndDisplay;
    public static int distance;
    public bool addingDistance = false;

    void Update()
    {
        if(addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    IEnumerator AddingDistance()
    {
        distance += 0;
        distanceDisplay.GetComponent<TextMeshProUGUI>().text = "" + distance;
        distanceDisplay.GetComponent<TextMeshProUGUI>().text = "" + distance;
        yield return new WaitForSeconds(0.25f);
        addingDistance = false;
    }
}
