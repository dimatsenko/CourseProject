using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Посилання на об'єкт, за яким слідкує камера
    public float smoothSpeed = 0.125f; // Параметр для згладжування руху камери

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -10); // Визначте бажану позицію камери
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Згладжуємо рух камери
            transform.position = smoothedPosition;
        }
    }
}
