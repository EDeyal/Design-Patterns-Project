using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableHandler
{
    ItemUI _currentItemUI;
    //public ItemSO currentItem { get => _currentItem; set => _currentItem = value; }
    public InteractableHandler(Player player)
    {
        _player = player;
    }
    Player _player;
    public void SendRay()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UI is in the way click canceled");
            return;
        }
        Ray ray = GameManager.instance.mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit);
        if (hit.transform == null)
        {
            Debug.Log("hit is null");
            return;
        }
        Debug.Log(hit.transform.gameObject);
        if (hit.transform.gameObject.tag == "Door")
        {
            OnDoorClick(hit);
        }
        else if (hit.transform.gameObject.tag == "Item")
        {
            OnItemClick(hit);
        }
        else if (hit.transform.gameObject.tag == "Animatable")
        {
            OnAnimatableClick(hit);
        }
    }
    private void OnAnimatableClick(RaycastHit hit)
    {
        Debug.Log("player Touched an Animatable object");
        Animator animator;
        if (hit.transform.gameObject.GetComponent<Animator>() == null)
        {
            animator = hit.transform.gameObject.GetComponentInParent<Animator>();
        }
        else
        {
            animator = hit.transform.gameObject.GetComponent<Animator>();
        }
        if (animator.GetBool("AnimateObject"))
        {
            animator.SetBool("AnimateObject", false);
        }
        else
        {
            animator.SetBool("AnimateObject", true);
        }
    }
    private void OnDoorClick(RaycastHit hit)
    {
        var door = hit.transform.gameObject.GetComponent<Door>();
        if (door != null)
            door.MoveToNextRoom();
        else
        {
            Debug.LogError("Door does not have the Door script");
        }
    }
    private void OnItemClick(RaycastHit hit)
    {
        Item item;
        if (hit.transform.gameObject.GetComponent<Item>() == null)
        {
            item = hit.transform.gameObject.GetComponentInParent<Item>();
        }
        else
        {
            item = hit.transform.gameObject.GetComponent<Item>();
        }
        _player.AddItemToPlayerInventory(item.itemSO);
        if (item is PlayerItem playerItem)
        {
            playerItem.InstantiateItemOnPlayer();
        }
        GameManager.instance.uiHandler.AddItemSprite(item.itemSO);
        item.gameObject.SetActive(false);
    }
    public void AssignCurrentItem(GameObject gameobject)
    {
        var parentObject = gameobject.transform.parent.gameObject;
        if (parentObject != null)
        {
            if (parentObject.GetComponent<ItemUI>() == null)
            {
                _currentItemUI = parentObject.GetComponentInChildren<ItemUI>();
            }
            else
            {
                _currentItemUI = parentObject.GetComponent<ItemUI>();
            }
        }
        Debug.Log($"Current item is {_currentItemUI}");
    }
    public void UnassignCurrentItem()
    {
        _currentItemUI = null;
        Debug.Log($"Current item is {_currentItemUI}");
    }
}