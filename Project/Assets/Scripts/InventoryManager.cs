using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryCanvas; // Canvas del inventario
    public GameObject itemButtonPrefab; // Prefab del botón del producto
    public Transform inventoryGrid; // Contenedor del Grid Layout

    [System.Serializable]
    public class InventoryItem
    {
        public string itemName;   // Nombre del producto
        public Sprite itemSprite; // Imagen del producto
    }

    public List<InventoryItem> availableItems = new List<InventoryItem>(); // Lista de productos disponibles
    private Dictionary<string, int> selectedItems = new Dictionary<string, int>(); // Productos seleccionados con cantidades

    void Start()
    {
        GenerateInventory();
    }

    void GenerateInventory()
    {
        foreach (InventoryItem item in availableItems)
        {
            GameObject newItem = Instantiate(itemButtonPrefab, inventoryGrid);
            newItem.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName; // Asigna el nombre del producto
            
            // Asigna la imagen al botón
            Transform imageTransform = newItem.transform.Find("Item_Image");
            if (imageTransform != null)
            {
                Image itemImage = imageTransform.GetComponent<Image>();
                if (itemImage != null)
                {
                    itemImage.sprite = item.itemSprite;
                }
            }

            // Asignar evento de selección al botón
            newItem.GetComponent<Button>().onClick.AddListener(() => SelectItem(item.itemName));
        }
    }

    void SelectItem(string item)
    {
        if (selectedItems.ContainsKey(item))
        {
            selectedItems[item]--;
            if (selectedItems[item] <= 0)
            {
                selectedItems.Remove(item);
            }
            Debug.Log("Product removed: " + item);
        }
        else
        {
            selectedItems[item] = 1;
            Debug.Log("Product added: " + item);
        }
    }

    public Dictionary<string, int> GetSelectedItems()
    {
        return new Dictionary<string, int>(selectedItems);
    }

    // Método para confirmar la entrega del pedido
    public void DeliverOrder()
    {
        FindObjectOfType<OrderManager>().CheckOrder(new Dictionary<string, int>(selectedItems));
        selectedItems.Clear(); // Limpiar la selección después de la entrega
    }

    public void ClearSelection()
    {
        selectedItems.Clear();
        Debug.Log("Inventory selection cleared.");
    }
}