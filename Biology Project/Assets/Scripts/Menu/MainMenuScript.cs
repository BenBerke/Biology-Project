using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI mayozHighScoreText;
    [SerializeField] TextMeshProUGUI mitozHighScoreText;
    private void Start()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("health", 3);
        mayozHighScoreText.text = PlayerPrefs.GetInt("mitozHighScore").ToString();
        mitozHighScoreText.text = PlayerPrefs.GetInt("mayozHighScore").ToString();
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
