using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLook : MonoBehaviour
{
    public AudioSource DeathSound;

    private void OnTriggerEnter(Collider scare)
    {
        if (scare.gameObject.CompareTag("Death Door"))
        {
            DeathSound.Play();
            Debug.Log("Die");
            Invoke("KillPlayer", 2.3f);
        }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene("GameOver");
    }
}
