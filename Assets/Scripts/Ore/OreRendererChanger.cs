using UnityEngine;

public class OreRendererChanger : MonoBehaviour
{
    private const int _oreStatesCount = 2;
    private const int _drilledStateIndex = 1;
    private const int _baseStateIndex = 0;

    [SerializeField] private OreTracker _tracker;


    [Tooltip("[0] - baseState; [1] - drilledState")]
    [SerializeField] private Vector3[] _scales = new Vector3[_oreStatesCount];
    [Tooltip("[0] - baseState; [1] - drilledState")]
    [SerializeField] private Material[] _materials = new Material[_oreStatesCount];

    public void SetNextState(Ore ore)
    {
        int newStateIndex = _tracker.IsDrilled(ore) ? _drilledStateIndex : _baseStateIndex;

        ore.Renderer.material = _materials[newStateIndex];
        ore.transform.localScale = _scales[newStateIndex];
    }
}