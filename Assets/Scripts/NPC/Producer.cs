using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Producer : MonoBehaviour
{
    public ResourceObject ResourceObject;
    public Transform ResourceSpawn;
    public int amountProduced = 1;
    public float productionStartDelay = 5f;
    public float timeBetweenProductions = 3f;

    private const string ProduceParameter = "Produce";
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("Produce", productionStartDelay, timeBetweenProductions);
    }

    private void Produce()
    {
        animator.SetTrigger(ProduceParameter);
        var resourceObject = Instantiate(ResourceObject.gameObject, ResourceSpawn.position, ResourceSpawn.rotation);
        resourceObject.GetComponent<ResourceObject>().Amount = amountProduced;
        resourceObject.hideFlags = HideFlags.HideInHierarchy;
    }
}
