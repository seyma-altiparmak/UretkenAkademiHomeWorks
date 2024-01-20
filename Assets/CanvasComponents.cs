using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasComponents : MonoBehaviour
{
    //Restart & Next Level i�in ayn� komponenti kullan�yorum.
   public void UI_RestartButton()
    {
        int getIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(getIndexScene);
        Time.timeScale = 1;
    }

}
