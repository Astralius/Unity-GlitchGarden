using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    [Range(-1f, 1.5f)]
    public float WalkSpeed;
    [Range(1f, 10f)]
    public float Damage;

    private float currentSpeed;
    private HealthController currentTarget;
    private BaseReactionBehaviour reaction;
    private new Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        reaction = GetComponent<BaseReactionBehaviour>();
        currentSpeed = WalkSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>())
        {
            currentTarget = collision.GetComponent<HealthController>();
            if (reaction != null)
            {
                reaction.React(currentTarget.gameObject);
            }
            else
            {
                throw new MissingComponentException("" +
                    "This GameObject (" + currentTarget + ") " +
                    "must have a BaseReactionBehaviour-derived " +
                    "component in order to properly react to collisions!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exit!");
        if (collision.GetComponent<Defender>())
        {
            currentTarget = null;
            if (reaction != null)
            {
                reaction.StopReacting();
            }
            else
            {
                throw new MissingComponentException("" +
                    "This GameObject (" + collision + ") " +
                    "must have a BaseReactionBehaviour-derived " +
                    "component in order to properly react to collisions!");
            }
        }
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void ResetSpeed()
    {
        SetSpeed(WalkSpeed);
    }

    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget()
    {
        if (currentTarget != null)
        {
            currentTarget.Damage(Damage);
        }
        else
        {
            Debug.LogWarning("Missing " + 
                             typeof(HealthController) + 
                             "in target! Damage will not be dealt!");
        }
    }    
}
