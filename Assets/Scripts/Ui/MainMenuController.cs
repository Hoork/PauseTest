using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.SetActiveScene(gameObject.scene);
    }

    public void OnStartClicked()
    {
        Managers.Level.ChangeToScene("Level1");
    }
}
