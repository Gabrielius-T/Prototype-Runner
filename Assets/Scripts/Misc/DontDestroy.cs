using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {
    public string destroyOnSceneName; // name of the scene on which to destroy the object

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // not letting gameobject to be destroyed on scene change
    }

    private void Update()
    {
        if(destroyOnSceneName == SceneManager.GetActiveScene().name) {
            Destroy(gameObject);
        }
    }
}
