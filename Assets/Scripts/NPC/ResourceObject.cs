using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ResourceObject : MonoBehaviour
{
    public ResourceType Type;
    public int Amount = 1;
    public float TimeToDisappear = 4f;

    private new SpriteRenderer renderer;
    private Color color;
    private ResourcesController resourcesController;
    
    private void Start()
    {
        color = Color.white;
        renderer = GetComponent<SpriteRenderer>();
        resourcesController = FindObjectOfType<ResourcesController>();
        hideFlags = HideFlags.HideInHierarchy;
        Invoke("OnBecameInvisible", TimeToDisappear);
    }

    private void Update()
    { 
        color.a -= Time.deltaTime / TimeToDisappear;
        renderer.color = color;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (resourcesController)
        {
            switch (Type)
            {
                case ResourceType.Light:
                    resourcesController.Light.Add(Amount);
                    break;
                //TODO: Add more resources here
            }

            Destroy(this.gameObject);
        }
        else
        {
            Debug.LogError("There seems to be no ResourcesController in the scene!");
        }
    }
}
