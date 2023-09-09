using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlotData : MonoBehaviour, IPointerDownHandler
{
    public Item item;

    public void OnPointerDown(PointerEventData eventData)
    {
        UIInventory.OnSlotClick?.Invoke(this.item);
    }

    private void OnEnable()
    {
        UIInventory.OnSlotClick += SetCurrentSelectItem;
    }
    private void OnDisable()
    {
        UIInventory.OnSlotClick -= SetCurrentSelectItem;
    }
    private void SetCurrentSelectItem(Item item)
    {
        if (item != null)
        {
            UIInventory.Instance._currentSelectItem = item;
        }
    }
}
