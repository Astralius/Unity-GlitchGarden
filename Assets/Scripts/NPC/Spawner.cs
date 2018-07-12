using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    public void Spawn(GameObject objectToSpawn)
    {
        var spawn = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        spawn.transform.parent = this.transform;
    }
}
