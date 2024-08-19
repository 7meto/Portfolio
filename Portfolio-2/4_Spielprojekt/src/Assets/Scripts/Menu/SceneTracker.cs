using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public static SceneTracker Instance { get; private set; }
    public static string previousScene;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        public void LoadOptions()
        {
            previousScene = SceneManager.GetActiveScene().name;          
            SceneManager.LoadScene(2);
        }

        public void ReturnToPreviousScene()
        {
            SceneManager.LoadScene(previousScene);
        }
    

}

