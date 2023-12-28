using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private GameObject UI_Positive,UI_Negative;
    private Vector3 inputController;
    private Vector3 hizController;
    public float drift = 10f; // Adjust this value to control the drift force
    float moveHorizontal;
    float moveVertical;
    private void Awake()
    {
        UI_Positive = GameObject.Find("UI_Positive");
        UI_Negative = GameObject.Find("UI_Negative");
        //Set Active - false part
        if (UI_Positive != null && UI_Negative != null)
        {
            UI_Positive.SetActive(false);
            UI_Negative.SetActive(false);
        }
    }
    void Start()
    {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Engel engel))
        {
            print("engele carptým");
            if(UI_Negative != null)UI_Negative.SetActive(true);
        }
        if(other.gameObject.TryGetComponent(out End end))
        {
            if(UI_Positive != null)UI_Positive.SetActive(true);
        }
    }
}
