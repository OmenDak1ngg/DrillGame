using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool _isSlotActive;

    public event Action<Item, bool> DroppedOnSlot;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem item = eventData.pointerDrag.GetComponent<DraggableItem>();   
        item.SetParentTransform(GetComponent<RectTransform>());
        
        DroppedOnSlot?.Invoke(item, _isSlotActive);
    }
}