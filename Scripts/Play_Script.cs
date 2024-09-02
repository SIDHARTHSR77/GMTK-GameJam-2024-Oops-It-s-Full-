using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play_Script : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit(){
        Application.Quit();
    }

    public void About(){
        SceneManager.LoadSceneAsync(4);
    }

    public void MainMenu(){
        SceneManager.LoadSceneAsync(0);
    }

    public void Controls(){
        SceneManager.LoadSceneAsync(5);
    }
}
