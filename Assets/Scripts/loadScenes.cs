using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScenes : MonoBehaviour
{  
    public void loadScene(string whichScene)
    {
        SceneManager.LoadScene(whichScene);
    }
}
