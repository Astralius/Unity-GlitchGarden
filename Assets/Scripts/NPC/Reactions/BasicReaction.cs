﻿using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BasicReaction : BaseReactionBehaviour
{
    public override void React(GameObject source)
    {
        animator.SetBool("IsAttacking", true);
    }

    public override void StopReacting()
    {
        animator.SetBool("IsAttacking", false);
    }
}
