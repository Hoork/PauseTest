using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.SetActiveScene(gameObject.scene);
        Managers.Ui.InitGameplayUi();
        Managers.Ui.InitPauseMenu();
    }
}
