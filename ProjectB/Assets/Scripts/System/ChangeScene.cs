using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum scenes{
    playScene, gameOver, MainMenu
}

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private scenes scene;

    /// <summary>
    /// switches scene to the set scene
    /// </summary>
    public void Switch(){
        SceneManager.LoadScene((int)scene);
    }

}
