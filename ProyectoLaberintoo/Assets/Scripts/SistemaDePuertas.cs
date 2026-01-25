using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SistemaDePuertas : MonoBehaviour
{
    public MovimientoPuerta puertaRoja;
    public MovimientoPuerta puertaVerde;
    public MovimientoPuerta puertaAzul; 

    public Transform spawnPoint;
    public Canvas detectedCanvas;
    public TMP_Text textoUI;
    public AudioSource audioSource;

    private bool rojaAbierta;
    private bool verdeAbierta;
    private bool azulAbierta;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        detectedCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        detectedCanvas.gameObject.SetActive(false);

        if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f))
            return;

        // INTERRUPTOR ROJO
        if (hit.collider.CompareTag("InterruptorRojo"))
        {
            detectedCanvas.gameObject.SetActive(true);

            if (!rojaAbierta)
            {
                textoUI.text = "Pulsa F para abrir la puerta roja";

                if (Keyboard.current.fKey.wasPressedThisFrame)
                {
                    puertaRoja.OpenDoor();
                    rojaAbierta = true;
                    textoUI.text = "Puerta roja abierta";
                }
            }
            else
            {
                textoUI.text = "Puerta roja abierta";
            }
        }

        // INTERRUPTOR VERDE
        else if (hit.collider.CompareTag("InterruptorVerde"))
        {
            detectedCanvas.gameObject.SetActive(true);

            if (!verdeAbierta)
            {
                textoUI.text = "Pulsa F para abrir la puerta verde";

                if (Keyboard.current.fKey.wasPressedThisFrame)
                {
                    puertaVerde.OpenDoor();
                    verdeAbierta = true;
                    textoUI.text = "Puerta verde abierta";
                }
            }
            else
            {
                textoUI.text = "Puerta verde abierta";
            }
        }

        // INTERRUPTOR AZUL 
        else if (hit.collider.CompareTag("InterruptorAzul"))
        {
            detectedCanvas.gameObject.SetActive(true);

            if (!azulAbierta)
            {
                textoUI.text = "Pulsa F para abrir la puerta azul";

                if (Keyboard.current.fKey.wasPressedThisFrame)
                {
                    puertaAzul.OpenDoor();
                    azulAbierta = true;
                    textoUI.text = "Puerta azul abierta";
                }
            }
            else
            {
                textoUI.text = "Puerta azul abierta";
            }
        }

        // INTERRUPTOR TRAMPA
        else if (hit.collider.CompareTag("InterruptorTrampa"))
        {
            detectedCanvas.gameObject.SetActive(true);
            textoUI.text = "Pulsa F para abrir la puerta";

            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                audioSource.Play();

                if (controller != null)
                {
                    controller.enabled = false;
                    controller.transform.position = spawnPoint.position;
                    controller.enabled = true;
                }
            }
        }
    }
}
