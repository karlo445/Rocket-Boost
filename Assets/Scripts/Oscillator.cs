using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period; // Time it takes for the sine wave to do a full circle

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        float cycles = Time.time / period; // Continually growing over time

        const float tau = Mathf.PI * 2; // 兀 * 2; Constant value of 6.283

        float rawSinWave = Mathf.Sin(cycles * tau); // Going  from -1 to 1

        movementFactor = (rawSinWave + 1) / 2; // Recalculated to 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
