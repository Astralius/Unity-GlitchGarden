using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Tooltip("Angular velocity in degrees per second.")]
    public Vector3 RotationSpeed;

    void Update()
    {
        transform.Rotate(RotationSpeed * Time.deltaTime);
    }
}
