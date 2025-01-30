using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialCanvas; // Referencia al canvas
    public GameObject orderCanvas; // Referencia al Canvas de ordenes
    public GameObject inventoryCanvas; // Referencia al Canvas del inventario

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Si el jugador presiona espacio
        {
            tutorialCanvas.SetActive(false); // Desactiva el canvas del tutorial
            orderCanvas.SetActive(true); // Activa el canvas de ordenes
            inventoryCanvas.SetActive(true); // Activa el canvas de inventario
            Time.timeScale = 1f; // Restablece el tiempo del juego
        }
    }
}
