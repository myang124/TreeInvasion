using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public void ChangeScenes(int sceneChange)
    {
        SceneManager.LoadScene(sceneChange);
    }
}
