using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : Item, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform _parentTransform;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
   
    private bool _droppedOnSlot;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _droppedOnSlot = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;

        if (_droppedOnSlot == false)
            _rectTransform.position = _parentTransform.position;
    }

    public void SetParentTransform(RectTransform rectTransform)
    {
        _parentTransform = rectTransform;
        _droppedOnSlot = true;
        _rectTransform.position = _parentTransform.position;
    }
}
