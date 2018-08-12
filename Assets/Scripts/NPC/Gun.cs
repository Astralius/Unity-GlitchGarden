using UnityEngine;

public class Gun : MonoBehaviour
{
    private new Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    public void FireProjectile(Projectile projectile)
    {
        var spawn = Instantiate(projectile.gameObject, transform.position, transform.rotation);
        spawn.hideFlags = HideFlags.HideInHierarchy;
    }
}
