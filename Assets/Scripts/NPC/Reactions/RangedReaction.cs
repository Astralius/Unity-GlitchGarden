using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RangedReaction : AttackReaction
{
    [Tooltip("Projectile prefab containing the projectiles to be fired by this object.")]
    public Projectile Projectile;

    private Gun gun;
    private Spawner myLaneSpawner;

    private void Start()
    {
        gun = GetComponentInChildren<Gun>();
        DetectSpawner();        
    }   

    private void Update()
    {
        var attacker = DetectAttacker();
        if (attacker != null)
        {
            React(attacker.gameObject);
        }
        else
        {
            StopReacting();
        }
    }

    // Called by animation events
    public void Shoot()
    {
        gun.FireProjectile(Projectile);
    }

    private bool IsInTheSameLane(MonoBehaviour objectToCheck)
    {
        return Math.Abs(objectToCheck.transform.position.y - this.transform.position.y) < 0.01f;
    }

    private void DetectSpawner()
    {
        myLaneSpawner = FindObjectsOfType<Spawner>().FirstOrDefault(IsInTheSameLane);
        if (myLaneSpawner == null)
        {
            Debug.LogError("There seems to be no Spawner in lane " + (int)this.transform.position.y);
        }
    }

    private Attacker DetectAttacker()
    {
        Attacker detectedAttacker = null;
        if (myLaneSpawner != null && myLaneSpawner.transform.childCount > 0)
        {
            detectedAttacker = 
                myLaneSpawner.GetComponentsInChildren<Attacker>()
                           .OrderBy(a => a.transform.position.x)
                           .FirstOrDefault(a => a.transform.position.x > this.transform.position.x);
        }

        return detectedAttacker;
    }    
}
