using UnityEngine;
#pragma warning disable 649

public class ResourcesController : MonoBehaviour
{
    [SerializeField]
    private ResourceDisplay lightDisplay;

    public int InitialLightAmount = 3;

    public Resource Light { get; private set; }

    private void Start()
    {
        this.Light = new Resource(
            ResourceType.Light, 
            (added, total) => OnAmountIncreased(added, total, lightDisplay),
            (used, total) => OnAmountDecreased(used, total, lightDisplay),
            total => OnAmountSet(total, lightDisplay));

        Light.Set(InitialLightAmount);
    }

    private static void OnAmountSet(int totalAmount, ResourceDisplay resourceDisplay)
    {
        resourceDisplay.UpdateAmount(0, totalAmount, ResourceOperationType.Set);
    }

    private static void OnAmountIncreased(int addedAmount, int totalAmount, ResourceDisplay resourceDisplay)
    {
        resourceDisplay.UpdateAmount(addedAmount, totalAmount, ResourceOperationType.Add);
    }

    private static void OnAmountDecreased(int usedAmount, int totalAmount, ResourceDisplay resourceDisplay)
    {
        resourceDisplay.UpdateAmount(usedAmount, totalAmount, ResourceOperationType.Substract);
    }

}
