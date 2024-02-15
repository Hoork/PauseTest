using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class UiManager: MonoBehaviour
{
    // Overlay
    public BlackScreenController blackScreen;
    public GameObject loadingLabel;

    // Prefabs
    public GameObject canvasPrefab;
    public GameObject gameplayUiPrefab;
    public GameObject pauseMenuPrefab;

    // Injected
    public GameObject Canvas { get; private set; }
    public GameplayUiController GameplayUi { get; private set; }
    public PauseMenuController PauseMenu { get; private set; }

    private void Start()
    {
        Assert.IsNotNull(blackScreen);
        Assert.IsNotNull(loadingLabel);
        Assert.IsNotNull(canvasPrefab);
        Assert.IsNotNull(gameplayUiPrefab);
        Assert.IsNotNull(pauseMenuPrefab);
    }

    public void InitGameplayUi()
    {
        Assert.IsFalse(SceneManager.GetActiveScene().name == "Managers");

        if (GameplayUi != null)
            Destroy(GameplayUi.gameObject);

        if (Canvas == null)
        {
            Canvas = Instantiate(canvasPrefab);
            Canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        }

        var gameObject = Instantiate(gameplayUiPrefab, Canvas.transform);
        GameplayUi = gameObject.GetComponent<GameplayUiController>();
    }

    public void InitPauseMenu()
    {
        Assert.IsFalse(SceneManager.GetActiveScene().name == "Managers");

        if (PauseMenu != null)
            Destroy(PauseMenu.gameObject);

        if (Canvas == null)
        {
            Canvas = Instantiate(canvasPrefab);
            Canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        }

        var gameObject = Instantiate(pauseMenuPrefab, Canvas.transform);
        PauseMenu = gameObject.GetComponent<PauseMenuController>();
    }

    public IEnumerator ShowLoadingScreenAsync()
    {
        yield return blackScreen.FadeInAsync();
        loadingLabel.SetActive(true);
    }

    public IEnumerator HideLoadingScreenAsync()
    {
        loadingLabel.SetActive(false);
        yield return blackScreen.FadeOutAsync();
    }
}