using UnityEngine;

[DisallowMultipleComponent]
public class HealthController : MonoBehaviour
{
    [Range(0,100)]
    public int StartingHealth;

    [ReadOnly]
    public float CurrentHealth;

    private BaseReactionBehaviour reaction;

    protected virtual void Start()
    {
        CurrentHealth = StartingHealth;
        reaction = GetComponent<BaseReactionBehaviour>();
    }

    public void DealDamage(float damagePoints)
    {
        CurrentHealth -= damagePoints;
        if (CurrentHealth <= 0f)
        {
            if (reaction != null)
            {
                reaction.Disappear();
            }
            else
            {
                throw new MissingComponentException("This GameObject (" 
                    + gameObject.name + ") must have BaseReactionBehaviour-derived " +
                    "component in order to disappear!");
            }
        }
    }

    public virtual void Destroy()
    {
        Destroy(this.gameObject);
    }
}
