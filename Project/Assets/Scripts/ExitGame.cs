using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Método que se llama al presionar el botón
    public void QuitGame()
    {
        // Si estamos en el editor de Unity, mostramos un mensaje
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detener el juego en el editor
        #else
            Application.Quit(); // Cerrar el juego en la build
        #endif

        Debug.Log("Juego cerrado");
    }
}