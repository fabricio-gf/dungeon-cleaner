using System.Collections;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    Animator animator = null;
    public float fadeDelay = 1;
    public float animationDelay = 0.5f;

    public delegate void BlackScreenDelegate();
    public BlackScreenDelegate duringFade;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartFade()
    {
        print("start fade");
        animator.SetTrigger("Open");
        StartCoroutine(FadeDelay());
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(animationDelay);
        duringFade?.Invoke();
        yield return new WaitForSeconds(fadeDelay);
        EndFade();
    }

    public void EndFade()
    {
        print("end fade");
        animator.SetTrigger("Close");
    }
}
