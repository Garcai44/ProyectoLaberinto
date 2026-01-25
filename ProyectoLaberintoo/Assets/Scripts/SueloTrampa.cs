using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloTrampa : MonoBehaviour
{
  
    public Transform spawnPoint;
    public AudioSource audioSource;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entró");

        if (other.CompareTag("Player"))
        {
            audioSource.Play();

            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                
                cc.enabled = false;                // desactiva temporalmente
                other.transform.position = spawnPoint.position;
                cc.enabled = true;                 // vuelve a activar
            }
        }
    }
   
    
}
