using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager8 : MonoBehaviour
{
    GameObject character;
    MeshFilter mainObject;
    MeshFilter cubeObject, sphereObject, cylinderObject;
    [SerializeField] Button cubeButton, sphereButton, cylinderButton;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameUI;
    public bool isActive = false;
    [HideInInspector] public static int timer = 100;
    [SerializeField] private TextMeshProUGUI timerTxt;

    private void Awake()
    {
        cubeObject = GameObject.Find("Cube").GetComponent<MeshFilter>();
        sphereObject = GameObject.Find("Sphere").GetComponent<MeshFilter>();
        cylinderObject = GameObject.Find("Capsule").GetComponent<MeshFilter>();
    }
    private void Start()
    {
        Time.timeScale = 0;
        mainObject = GameObject.Find("Character").GetComponent<MeshFilter>();
        character = GameObject.Find("Character");
        
    }
    private void Update()
    {
        if (BasicMoveController.isContinue)
        {
            timerTxt.text = timer.ToString();
            StartCoroutine(TimerController());
        }
        else
        {
            cubeButton.interactable = true;
            sphereButton.interactable = true;
            cylinderButton.interactable = true;
        }
    }

    IEnumerator TimerController()
    {
        timer--;
        yield return new WaitForSeconds(50f);
    }

    public void StartButton()
    {
        Time.timeScale = 1; //baþlat
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        isActive = true;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void MusicManager()
    {
        GameObject musicController = GameObject.Find("MusicController");
        if (musicController.GetComponent<AudioSource>().volume != 0)
            musicController.GetComponent<AudioSource>().volume = 0;
        else musicController.GetComponent<AudioSource>().volume = 100;
    }

    public void Remesh(int i)
    {
        switch (i)
        {
            case 0:
                mainObject.mesh = cubeObject.mesh;
                character.transform.position += new Vector3(0, 1f, 0);
                cubeButton.interactable = false;
                timer += 10;
                break;
            case 1:
                mainObject.mesh = sphereObject.mesh;
                character.transform.position += new Vector3(0, 1f, 0);
                sphereButton.interactable = false;
                timer += 20;
                break;
            case 2:
                mainObject.mesh = cylinderObject.mesh;
                character.transform.position += new Vector3(0, 1f, 0);
                cylinderButton.interactable = false;
                timer += 20;
                break;
            default:
                print("Nothing New!");
                break;
        }
    }

}
