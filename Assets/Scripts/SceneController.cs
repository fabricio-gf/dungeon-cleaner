using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public BlackScreen blackScreen;
    public LevelLoader levelLoader;

    public float fadeDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen.EndFade();
    }

    public void NextRound()
    {
        blackScreen.StartFade();
        StartCoroutine(FadeDelayNextRound());
    }

    public void ChangeScene(string sceneName)
    {
        blackScreen.StartFade();
        StartCoroutine(FadeDelay(sceneName));
    }

    public void RestartRound()
    {
        blackScreen.StartFade();
        StartCoroutine(FadeDelayRestartRound());
    }

    IEnumerator FadeDelay(string sceneName)
    {
        yield return new WaitForSeconds(fadeDelay);
        levelLoader.ChangeScene(sceneName);
    }

    IEnumerator FadeDelayNextRound()
    {
        yield return new WaitForSeconds(fadeDelay);
        levelLoader.NextRound();
    }

    IEnumerator FadeDelayRestartRound()
    {
        yield return new WaitForSeconds(fadeDelay);
        levelLoader.RestartRound();
    }
}
