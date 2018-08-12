using UnityEngine;

public class BlockerReaction : BaseReactionBehaviour
{
    protected const string ReactToAttackParameter = "React to attack";

    [Range(1, 3)]
    public int Size = 1;

    public override void React(GameObject source)
    {
        if (animator != null)
        {
            var colliderBehaviour = source.GetComponent<BaseReactionBehaviour>();
            if (colliderBehaviour is AttackReaction)
            {
                animator.SetBool(ReactToAttackParameter, true);
            }
        }
    }

    public override void StopReacting()
    {
        if (animator != null)
        {
            animator.SetBool(ReactToAttackParameter, true);
        }
    }
}
