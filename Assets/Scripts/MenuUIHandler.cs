using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField playerInputName;
    public string playerName;

    private void Awake()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        playerName = playerInputName.text;
    }

    public void Exit()
    {
        /* All lines starting with # aren’t really “code”. They won’t be compiled and executed, they’re actually instructions for the compiler.
           In this case, when the code is compiled inside the Editor then UNITY_EDITOR is true, it will keep the EditorApplication.ExitPlaymode() 
           code and discard the Application.Quit. When you build a player, UNITY_EDITOR will be false, and so it will keep Application.Quit() 
           and discard EditorApplication.ExitPlaymode() ! */
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
