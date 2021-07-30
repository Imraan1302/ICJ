using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider pass)
    {
        if (pass.gameObject.CompareTag("Player"))
        {
            Debug.Log("You may proceed");
            gameObject.SetActive(false);
        }
    }
}
