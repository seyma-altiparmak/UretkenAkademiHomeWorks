using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerCar : MonoBehaviour
{
    public TextMeshProUGUI textmeshbuy;
    public void OnTriggerEnter(Collider colision) {
        if(colision.TryGetComponent(out Car car))
        {
            textmeshbuy.text = "Sancaktepe Oyun Akademisi 2023 CARS";
        }
        else { }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Car c))
        {
            textmeshbuy.text = " ";
        }
        else { }
    }
}
