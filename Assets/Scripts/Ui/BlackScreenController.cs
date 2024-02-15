using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class BlackScreenController : MonoBehaviour
{
    public Animator animator;
    private bool _isPlaying;

    private void Start()
    {
        Assert.IsNotNull(animator);
        _isPlaying = false;
    }

    public IEnumerator FadeInAsync()
    {
        _isPlaying = true;
        animator.SetTrigger("FadeIn");
        return new WaitWhile(() => _isPlaying);
    }

    public IEnumerator FadeOutAsync()
    {
        _isPlaying = true;
        animator.SetTrigger("FadeOut");
        return new WaitWhile(() => _isPlaying);
    }

    public void OnAnimationFinished()
    {
        _isPlaying = false;
    }
}
