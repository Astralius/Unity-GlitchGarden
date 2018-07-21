using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumperReaction : AttackReaction
{
    protected const string JumpParameter = "Jump";

    public override void React(GameObject source)
    {
        var blocker = source.GetComponent<BlockerReaction>();
        if (blocker && blocker.Size == 1)
        {
            animator.SetTrigger(JumpParameter);
        }
        else
        {
            animator.SetBool(IsAttackingParameter, true);
        }
    }

    public override void StopReacting()
    {
        animator.SetBool(IsAttackingParameter, false);
    }
}
