using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1); // Cargar la escena jugable
        Time.timeScale = 0f; // Detiene el tiempo del juego para revisar el tutorial
    }
    
    /*public void QuitGame()
    {
        Application.Quit(); // Cierra el juego (solo funciona en versión compilada)
        Debug.Log("Saliendo del juego..."); // Para probar en el editor
    }*/
}
