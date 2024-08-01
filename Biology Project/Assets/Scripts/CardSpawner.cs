using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] GameObject cam;

    [SerializeField] float rowDistance, columnDistance;

    float lastCardPosX;

    public List<GameObject> cards = new List<GameObject>();
    public List<Vector2> pos = new List<Vector2>();

    [SerializeField] Color correctColor;

    QuestionManager _questionManager;

    private void Start()
    {
        _questionManager = GetComponent<QuestionManager>();
        SpawnCards(3);
    }
    public void SpawnCards(int row)
    {
        lastCardPosX = 0;
        for (int i = 0; i < row; i++)
        {
            GameObject c = Instantiate(card, gameObject.transform);
            c.transform.position = new Vector2(lastCardPosX, 0);
            cards.Add(c);
            lastCardPosX += rowDistance;

            if (i == 1) cam.transform.position = new Vector2(c.transform.position.x, cam.transform.position.y);
        }
        lastCardPosX = 0;
        for (int i = 0; i < row; i++)
        {
            GameObject c = Instantiate(card, gameObject.transform);
            c.transform.position = new Vector2(lastCardPosX, -columnDistance);
            cards.Add(c);
            lastCardPosX += rowDistance;

            if (i == 1) cam.transform.position = new Vector2(cam.transform.position.x, c.transform.position.y + rowDistance/2);
        }
        for (int i = 0; i < cards.Count; i++)
        {
            pos.Add(cards[i].transform.position);
        }

        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
    }

    public void DisableCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = new Vector2(1000, 1000);
        }

        cards.Clear();
        pos.Clear();
    }

    public void RevealCorrectText()
    {
        foreach(GameObject card in cards)
        {
            if (card.GetComponent<CardPicker>().rightAnswer)
            {
                card.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                card.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = correctColor;
            }
        }
    }
}
