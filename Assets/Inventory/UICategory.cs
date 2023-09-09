using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICategory : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemType _categoryType;

    public void OnPointerDown(PointerEventData eventData)
    {
        UIInventory.OnCategoryClick?.Invoke(this._categoryType);
    }
    private void OnEnable()
    {
        UIInventory.OnCategoryClick += ShowAllByType;
    }
    private void OnDisable()
    {
        UIInventory.OnCategoryClick -= ShowAllByType;
    }
    private void ShowAllByType(ItemType itemType)
    {
        UIInventory.Instance.RefreshUIInventory(itemType);
    }
}
