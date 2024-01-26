using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMoveController : MonoBehaviour
{
   
    public float moveSpeed =3f;
    public Vector3 rotationSpeed;
    private SphereCollider sp;
    private UIManager8 ui;
    public static bool isContinue = false;
    [SerializeField] private GameObject endTimer;

    private void Start()
    {
        sp = GetComponent<SphereCollider>();
        rotationSpeed = new Vector3(0, 250f, 0);
        ui = GameObject.Find("UIController").GetComponent<UIManager8>();
    }
    void Update()
    {
        MoveCharacter();
        Look();
        StartCoroutine(Failed());
    }

    IEnumerator Failed()
    {
        yield return new WaitForSeconds(5f);
        if(UIManager8.timer < 0)
        {
            SceneManager.LoadScene(0);
            UIManager8.timer = 5000;
        }
    }

    void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f,  verticalInput * moveSpeed * Time.deltaTime);
        
        transform.Translate(movement);
        sp.transform.Translate(movement);
    }

    void Look()
    {
        float rotationInput = Input.GetAxis("Rotate");

        float rotationAmount = rotationInput * rotationSpeed.y * Time.deltaTime;

        transform.Rotate(Vector3.up, rotationAmount, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out StartTimer st))
        {
            UIManager8.timer = 5000;
            isContinue = true;
            if (endTimer.activeSelf)
            {
                endTimer.SetActive(false);
            }
        }
        else if(other.gameObject.TryGetComponent(out EndTimer et))
        {
            isContinue = false;
            endTimer.SetActive(true);
        }
        else if(other.gameObject.TryGetComponent(out EndGame eg))
        {
            isContinue = false;
        }
        else if(other.gameObject.TryGetComponent(out Timehealer th))
        {
            UIManager8.timer += 100;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.TryGetComponent(out TimeEnder te))
        {
            UIManager8.timer -= 100;
            Destroy(other.gameObject);
        }
        else
        {
            print("Undefined Object");
        }
    }
}
