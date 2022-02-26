using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCrontroller : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(sceneName);
        }

    }
}
