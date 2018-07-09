using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RangedReaction : BaseReactionBehaviour
{
    [Tooltip("Projectile prefab containing the projectiles to be fired by this object.")]
    public Projectile Projectile;

    private Gun gun;

    private void Start()
    {
        gun = GetComponentInChildren<Gun>();
    }

    public override void React(GameObject source)
    {
        animator.SetBool("IsAttacking", true);
    }

    public override void StopReacting()
    {
        animator.SetBool("IsAttacking", false);
    }

    public void Shoot()
    {
        gun.FireProjectile(Projectile);
    }
}
