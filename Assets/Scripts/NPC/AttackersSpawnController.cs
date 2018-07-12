using UnityEngine;

public class AttackersSpawnController : MonoBehaviour
{
    public Attacker[] PossibleAttackers;
    public Spawner[] Spawners = new Spawner[5];
    public int AttackersToSpawn;

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
        var spawnsPerSecond = 1 / attacker.SpawnInterval;

        if (Time.deltaTime > attacker.SpawnInterval)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        var threshold = spawnsPerSecond * Time.deltaTime;
        return Random.value < threshold;
    }
}