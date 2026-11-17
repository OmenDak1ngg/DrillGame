using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTracker : MonoBehaviour
{
    [SerializeField] private List<DroppableSlot> _slots;
    [SerializeField] private ModifiesData _modifiesData;

    private void OnEnable()
    {
        foreach (var slot in _slots)
        {
            slot.DroppedOnSlot += OnSlotDropped;
        }
    }

    private void OnDisable()
    {
        foreach (var slot in _slots)
        {
            slot.DroppedOnSlot -= OnSlotDropped;
        }
    }

    private void OnSlotDropped(Item item, bool isActive)
    {
        _modifiesData.ChangeModifyState(item.Type, isActive);
    }
}