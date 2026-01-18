using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPuerta : MonoBehaviour
{
    public float openAngle = -90f;   // grados totales a girar
    public float openSpeed = 30f;    // grados por segundo
    private bool isOpen = false;     // abierta o cerrada la puerta
    private float rotated = 0f;      // cuánto hemos girado ya

    public void OpenDoor()
    {
        if (!isOpen) isOpen = true;
    }

    void Update()
    {
        if (isOpen)
        {
            float step = openSpeed * Time.deltaTime; // cuánto girar este frame

            if (rotated + step > Mathf.Abs(openAngle))
                step = Mathf.Abs(openAngle) - rotated; // no pasarse

            transform.Rotate(0, -step, 0);
            rotated += step;

            if (rotated >= Mathf.Abs(openAngle))
            {
                isOpen = false; // terminado
               
            }
        }
    }
}
    


   
