using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {
    public void StartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
