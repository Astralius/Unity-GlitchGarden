using UnityEngine;

public class NoReaction : BaseReactionBehaviour
{
    public override void React(GameObject source)
    {
        // Do not react at all.
    }

    public override void StopReacting()
    {
        // Nothing to do here, too.
    }
}
