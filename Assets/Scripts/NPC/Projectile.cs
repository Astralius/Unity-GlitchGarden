using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;

    private void Start()
    {
        hideFlags = HideFlags.HideInHierarchy;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.GetComponent<Attacker>();
        var health = collision.GetComponent<HealthController>();

        if (attacker && health)
        {
            health.DealDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
