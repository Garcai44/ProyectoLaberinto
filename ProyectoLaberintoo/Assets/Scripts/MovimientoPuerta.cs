using UnityEngine;

public class MovimientoPuerta : MonoBehaviour
{
    public float openAngle = -90f;   // puede ser positivo o negativo
    public float openSpeed = 8f;    // grados por segundo
    public AudioSource audioSource;
    private bool isOpen = false;
    private float rotated = 0f;
    private float direction;

    void Start()
    {
        direction = Mathf.Sign(openAngle); // +1 o -1
    }

    public void OpenDoor()
    {
        audioSource.Play();
        if (!isOpen)
            isOpen = true;
      
    }

    void Update()
    {
        if (!isOpen) return;

        float step = openSpeed * Time.deltaTime;

        if (rotated + step > Mathf.Abs(openAngle))
            step = Mathf.Abs(openAngle) - rotated;

        transform.Rotate(0, step * direction, 0, Space.Self);
        rotated += step;

        if (rotated >= Mathf.Abs(openAngle))
        {
            isOpen = false;
        }
    }
}
