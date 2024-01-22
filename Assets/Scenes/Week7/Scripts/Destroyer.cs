using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;
   
    void Update()
    {
        parentName = transform.name;
        StartCoroutine((DestroyClone()));
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(10f);
        if (parentName == "Section(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
