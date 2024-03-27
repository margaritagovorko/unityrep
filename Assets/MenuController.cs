using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVontroller : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void CloseApplication()
    {
        print("Exit");
        Application.Quit();
    }


}