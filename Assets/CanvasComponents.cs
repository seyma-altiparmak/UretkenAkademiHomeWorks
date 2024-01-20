using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasComponents : MonoBehaviour
{
    //Restart & Next Level için ayný komponenti kullanýyorum.
   public void UI_RestartButton()
    {
        int getIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(getIndexScene);
        Time.timeScale = 1;
    }

}
