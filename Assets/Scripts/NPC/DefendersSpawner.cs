using UnityEngine;
using UnityEngine.EventSystems;

public class DefendersSpawner : MonoBehaviour, IPointerClickHandler
{
    public ConstructionPane ConstructionPane;

    private const string defendersParentName = "Defenders";
    private GameObject defendersParent;
    
    public void Start()
    {
        defendersParent = GameObject.Find(defendersParentName);
        if (!defendersParent)
        {
            defendersParent = new GameObject(defendersParentName);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var selectedDefender = ConstructionPane.SelectedDefenderPrefab;
        if (selectedDefender)
        {
            var spawnPosition = SnapToGrid(GetWorldPosition(eventData.position));
            var spawn = Instantiate(selectedDefender, spawnPosition, Quaternion.identity);
            spawn.transform.parent = defendersParent.transform;
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
