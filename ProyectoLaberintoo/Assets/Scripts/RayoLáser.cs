using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoLáser : MonoBehaviour
{
 
    public float tiempoEncendido = 2f;
    public float tiempoApagado = 1f;

    public Transform spawnPoint;
    public Transform posicionJugador;
    public float radioSonido = 5f;

    private Collider col;
    private Renderer rend;
    public AudioSource audioSource;

    void Start()
    {
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();

        // Seguridad
        if (posicionJugador == null)
            posicionJugador = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(CicloLaser());
    }

    IEnumerator CicloLaser()
    {
        while (true)
        {
            // ENCENDIDO
            col.enabled = true;
            rend.enabled = true;

            if (audioSource != null &&
                Vector3.Distance(posicionJugador.position, transform.position) <= radioSonido)
            {
                audioSource.Play();
            }

            yield return new WaitForSeconds(tiempoEncendido);

            // APAGADO
            col.enabled = false;
            rend.enabled = false;

            if (audioSource != null)
                audioSource.Stop();

            yield return new WaitForSeconds(tiempoApagado);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                other.transform.position = spawnPoint.position;
                cc.enabled = true;
            }
        }
    }
}
