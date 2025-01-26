using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void loadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}
