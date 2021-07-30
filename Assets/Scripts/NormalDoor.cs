using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider pass)
    {
        if (pass.gameObject.CompareTag("Player"))
        {
            
            gameObject.SetActive(false);
        }
    }
}
