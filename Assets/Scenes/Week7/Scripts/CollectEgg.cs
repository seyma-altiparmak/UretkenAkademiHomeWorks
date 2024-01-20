using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEgg : MonoBehaviour
{
    [SerializeField] private AudioClip gýtVoice;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Egg egg))
        {
            AudioSource.PlayClipAtPoint(gýtVoice, other.transform.position);
            this.gameObject.SetActive(false);
        }
    }
}
