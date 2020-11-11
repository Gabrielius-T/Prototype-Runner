using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }
}
