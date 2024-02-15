using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject root;

    private void Start()
    {
        Assert.IsNotNull(root);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Managers.Level.isTransitioning)
        {
            Managers.Pause.IsPaused = !Managers.Pause.IsPaused;
            root.SetActive(Managers.Pause.IsPaused);
        }
    }

    public void OnToMenuClicked()
    {
        Managers.Level.ChangeToScene("MainMenu");
    }

    public void OnToNextLevelClicked()
    {
        var currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level1")
            Managers.Level.ChangeToScene("Level2");
    }
}
