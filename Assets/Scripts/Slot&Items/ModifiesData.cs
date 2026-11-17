using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class ModifiesData : MonoBehaviour
{
    [SerializeField] private List<Modify> _modifies;

    private static List<ModifyTypes> _activeTypes = new List<ModifyTypes>();

    private void Awake()
    {
        foreach(Modify modify in _modifies)
        {
            if (_activeTypes.Contains(modify.Type))
            {
                modify.gameObject.SetActive(true);
            }
            else
            {
                modify.gameObject.SetActive(false);
            }
        }
    }

    public void ChangeModifyState(ModifyTypes type, bool isActive)
    {
        if (isActive)
        {
            if (_activeTypes.Contains(type))
                throw new InvalidEnumArgumentException();

            _activeTypes.Add(type);
        }
        else
        {
            if (_activeTypes.Contains(type) == false)
                throw new InvalidEnumArgumentException();

            _activeTypes.Remove(type);
        }
    }
}