using UnityEngine;

public class BlockerReaction : BaseReactionBehaviour
{
    protected const string IsUnderAttackParameter = "IsUnderAttack";

    [Range(1, 3)]
    public int Size = 1;

    public override void React(GameObject source)
    {
        if (animator != null)
        {
            var colliderBehaviour = source.GetComponent<BaseReactionBehaviour>();
            if (colliderBehaviour is AttackReaction)
            {
                animator.SetBool(IsUnderAttackParameter, true);
            }
        }
    }

    public override void StopReacting()
    {
        if (animator != null)
        {
            animator.SetBool(IsUnderAttackParameter, true);
        }
    }
}
