using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Restablece el tiempo del juego antes de cambiar de escena
        SceneManager.LoadScene(0); // Carga la escena del menú principal
    }
}
