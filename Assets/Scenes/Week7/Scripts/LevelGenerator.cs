using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject[] sec;
    private int zPosition;
    private bool isCreating = false;
    private int secNumber;

    private void Update()
    {
        if (!isCreating)
        {
            isCreating = true;
            StartCoroutine(Generate());

        }
    }

    IEnumerator Generate()
    {
        secNumber = Random.Range(0,3);
        Instantiate(sec[secNumber], new Vector3(0,0,zPosition),Quaternion.identity);
        zPosition += 50;

        yield return new WaitForSeconds(2f);

        isCreating = false;
    }
}
