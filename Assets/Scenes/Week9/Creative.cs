using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creative : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float fadeSpeed = 1f;

    private void Start()
    {
        // Destroy the GameObject after a certain time
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        // Move the GameObject upward
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Fade out the GameObject
        Color currentColor = GetComponent<SpriteRenderer>().color;
        float newAlpha = Mathf.Lerp(currentColor.a, 0f, fadeSpeed * Time.deltaTime);
        GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        if (Time.deltaTime == .5f) Destroy(gameObject);
    }
}
