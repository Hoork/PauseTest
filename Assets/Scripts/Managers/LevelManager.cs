using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    public bool isTransitioning { get; private set; }

    public void ChangeToScene(string name)
    {
        StartCoroutine(ChangeToSceneAsync(name));
    }

    private IEnumerator ChangeToSceneAsync(string name)
    {
        if (isTransitioning)
            yield break;
        isTransitioning = true;
        Managers.Pause.IsPaused = true;
        yield return Managers.Ui.ShowLoadingScreenAsync();

        var oldScene = SceneManager.GetActiveScene();
        var unloadOperation = SceneManager.UnloadSceneAsync(oldScene);
        yield return new WaitUntil(() => unloadOperation.isDone);

        var loadOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield return new WaitUntil(() => loadOperation.isDone);
        yield return new WaitForSecondsRealtime(2); // Симуляция загрузки

        yield return Managers.Ui.HideLoadingScreenAsync();
        Managers.Pause.IsPaused = false;
        isTransitioning = false;
    }
}
