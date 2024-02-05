using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController09 : MonoBehaviour
{
    [SerializeField] GameObject StopScreen;
    public void ContinueGame()
    {
        Time.timeScale = 1;
        StopScreen.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        StopScreen.SetActive(true);
    }
}
