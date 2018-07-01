using UnityEngine;

[DisallowMultipleComponent]
public abstract class BaseReactionBehaviour : MonoBehaviour
{
    protected const string IsAttackingParameter = "IsAttacking";
    protected Animator animator;

    private const string DisappearParameter = "Disappear";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Triggers specific reaction behaviour of this <see cref="BaseReactionBehaviour"/> descendant.
    /// </summary>
    /// <param name="source"><see cref="GameObject"/> which caused the reaction.</param>
    public abstract void React(GameObject source);

    /// <summary>
    /// Stops specific reaction behaviour of this <see cref="BaseReactionBehaviour"/> descendant.
    /// </summary>
    public abstract void StopReacting();

    /// <summary>
    /// Makes the GameObject disappear.
    /// </summary>
    public void Disappear()
    {
        if (animator != null)
        {
            animator.SetTrigger(DisappearParameter);
        }
    }
}
