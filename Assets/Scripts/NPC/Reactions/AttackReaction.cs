using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackReaction : BaseReactionBehaviour
{
    protected const string IsAttackingParameter = "IsAttacking";

    public override void React(GameObject source)
    {
        animator.SetBool(IsAttackingParameter, true);
    }

    public override void StopReacting()
    {
        animator.SetBool(IsAttackingParameter, false);
    }
}
