using UnityEngine;

public class OrePlacer : MonoBehaviour
{
    [SerializeField] private PlacementZone _placementZone;
    [SerializeField] float objectSpacing = 0.2f;

    public bool TryPlace(Ore ore)
    {
        Vector3 nextPlacePosition = Vector3.zero;

        if (_placementZone.TryGetNextPosition(objectSpacing + ore.transform.localScale.x, out nextPlacePosition) == false)
        {
            return false;
        }
        
        ore.transform.rotation = Quaternion.identity;
        ore.transform.SetParent(transform,false);
        ore.transform.position = nextPlacePosition;
        ore.Rigidbody.isKinematic = true;

        return true;
    }
}