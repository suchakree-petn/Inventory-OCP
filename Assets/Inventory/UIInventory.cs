using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIInventory : MonoBehaviour
{
    public static UIInventory Instance;

    [Header("Item List")]
    public List<GameObject> UISlot;
    public Item _currentSelectItem;



    [Header("Description Panel")]
    [SerializeField] private TextMeshProUGUI _descriptionName;
    [SerializeField] private Image _descriptionIcon;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _priceText;

    [Header("UI Transform")]
    [SerializeField] private Transform _inventoryContentTransform;
    [SerializeField] private Transform _descriptionContentTransform;


    [Header("Prefab")]
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject InventoryPrefab;

    public delegate void SlotActions(Item item);
    public static SlotActions OnSlotClick;

    public delegate void CategoryActions(ItemType itemType);
    public static CategoryActions OnCategoryClick;

    List<SlotItem> _slotItem = new List<SlotItem>();

    [Header("Money")]
    public int _money;
    public TextMeshProUGUI showMoney;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _slotItem = InventorySystem.Instance.itemList;
        RefreshUIInventory(ItemType.Weapon);
        OnSlotClick?.Invoke(_currentSelectItem);
        showMoney.text = _money+"";

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            RefreshUIInventory(ItemType.Weapon);
            OnSlotClick?.Invoke(_currentSelectItem);
        }

    }
    private GameObject CreateUISlot(SlotItem slotItem)
    {
        GameObject slot = Instantiate(slotPrefab, _inventoryContentTransform);
        slot.GetComponent<UISlotData>().item = slotItem.item;
        slot.transform.GetChild(0).GetComponent<Image>().sprite = slotItem.item._icon;
        slot.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = slotItem.stackCount.ToString();
        return slot;
    }

    public void BuyItem()
    {
        int priceItem = _currentSelectItem._price;
        if(_money >= priceItem)
        {
            _money -= priceItem;
            showMoney.text = _money + "";
            Debug.Log("Buy this item");
        }
        else
        {
            Debug.Log("Can not buy this item");
        }
    }
    public void RefreshUIInventory(ItemType itemType)
    {
        // Is list empty?
        if (_slotItem == null)
        {
            return;
        }

        // Clear inventory
        foreach (Transform child in _inventoryContentTransform)
        {
            Destroy(child.gameObject);
        }

        // Clear list
        UISlot.Clear();

        // Create new slot
        SlotItem firstItemInSlot = null;
        for (int i = 0; i < _slotItem.Count; i++)
        {

            if (_slotItem[i].item._itemType == itemType)
            {
                if (firstItemInSlot == null)
                {
                    firstItemInSlot = _slotItem[i];
                }
                GameObject slot = CreateUISlot(_slotItem[i]);
                UISlot.Add(slot);
            }
        }

        // Init first select slot
        if (firstItemInSlot == null)
        {
            _currentSelectItem = null;
        }
        else
        {
            _currentSelectItem = firstItemInSlot.item;
        }

        // Enable description
        InitDescriptionUI();

    }

    private void InitDescriptionUI()
    {
        if (_slotItem == null || _currentSelectItem == null)
        {
            _inventoryContentTransform.gameObject.SetActive(false);
            _descriptionContentTransform.gameObject.SetActive(false);
        }
        else
        {
            _inventoryContentTransform.gameObject.SetActive(true);
            _descriptionContentTransform.gameObject.SetActive(true);
        }
    }
    private void RefreshDescriptionName(Item item)
    {
        if (item != null)
        {
            _descriptionName.text = item._name;
        }
    }
    private void RefreshDescriptionIcon(Item item)
    {
        if (item != null)
        {
            _descriptionIcon.sprite = item._icon;
        }
    }

    private void RefreshDescriptionText(Item item)
    {
        if (item != null)
        {
            _descriptionText.text = item._description;
        }
    }
    private void RefreshPriceText(Item item)
    {
        if (item != null)
        {
            _priceText.text = "Price: " + item._price.ToString();
        }
    }

    private void OnEnable()
    {
        OnSlotClick += RefreshDescriptionName;
        OnSlotClick += RefreshDescriptionIcon;
        OnSlotClick += RefreshDescriptionText;
        OnSlotClick += RefreshPriceText;
    }
    private void OnDisable()
    {
        OnSlotClick -= RefreshDescriptionName;
        OnSlotClick -= RefreshDescriptionIcon;
        OnSlotClick -= RefreshDescriptionText;
        OnSlotClick -= RefreshPriceText;

    }
}
