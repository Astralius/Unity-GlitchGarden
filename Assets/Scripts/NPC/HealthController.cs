using UnityEngine;

[DisallowMultipleComponent]
public class HealthController : MonoBehaviour
{
    [Range(0,100)]
    public int StartingHealth;

    [ReadOnly]
    public float CurrentHealth;

    private BaseReactionBehaviour reaction;

    private void Start()
    {
        CurrentHealth = StartingHealth;
        reaction = GetComponent<BaseReactionBehaviour>();
    }

    public void Damage(float damagePoints)
    {
        CurrentHealth -= damagePoints;
        Debug.Log(gameObject + " stroke for " + damagePoints + " hit points!");
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

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
