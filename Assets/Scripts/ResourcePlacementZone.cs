using UnityEngine;

public class ResourcePlacementZone : PlacementZone
{
    [SerializeField] private ResourceStorage _playerStorage;

    private void OnEnable()
    {
        _playerStorage.Decreased += OnDecrease;
    }

    private void OnDisable()
    {
        _playerStorage.Decreased -= OnDecrease;
    }

    private void OnDecrease()
    {
        SetPreviousCurrentPosition();
    }
}