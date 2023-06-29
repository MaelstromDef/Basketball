using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;
    [Header("Scenes")]
    [SerializeField] string TitleScene = "Title";
    [SerializeField] string MainScene = "Main";

    [Header("Debuggers")]
    [SerializeField] bool test = false;

    private void Awake()
    {
        ImplementSingleton();
    }

    #region Listeners

    // Play the game
    public void Play()
    {
        SceneManager.LoadScene(MainScene);
        
        if (test) Invoke(nameof(ToTitle), 3f);
    }

    // Back to title screen
    // NOTE: TEST BUTTON GRAB LATER!!!! delete this when done so ik when its done
    public void ToTitle()
    {
        SceneManager.LoadScene(TitleScene);     // Load scene
        Invoke(nameof(LoadPlayButton), 0.5f);   // Reattach Play Button
    }

    #endregion

    #region Utility

    void LoadPlayButton()
    {
        // Grab play button and add listener
        Button[] buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
        var btns =
            from button in buttons
            where button.gameObject.name == "Play"
            select button;

        btns.First().onClick.AddListener(Play);
    }

    // Called on Awake. Ensures singleton
    void ImplementSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}
