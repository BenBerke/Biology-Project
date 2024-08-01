using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHealth, currentHealth;
    [SerializeField] float delayBetweenRounds;

    [SerializeField] Image h0, h1, h2;
    [SerializeField] Sprite emptyHeart;

    [SerializeField] GameObject looseMenuParent;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject heartsParent;
    [SerializeField] GameObject questionParent;

    [SerializeField] TextMeshProUGUI scoreText;

    CardSpawner _cardSpawner;

    private void Start()
    {
        currentHealth = PlayerPrefs.GetInt("health");
        looseMenuParent.SetActive(false);
        _cardSpawner = GetComponent<CardSpawner>();
        if (currentHealth <= 2) h2.sprite = emptyHeart;
        if (currentHealth <= 1) h1.sprite = emptyHeart;
        scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
    }
    public IEnumerator Win()
    {
        PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore")+1);
        cam.GetComponent<AudioSource>().Play();
        _cardSpawner.DisableCards();
        yield return new WaitForSeconds(delayBetweenRounds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
    }

    public IEnumerator TakeDamage()
    {
        bool l = false;
        GetComponent<AudioSource>().Play();
        currentHealth--;
        PlayerPrefs.SetInt("health", currentHealth);
        if (currentHealth <= 2) h2.sprite = emptyHeart;
        if (currentHealth <= 1) h1.sprite = emptyHeart;
        if (currentHealth <= 0)
        {
            l = true;
            h0.sprite = emptyHeart;
            Loose();
        }
        yield return new WaitForSeconds(delayBetweenRounds);
        if(!l)  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Loose()
    {
        looseMenuParent.SetActive(true);
        heartsParent.SetActive(false);
        questionParent.SetActive(false);
        _cardSpawner.DisableCards();
        SaveHighScore(PlayerPrefs.GetInt("CurrentScore"));
    }

    private void SaveHighScore(int newScore)
    {
        int highScore = 0;

        if (SceneManager.GetActiveScene().name == "Mitoz")
            highScore = PlayerPrefs.GetInt("mitozHighScore");
        else highScore = PlayerPrefs.GetInt("mayozHighScore");

        if (newScore > highScore)
        {
            if (SceneManager.GetActiveScene().name == "Mitoz")
                PlayerPrefs.SetInt("mitozHighScore", newScore);
            else
            {
                print("mayoz");
                PlayerPrefs.SetInt("mayozHighScore", newScore);
            }
            PlayerPrefs.Save();
        }
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
