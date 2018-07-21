using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("Could not find a Level Manager in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("03b Lose");
    }
}
