using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public AudioSource audioSource;
    public TMP_Text textoUI;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entró");

        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            textoUI.text = "Has superado el laberinto, enhorabuena!";
}
    }
}
