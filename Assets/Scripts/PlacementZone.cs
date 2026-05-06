using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class PlacementZone : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;

    private Transform _transform;

    private float _halfDivider = 2f;
    private Vector3 _currentPlacePosition;
    private Vector3 _startPlacePosition;

    private Stack<Vector3> _previousPositions = new Stack<Vector3>();

    private void Awake()
    {
        _collider.isTrigger = true;
        _transform = GetComponent<Transform>();
        _transform.localScale = Vector3.one;
    }

    public bool TryGetNextPosition(float objectSpacing, out Vector3 nextPosition)
    {
        if (_currentPlacePosition == Vector3.zero)
            _currentPlacePosition = GetStartPosition(objectSpacing);

        _previousPositions.Push(_currentPlacePosition);
        
        nextPosition = Vector3.zero;
        _currentPlacePosition.x += objectSpacing;

        Vector3 min = _collider.center - _collider.size / _halfDivider;
        Vector3 max = _collider.center + _collider.size / _halfDivider;

        if (_currentPlacePosition.x > max.x)
        {
            _currentPlacePosition.x = min.x;
            _currentPlacePosition.z += objectSpacing;
        }

        if (_currentPlacePosition.z > max.z)
        {
            _currentPlacePosition.z = min.z;
            _currentPlacePosition.y += objectSpacing;
        }

        if (_currentPlacePosition.y > max.y)
            return false;

        nextPosition = transform.TransformPoint(_currentPlacePosition);

        return true;
    }

    public Vector3 GetStartPosition(float objectSpacing)
    {
        Vector3 min = _collider.center - _collider.size / _halfDivider;
        min.x -= objectSpacing;
        _startPlacePosition = min;

        return _startPlacePosition;
    }

    public void SetPreviousCurrentPosition()
    {
        if (_previousPositions.Count == 0)
            return;

        _currentPlacePosition = _previousPositions.Pop();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(
                        _collider.bounds.size.x,
                        _collider.bounds.size.y,
                        _collider.bounds.size.z));
    }
}