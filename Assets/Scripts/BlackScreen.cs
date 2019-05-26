using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public Image image = null;
    Animator animator = null;
    public float fadeDelay = 1;
    public float animationDelay = 0.5f;

    public delegate void BlackScreenDelegate();
    public BlackScreenDelegate duringFade;
    public BlackScreenDelegate afterFade;

    private void Awake()
    {
        image = GetComponent<Image>();
        animator = GetComponent<Animator>();
    }

    public void StartFade()
    {
        image.enabled = true;
        animator.SetTrigger("Open");
        StartCoroutine(FadeDelay());
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(animationDelay);
        duringFade?.Invoke();
        yield return new WaitForSeconds(fadeDelay);
        EndFade();
        yield return new WaitForSeconds(animationDelay);
        afterFade?.Invoke();
    }

    public void EndFade()
    {
        animator.SetTrigger("Close");
        StartCoroutine(EndFadeDelay());
    }

    IEnumerator EndFadeDelay()
    {
        yield return new WaitForSeconds(animationDelay);
        image.enabled = false;
    }
}
