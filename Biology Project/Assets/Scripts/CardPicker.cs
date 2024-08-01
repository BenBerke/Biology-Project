using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPicker : MonoBehaviour
{
    [HideInInspector] public bool rightAnswer;
    GameObject cardManager;
    ShuffleManager _shuffleManager;
    HealthManager _healthManager;

    bool preventTouching;
    private void Start()
    {
        preventTouching = false;
        cardManager = GameObject.FindGameObjectWithTag("CardManager");
        _shuffleManager = cardManager.GetComponent<ShuffleManager>();
        _healthManager = cardManager.GetComponent<HealthManager>();
    }
    private void OnMouseDown()
    {
        preventTouching = true;
        if (!preventTouching) return;
        if (_shuffleManager.doneShuffling)
        {
            if (rightAnswer) StartCoroutine(_healthManager.Win());
            else
            {
                StartCoroutine(_healthManager.TakeDamage());
                cardManager.GetComponent<CardSpawner>().RevealCorrectText();
            }
        }
    }
}
