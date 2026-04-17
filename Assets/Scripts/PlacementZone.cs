using UnityEngine;

public class PlacementZone : MonoBehaviour
{
    private Transform _transform;

    private float _halfDivider = 2f;
    private Vector3 _currentPlacePosition;
    private Vector3 _startPlacePosition;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public bool TryGetNextPosition(float objectSpacing, out Vector3 nextPosition)
    {
        nextPosition = Vector3.zero;

        bool isReachedWidthBound = false;
        bool isReachedLengthBound = false;
        bool isReachedHeightBound = false;

        float newPositionX = _currentPlacePosition.x + objectSpacing;
        float newPositionY = _currentPlacePosition.y;
        float newPositionZ = _currentPlacePosition.z;

        if (IsInWidthBounds(newPositionX) == false)
        {
            newPositionX = _startPlacePosition.x;
            isReachedWidthBound = true;
        }

        if (isReachedWidthBound)
            newPositionZ += objectSpacing;

        if (IsInLengthBounds(newPositionZ) == false)
        {
            newPositionZ = _startPlacePosition.z;
            isReachedLengthBound = true;
        }

        if (isReachedLengthBound && isReachedWidthBound)
            newPositionY += objectSpacing;

        if (IsInHeightBounds(newPositionY) == false)
            isReachedHeightBound = true;

        if (isReachedWidthBound && isReachedLengthBound && isReachedHeightBound)
            return false;

        _currentPlacePosition = (new Vector3(newPositionX, newPositionY, newPositionZ));
        nextPosition = _currentPlacePosition;

        return true;
    }

    public Vector3 GetStartPosition(float sizeOfPlacementObject)
    {
        _startPlacePosition = _transform.position - new Vector3(_transform.localScale.x,
            _transform.localScale.y,
            _transform.localScale.z) / _halfDivider
            + new Vector3(sizeOfPlacementObject, sizeOfPlacementObject, sizeOfPlacementObject) / _halfDivider;

        _currentPlacePosition = _startPlacePosition;

        return _startPlacePosition;
    }

    private bool IsInWidthBounds(float value)
    {
        float minWidthBound = _transform.position.x - _transform.transform.localScale.x / _halfDivider;
        float maxWidthBound = minWidthBound + _transform.localScale.x;

        return value <= maxWidthBound && value >= minWidthBound;
    }

    private bool IsInLengthBounds(float value)
    {
        float minLengthBound = _transform.position.z - _transform.localScale.z / _halfDivider;
        float maxLengthBound = minLengthBound + _transform.localScale.z;

        return value <= maxLengthBound && value >= minLengthBound;
    }

    private bool IsInHeightBounds(float value)
    {
        float minHeightBound = _transform.position.y - _transform.transform.localScale.y / _halfDivider;
        float maxHeightBound = minHeightBound + _transform.localScale.y;

        return value <= maxHeightBound && value >= minHeightBound;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(
                        transform.localScale.x,
                        transform.localScale.y,
                        transform.localScale.z));
    }
}