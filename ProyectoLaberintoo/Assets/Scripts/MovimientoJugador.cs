using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Velocidades")]
    public float moveSpeed = 5f;      // Velocidad de avance / retroceso
    public float turnSpeed = 180f;    // Velocidad de giro (grados por segundo)


    private CharacterController controller;
    

    void Start()
    {
        // Obtener el CharacterController de la cápsula
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        //Obtener input del jugador
        float horizontal = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float vertical = Input.GetAxis("Vertical");     // W/S o flechas arriba/abajo

        //Girar al jugador (rotación Y)
        transform.Rotate(0f, horizontal * turnSpeed * Time.deltaTime, 0f);

        //Crear el vector de movimiento en espacio local
        Vector3 move = new Vector3(0f, 0f, vertical); // Avanza hacia adelante (z local)

        //Transformar de local a world space según rotación del personaje
        move = transform.TransformDirection(move);

        //Multiplicar por velocidad y deltaTime para consistencia
        move *= moveSpeed * Time.deltaTime;

        //Aplicar movimiento usando CharacterController
        controller.Move(move);

       
    }
}
