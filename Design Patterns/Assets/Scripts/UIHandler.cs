using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    GameObject _uiInventoryParent;

    [SerializeField]
    List<GameObject> _inventoryItemUI;

    [SerializeField]
    GameObject _inventorySpritePrefab;

    [SerializeField]
    GameObject _victoryBG;
    [SerializeField]
    GameObject _victoryText;
    [SerializeField]
    float _victoryFadeinTime =3;


    public void AddItemSprite(ItemSO itemSO)
    {
        ItemUI itemUI = GetItemUI();
        itemUI.SetItemUI(itemSO);
    }
    public void RemoveItemSprite(ItemSO itemSO)
    {
        foreach (var gameObject in _inventoryItemUI)
        {
            if (gameObject.GetComponent<ItemUI>().itemSO == itemSO)
            {
                gameObject.GetComponentInChildren<ItemInteraction>().ResetItemPos();
                gameObject.SetActive(false);
                return;
            }
        }
    }
    private ItemUI GetItemUI()
    {
        ItemUI itemUI;
        if (_inventoryItemUI == null)
        {
            CreateNewItemUIPrefab();
        }
        itemUI = SearchForItemUI();
        if (itemUI == null)
        {
            CreateNewItemUIPrefab();
            itemUI = SearchForItemUI();
            return itemUI;
        }
        return itemUI;
    }
    private ItemUI SearchForItemUI()
    {
        for (int i = 0; i < _inventoryItemUI.Count; i++)
        {
                if (!_inventoryItemUI[i].gameObject.activeSelf)
            {
                var go = _inventoryItemUI[i].gameObject;
                go.SetActive(true);
                ResetChildObject(go);
                ItemUI itemUI;
                itemUI = _inventoryItemUI[i].GetComponent<ItemUI>();
                return itemUI;
            }
        }
        return null;
    }
    private void CreateNewItemUIPrefab()
    {
        _inventoryItemUI.Add(GameManager.instance.factoryHandler.InstantiateObject(_inventorySpritePrefab, _uiInventoryParent));
    }
    private void ResetChildObject(GameObject gameObject)
    {
        gameObject.transform.GetChild(0).transform.localPosition = Vector3.zero;
    }
    public void VictoryScreen()
    {
        _victoryText.SetActive(true);
        _victoryBG.SetActive(true);
        var cg = _victoryBG.GetComponent<CanvasGroup>();
        LeanTween.alphaCanvas(cg, 1, _victoryFadeinTime);
    }

}
