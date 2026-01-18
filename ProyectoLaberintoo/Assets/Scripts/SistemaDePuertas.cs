using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class SistemaDePuertas : MonoBehaviour
{
    public MovimientoPuerta puerta;
    public Canvas detectedCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Interruptor"))
        {
                detectedCanvas.gameObject.SetActive(true);
                if (Keyboard.current.eKey.wasPressedThisFrame) {
                    Debug.Log("Se abre la puerta");
                    puerta.OpenDoor();
                   
                }
            }
            else {
                detectedCanvas.gameObject.SetActive(false);
            }
        }
    }
}
