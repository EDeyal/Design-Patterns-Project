using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInteraction : MonoBehaviour ,IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField]
    CanvasGroup _canvasGroup;
    public void OnClick()
    {
        GameManager.instance.interactableHandler.AssignCurrentItem(transform.gameObject);
    }
    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
        _canvasGroup.alpha = 0.8f;
        _canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        ResetItemPos();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log($"{gameObject} OnDropActivated");
        if (eventData.pointerDrag != null)
        {
            ItemUI droppedItem = eventData.pointerDrag.GetComponentInParent<ItemUI>();
            Debug.Log($"Dropped{droppedItem.itemSO.name} on");
            ItemUI onItem = gameObject.GetComponentInParent<ItemUI>();
            Debug.Log($"{onItem.itemSO.name} item");
            GameManager.instance.player.TryMerge(droppedItem.itemSO, onItem.itemSO);
        }
    }
    public void ResetItemPos()
    {
        transform.localPosition = Vector3.zero;
        GameManager.instance.interactableHandler.UnassignCurrentItem();
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
}
