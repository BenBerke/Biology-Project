using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    CardSpawner _cardSpawner;

    [SerializeField] float waitSecondsBeforeShuffle;
    [SerializeField] float speed;

    public List<int> remainingPositions = new List<int>();

    [HideInInspector] public bool doneShuffling;

    private void Start()
    {
        _cardSpawner = GetComponent<CardSpawner>();
        for(int i = 0; i < 6; i++)
        {
            remainingPositions.Add(i);
        }

        StartCoroutine(Shuffle());
    }

    IEnumerator Shuffle()
    {
        yield return new WaitForSeconds(waitSecondsBeforeShuffle);
        for(int i = 0; i < _cardSpawner.cards.Count; i++)
        {
            int rn = Random.Range(0, remainingPositions.Count);
            if (rn == i) rn = remainingPositions.Count-1;
            _cardSpawner.cards[i].GetComponent<CardMover>().Move(_cardSpawner.pos[remainingPositions[rn]], speed);
            remainingPositions.RemoveAt(rn);
        }

        doneShuffling = true;
    }
}
