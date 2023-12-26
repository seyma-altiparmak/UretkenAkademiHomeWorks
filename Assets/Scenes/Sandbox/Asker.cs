using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Asker : MonoBehaviour
{
    protected Questions question;
    protected TextMeshProUGUI tmpro;
    private bool isDone;
    private int i = 0;
    private void Awake()
    {
        question = GameObject.Find("QuestionManager").GetComponent<Questions>();
        tmpro = GameObject.Find("TextQuestion").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Student student))
        {
            question.questions[i] = tmpro.text;
            i++;
            isDone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Student student)&&isDone)
        {
            isDone = !isDone;
        }
    }
}
