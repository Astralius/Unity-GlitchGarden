using UnityEngine;

public class Mover : MonoBehaviour
{
    [Tooltip("Linear velocity in Unity units per second.")]
    public Vector3 MovementSpeed;

    void Update()
    {
        transform.position += MovementSpeed * Time.deltaTime;
    }
}
