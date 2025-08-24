using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loadmanager : MonoBehaviour
{
  public GameObject gameOver;
  public GameObject listMenu;
  public GameObject gameCanvas;
  void Start()
  {
    gameOver.SetActive(false);
    listMenu.SetActive(false);
  }

  public void StartGame()
  {
    SceneManager.LoadScene("GameScene");
  }

  public void ExitGame()
  {
    Debug.Log("Exit button pressed. Quitting game...");
    Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
  }

  public void GoMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

  public void MenuButtonClick()
  {
    gameCanvas.SetActive(false);
    listMenu.SetActive(true);
  }

  public void ContinueButtonClick()
  {
    listMenu.SetActive(false);
    gameCanvas.SetActive(true);
  }
}
