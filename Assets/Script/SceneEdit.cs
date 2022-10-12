using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEdit : MonoBehaviour
{
    public int numScene;
    public void MoveScene()
    {
        SceneManager.LoadScene(numScene);
    }
    public void ExitScene()
    {
        Application.Quit();
    }
    public void OpenDownload()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1_QlJrQPSq0ZyD8jcwRdRYrvZm23IofQg?usp=sharing");
    }
}
