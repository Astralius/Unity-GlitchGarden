using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackersSpawnController : MonoBehaviour
{
    public Attacker[] PossibleAttackers;
    public Spawner[] Spawners = new Spawner[5];
    public int AttackersToSpawn;

    [Tooltip("Initial delay (in seconds) before the spawning starts.")]
    public float InitialDelay = 0f;

    private CountdownPane countdownPane;

    private void Start()
    {
        countdownPane = FindObjectOfType<CountdownPane>();
        if (countdownPane == null)
        {
            throw new NullReferenceException("Could not find CountdownPane in the scene!");
        }
        countdownPane.Initialize(AttackersToSpawn);
    }

    private void Update()
    {
        if (AttackersToSpawn > 0)
        {
            foreach (var attacker in PossibleAttackers)
            {
                if (isTimeToSpawn(attacker))
                {
                    var spawnerIndex = Mathf.CeilToInt(Random.Range(0.01f, Spawners.Length)) - 1;
                    Spawners[spawnerIndex].Spawn(attacker.gameObject);
                    AttackersToSpawn--;
                }
            }
        }
    }

    private bool isTimeToSpawn(Attacker attacker)
    {
        var result = false;
        if (Time.timeSinceLevelLoad > InitialDelay)
        {
            var spawnsPerSecond = 1 / attacker.SpawnInterval;

            if (Time.deltaTime > attacker.SpawnInterval)
            {
                Debug.LogWarning("Spawn rate capped by frame rate");
            }

            var threshold = spawnsPerSecond * Time.deltaTime;
            result = Random.value < threshold;
        }
        return result;
    }
}