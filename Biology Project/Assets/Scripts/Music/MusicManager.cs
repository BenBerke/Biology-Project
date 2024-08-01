using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    [SerializeField] GameObject button;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    public void ChangeMusic()
    {
        if (PlayerPrefs.GetInt("music") == 1)
            PlayerPrefs.SetInt("music", -1);

        else PlayerPrefs.SetInt("music", 1);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            button.GetComponent<Image>().sprite = off;
        }
            
        else 
        {
            button.GetComponent<Image>().sprite = on;
        }
    }
}
