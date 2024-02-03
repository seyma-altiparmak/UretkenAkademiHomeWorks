using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    public static int money = 0;
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GameObject.Find("CoinCounterTxt").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        StartCoroutine(ChangeTMP());
    }

    IEnumerator ChangeTMP()
    {
        tmp.text = money + "$";
        yield return new WaitForSeconds(1f); 

    }
}
