using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl 
{

    public Dictionary<string, SceneBase> dict_scene;
    private static SceneControl instance;


    public static SceneControl GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("SceneControl doesn't exist");
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public SceneControl()
    {
        dict_scene= new Dictionary<string, SceneBase>();
    }
    /// <summary>
    /// Load Scene
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="sceneBase"></param>
    public void LoadScene(string sceneName, SceneBase sceneBase)
    {
        if (!dict_scene.ContainsKey(sceneName))
        {
            dict_scene.Add(sceneName, sceneBase);
        }
        if (dict_scene.ContainsKey(SceneManager.GetActiveScene().name))
        {
            dict_scene[SceneManager.GetActiveScene().name].ExitScene();
        }
        else
        {
            Debug.LogError($"Dictionary of SceneControl doesn't contain{SceneManager.GetActiveScene().name}");
        }

        #region Pop()
        GameRoot.GetInstance().UIManager_Root.Pop(true);
        #endregion
        SceneManager.LoadScene(sceneName);
        sceneBase.EnterScene();
    }
}
