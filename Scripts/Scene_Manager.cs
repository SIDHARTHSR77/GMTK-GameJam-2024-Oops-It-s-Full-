using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void Next(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Prev(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex -1);
    }
}
