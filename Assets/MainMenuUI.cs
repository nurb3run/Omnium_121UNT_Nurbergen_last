using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // GameScene
    }

    public void OpenLevels()
    {
        Debug.Log("Levels menu");
    }

    public void OpenOptions()
    {
        Debug.Log("Options menu");
    }
}