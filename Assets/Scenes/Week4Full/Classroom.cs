using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classroom : MonoBehaviour
{
    private Light lightClass;
    private GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        lightClass = GameObject.Find("lightWS").GetComponent<Light>();
        cube = GameObject.FindGameObjectWithTag("light");
    }

    // Update is called once per frame
    void Update()
    {
        //1
        print(Input.GetKeyDown(KeyCode.A));
        print(Input.GetKeyUp(KeyCode.A));
        if (Input.GetKeyDown(KeyCode.Space)) { lightClass.intensity = 1000; lightClass.color = Color.red; }
        else { lightClass.intensity = 100; lightClass.color = Color.white; }

        //2
        print("Horizontal : " + Input.GetAxis("Horizontal"));
        print("Vertical : " + Input.GetAxis("Vertical"));
        cube.SetActive(false);

        //4
        Physics.Raycast(Vector3.zero, Vector3.forward, out RaycastHit hitInfo, 10f);
        Debug.DrawLine(cube.transform.position, cube.transform.position + new Vector3(0, 10, 0), Color.green);
        Debug.DrawRay(cube.transform.position, cube.transform.position + new Vector3(10, 0, 0), Color.red);
    }
}
