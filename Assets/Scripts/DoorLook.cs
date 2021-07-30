using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLook : MonoBehaviour
{
    public AudioSource DeathSound;

    private void OnTriggerEnter(Collider scare)
    {
        if (scare.gameObject.CompareTag("Door"))
        {
            DeathSound.Play();
            Debug.Log("Die");
        }
    }
}
