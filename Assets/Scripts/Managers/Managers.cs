using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public static class Managers
{
    public static LevelManager Level { get; private set; }
    public static PauseManager Pause { get; private set; }
    public static UiManager Ui { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnLoad()
    {
        var operation = SceneManager.LoadSceneAsync("Managers", LoadSceneMode.Additive);
        operation.completed += OnOperationCompleted;
    }

    private static void OnOperationCompleted(AsyncOperation operation)
    {
        operation.completed -= OnOperationCompleted;

        Level = Object.FindObjectOfType<LevelManager>();
        Assert.IsNotNull(Level);

        Pause = Object.FindObjectOfType<PauseManager>();
        Assert.IsNotNull(Pause);

        Ui = Object.FindObjectOfType<UiManager>();
        Assert.IsNotNull(Ui);
    }
}
