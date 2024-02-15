using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused;
    public bool IsPaused 
    {
        get => _isPaused;
        set
        {
            _isPaused = value;
            Time.timeScale = _isPaused ? 0.0f : 1.0f;
        }
    }

    private void Start()
    {
        IsPaused = false;
    }
}
