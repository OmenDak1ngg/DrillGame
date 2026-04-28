using UnityEngine;

public class OrePresenter : MonoBehaviour
{
    [SerializeField] private Drill _playerDrill;
    [SerializeField] private OreStorage _storage;
    [SerializeField] private OreSpawner _spawner;

    [SerializeField] private OreTracker _tracker;
    [SerializeField] private OreRendererChanger _rendererChanger;
    [SerializeField] private Thrower _thrower;
    [SerializeField] private OrePlacer _placer;

    [SerializeField] private PlacementZone _storagePlacementZone;

    private void OnEnable()
    {
        _playerDrill.Drilled += OnOreDrilled;
        _storage.Decreased += OnStorageDecreased;
        _storage.Collected += OnOreCollected;
        _spawner.Created += OnOreCreated;
    }

    private void OnDisable()
    {
        _playerDrill.Drilled -= OnOreDrilled;
        _storage.Decreased -= OnStorageDecreased;
        _storage.Collected -= OnOreCollected;
        _spawner.Created -= OnOreCreated;
    }

    private void OnOreDrilled(Ore ore)
    {
        ore.Collider.isTrigger = false;

        _tracker.RemoveFromDrilled(ore);
        _tracker.PushToDrilled(ore);

        _rendererChanger.SetNextState(ore);
        _thrower.ThrowTo(ore, _playerDrill.transform.position);
    }

    private void OnOreCollected(Ore ore)
    {
        if (_tracker.IsDrilled(ore) == false)
            return;

        if (_placer.TryPlace(ore) == false)
            return;
    }

    private void OnOreCreated(Ore ore)
    {
        _tracker.AddToUndrilled(ore);
    }

    private void OnStorageDecreased()
    {
        _storagePlacementZone.SetPreviousCurrentPosition();
        _tracker.PopFromDrilled().gameObject.SetActive(false);
    }
}