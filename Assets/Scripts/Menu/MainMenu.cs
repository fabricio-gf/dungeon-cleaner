using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public BlackScreen blackScreen;
    public LevelLoader levelLoader;

    public float fadeDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen.EndFade();
    }

    public void ChangeScene(string sceneName)
    {
        blackScreen.StartFade();
        StartCoroutine(FadeDelay(sceneName));
    }

    IEnumerator FadeDelay(string sceneName)
    {
        yield return new WaitForSeconds(fadeDelay);
        levelLoader.ChangeScene(sceneName);
    }
}
