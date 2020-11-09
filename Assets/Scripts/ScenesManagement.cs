using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
    private const float WAIT_FOR_SOUNDS = 0.5f; // time to wait for sounds to play
    public Texture2D fadeOutTexture; // the texture that will overlay the screen. This can be a black image or a loading graphic 
    public float fadeSpeed = 0.8f; // the fading speed 
    public bool sceneFadeIn = false; // set to true for fading into scene
    public bool sceneFadeOut = false; // set to true for fading out of scene
    public float timeToTransition; // set to 0 if no transition is preffered
    private const int DRAW_DEPTH = -1000; // the texture's order in the draw hierarchy: a low number means it renders on top 
    private float alpha = 1.0f; // the texture's alpha value between 0 and 1 
    private int fadeDir = -100; // the direction to fade: in = -1 or out = 1 // -100 for no fading in by default
    private float fadeTime = 0.0f; // amount of time that fading in takes
    protected bool canChangeScene = false; // trigger which allows to change the scene

    private void OnEnable()
    {
        if (sceneFadeIn) {
            BeginFade(-1); 
        }
    }

    protected virtual void Update()
    {
        if (IsSceneComplete()) {
            Invoke("LoadNextScene", timeToTransition); // load next scene only after particular time
        }
    }

    protected virtual bool IsSceneComplete()
    {
        return false;
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(1));
    }

    public void LoadPreviousScene()
    {
        StartCoroutine(LoadScene(-1));
    }

    public void LoadAnyScene(int _index)
    {
        StartCoroutine(LoadScene(_index));
    }

    /// <summary>
    /// Load scene 
    /// </summary>
    /// <param name="_index"></param>
    /// <returns></returns>
    private IEnumerator LoadScene(int _index)
    {
        Time.timeScale = 1f;
        if (sceneFadeOut) {
            fadeTime = BeginFade(1);
            yield return new WaitForSeconds(fadeTime); // waits till fading ends
        }
        yield return new WaitForSeconds(WAIT_FOR_SOUNDS); // need to wait a bit for sounds to finish to play
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _index); // saving current game's progress
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime; // fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds 
        alpha = Mathf.Clamp01(alpha); // force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1 
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = DRAW_DEPTH; // make the black texture render on top (drawn last) 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); // draw the texture to fit the entire screen area 
    }

    /// <summary>
    /// Sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1 
    /// </summary>
    /// <param name="_direction"></param>
    /// <returns></returns>
    public float BeginFade(int _direction)
    {
        fadeDir = _direction; return (fadeSpeed);
    }
}
