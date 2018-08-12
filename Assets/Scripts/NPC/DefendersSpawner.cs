using UnityEngine;
using UnityEngine.EventSystems;

public class DefendersSpawner : MonoBehaviour, IPointerClickHandler
{
    public ConstructionPane ConstructionPane;

    private const string defendersParentName = "Defenders";
    private ResourcesController resourcesController;
    private GameObject defendersParent;
    
    public void Start()
    {
        defendersParent = GameObject.Find(defendersParentName);
        if (!defendersParent)
        {
            defendersParent = new GameObject(defendersParentName);
        }

        resourcesController = FindObjectOfType<ResourcesController>();
        if (resourcesController == null)
        {
            Debug.LogError("There seems to be no Resources Controller in the scene!");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var selectedPrefab = ConstructionPane.SelectedDefenderPrefab;      
        if (selectedPrefab != null)
        {
            var selectedDefender = selectedPrefab.GetComponent<Defender>();
            if (selectedDefender != null)
            {
                if (resourcesController.Light.Use(selectedDefender.LightCost))
                {                    
                    var spawnPosition = SnapToGrid(GetWorldPosition(eventData.position));
                    var spawn = Instantiate(selectedDefender, spawnPosition, Quaternion.identity);
                    spawn.transform.parent = defendersParent.transform;                   
                }
                else
                {
                    Debug.Log("Insufficient stars!");
                }
                ConstructionPane.DeselectEverything();
            }           
        }
    }

    private static Vector3 GetWorldPosition(Vector3 screenPosition)
    {
        var mainCamera = Camera.main;
        var distanceFromCamera = mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, 
                                                         screenPosition.y, 
                                                         -distanceFromCamera));
    }

    private static Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        return new Vector2(Mathf.RoundToInt(rawWorldPosition.x), 
                           Mathf.RoundToInt(rawWorldPosition.y));
    }
}
