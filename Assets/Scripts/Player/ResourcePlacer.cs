using UnityEngine;

public class ResourcePlacer : MonoBehaviour
{
    [SerializeField] private PlacementZone _placementZone;
    [SerializeField] float objectSpacing = 0.2f;

    public bool CanPlace { get; private set; }

    private void Awake()
    {
        CanPlace = true;
    }

    public void TryPlace(Resource resource)
    {
        Vector3 nextPlacePosition = Vector3.zero;

        if (_placementZone.TryGetNextPosition(objectSpacing + resource.transform.localScale.x, out nextPlacePosition) == false)
        {
            CanPlace = false;
            return;
        }
        
        CanPlace = true;
        resource.transform.rotation = Quaternion.identity;
        resource.transform.SetParent(transform,false);
        resource.transform.position = nextPlacePosition;
        resource.GetComponent<Rigidbody>().isKinematic = true;
    }
}