using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public GameObject orderCanvas;
    public TextMeshProUGUI orderText;
    public float orderInterval = 10f;  // Tiempo de espera antes de una nueva orden
    public float orderTimeout = 15f;   // Tiempo máximo que el jugador tiene para completar la orden

    public GameObject gameOverCanvas;

    private List<string> legalItems = new List<string> { "Apple", "Meat", "Bread", "Water", "Sausage", "Sandwich", "Banana", "Fish", "Cheese", "Beer" };
    private List<string> illegalItems = new List<string> { "Whiskey", "Knife", "Dagger", "Mushroom", "Ron", "Crossbow" };

    private Dictionary<string, int> currentOrder = new Dictionary<string, int>();
    private bool isPoliceOrder = false;
    private bool gameOver = false;
    private bool orderActive = false;  // Indica si hay una orden activa
    private bool orderExpired = false; // Para verificar si la orden ha expirado sin respuesta

    void Start()
    {
        orderText.text = "Waiting for a new order...";
        StartCoroutine(WaitAndGenerateNewOrder(orderInterval));
    }

    IEnumerator WaitAndGenerateNewOrder(float delay)
    {
        orderActive = false; // No hay orden activa
        yield return new WaitForSeconds(delay);
        GenerateNewOrder();
    }

    void GenerateNewOrder()
    {
        if (gameOver) return;

        orderCanvas.SetActive(true);
        currentOrder.Clear();
        isPoliceOrder = false;
        orderActive = true; // Activamos la nueva orden
        orderExpired = false; // Reiniciamos el estado de expiración

        // Limpiar selección de items
        FindObjectOfType<InventoryManager>().ClearSelection(); // Llamamos el método para limpiar selección de items

        string order = "The Customer Wants:\n";
        int itemCount = Random.Range(1, 4);
        for (int i = 0; i < itemCount; i++)
        {
            string selectedItem = Random.value < 0.8f ? legalItems[Random.Range(0, legalItems.Count)] : illegalItems[Random.Range(0, illegalItems.Count)];
            if (currentOrder.ContainsKey(selectedItem))
                currentOrder[selectedItem]++;
            else
                currentOrder[selectedItem] = 1;

            order += "- " + selectedItem + " x" + currentOrder[selectedItem] + (illegalItems.Contains(selectedItem) ? " (illegal)" : "") + "\n";
        }

        if (Random.value < 0.1f && ContainsIllegalItem())
        {
            isPoliceOrder = true;
            order += "\n (Suspicious Order - Be Careful!)";
        }

        orderText.text = order;

        // Si el jugador no completa la orden en X segundos, se considera incorrecta
        StartCoroutine(AutoFailOrder(orderTimeout));  // Cambié 'orderInterval' a 'orderTimeout'
    }

    IEnumerator AutoFailOrder(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (orderActive && !orderExpired) // Si la orden no ha expirado
        {
            orderText.text = "Time ran out! Incorrect order. Waiting for next order...";
            Debug.Log("Time expired! Incorrect order.");
            StartCoroutine(WaitAndGenerateNewOrder(5f));
            orderExpired = true; // Marca la orden como expirada para no permitir más interacciones
        }
    }

    public void CheckOrder(Dictionary<string, int> selectedItems)
    {
        if (gameOver || !orderActive) return;

        orderActive = false; // Se desactiva la orden actual

        if (!AreOrdersEqual(selectedItems, currentOrder))
        {
            orderText.text = "Incorrect Order! Waiting for the next order...";
            Debug.Log("The order is incorrect!");
            StartCoroutine(WaitAndGenerateNewOrder(5f));
            return;
        }

        if (isPoliceOrder && ContainsIllegalItem())
        {
            orderText.text = "It was a police trap! You got caught!";
            Debug.Log("It was a police trap! GAME OVER.");
            StartCoroutine(DelayedGameOver(3f)); // Espera 3 segundos antes de activar Game Over
            return;
        }

        orderText.text = "Correct Order! Waiting for the next order...";
        Debug.Log("Order successfully delivered!");
        StartCoroutine(WaitAndGenerateNewOrder(5f));
    }

    bool AreOrdersEqual(Dictionary<string, int> selected, Dictionary<string, int> order)
    {
        if (selected.Count != order.Count) return false;
        foreach (var item in selected)
        {
            if (!order.ContainsKey(item.Key) || order[item.Key] != item.Value)
                return false;
        }
        return true;
    }

    bool ContainsIllegalItem()
    {
        foreach (var item in currentOrder.Keys)
        {
            if (illegalItems.Contains(item))
                return true;
        }
        return false;
    }

    IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameOver();
    }

    void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }
}