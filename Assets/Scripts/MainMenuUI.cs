using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Overlays;
#endif

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TMP_InputField playerNameInputUI;

    private void Start()
    {
        DisplayPlayerData();
    }

    private void DisplayPlayerData()
    {
        highScoreUI.text = "High Score: " + DataManager.instance.playerData.highestScoreName + " : " + DataManager.instance.playerData.highestScore;

        playerNameInputUI.text = DataManager.instance.playerData.playerName;
    }

    public void StartGame()
    {
        DataManager.instance.playerData.playerName = playerNameInputUI.text;
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        DataManager.instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
