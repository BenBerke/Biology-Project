using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("music") == 1) GetComponent<AudioSource>().volume = 0;
        else GetComponent<AudioSource>().volume = 1;

        if (SceneManager.GetActiveScene().name == "MusicMenu")
            SceneManager.LoadScene(1);
    }
}
