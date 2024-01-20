using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarController : MonoBehaviour
{
    private GameObject UI_Negative;
    private Vector3 inputController;
    private Vector3 hizController;
    public float drift = 10f; // Adjust this value to control the drift force
    float moveHorizontal;
    float moveVertical;
    Light lightDirect;
    TextMeshProUGUI tmp;
    float score;
    Vector3 startPoint;

    /*
     * Color Changer:
     */

    Color normal = new Color(
    (float)(0xFF) / 255f,
    (float)(0xE8) / 255f,
    (float)(0xBE) / 255f,
    1f
    );

    Color red = new Color(
        (float)(0xFF) / 255f,
        (float)(0x18) / 255f,
        (float)(0x00) / 255f,
        1f
        );

    private void Awake()
    {
        UI_Negative = GameObject.Find("UI_Negative");
        //Set Active - false part
        lightDirect = GameObject.Find("Directional Light").GetComponent<Light>();
        if (lightDirect != null) lightDirect.color = normal;
        if (UI_Negative != null) { UI_Negative.SetActive(false);}
        startPoint = new Vector3(0f, 0f, -260f);
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        inputController = new Vector3(moveHorizontal, 0, moveVertical);
        hizController += inputController * Time.fixedDeltaTime * .1f;
        //drift:
        if (Mathf.Abs(moveHorizontal) > 0.1f)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 driftForceDir = transform.right * moveHorizontal * drift;
                rb.AddForce(driftForceDir, ForceMode.Force);
            }
        }
        transform.position += hizController;
        score = (transform.position.z - startPoint.z)/10;
        tmp = GameObject.Find("Scorer").GetComponent<TextMeshProUGUI>();
        tmp.text = "Score " + score.ToString("F2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Engel engel))
        {
            print("engele carptým");
            if (UI_Negative != null) UI_Negative.SetActive(true);
            ScoreGenerator();
        }
        if (other.gameObject.TryGetComponent(out End end))
        {
            if (UI_Negative != null) UI_Negative.SetActive(true);
            ScoreGenerator();
        }
        if (other.gameObject.TryGetComponent(out Sinir sinir))
        {
            lightDirect.color = red;
            print("detected sinir.");
        }

    }
    float ScoreGenerator()
    {
        Time.timeScale = 0;
        score = (transform.position.z - startPoint.z)/10;
        tmp = GameObject.Find("TimeScore").GetComponent<TextMeshProUGUI>();
        tmp.text = "Score " + score.ToString("F2");
        return score;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Sinir sinir))
        {
            lightDirect.color = normal;
        }
    }
}
