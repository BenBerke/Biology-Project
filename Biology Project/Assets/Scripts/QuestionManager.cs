using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] List<string> questions = new List<string>();
    [SerializeField] List<List<string>> answers = new List<List<string>>();

    [SerializeField] TextMeshProUGUI question;

    string chosenQuestionString;
    int chosenQuestionIndex;
    CardSpawner _cardSpawner;

    private void Start()
    {
        _cardSpawner = GetComponent<CardSpawner>();

        int randomNumber = Random.Range(0, questions.Count);
        chosenQuestionIndex = randomNumber;
        chosenQuestionString = questions[chosenQuestionIndex];
        question.text = chosenQuestionString;
        StartCoroutine(Choose());

        if (SceneManager.GetActiveScene().name == "Mayoz")
        {
            answers.Add(new List<string>());
            answers[0].Add("Profaz I");
            answers[0].Add("Metafaz I");
            answers[0].Add("Anafaz I");
            answers[0].Add("Telofaz I");
            answers[0].Add("Profaz II");
            answers[0].Add("Anafaz II");
            answers.Add(new List<string>());
            answers[1].Add("4");
            answers[1].Add("2");
            answers[1].Add("3");
            answers[1].Add("1");
            answers[1].Add("5");
            answers[1].Add("6");
            answers.Add(new List<string>());
            answers[2].Add("23");
            answers[2].Add("46");
            answers[2].Add("12");
            answers[2].Add("24");
            answers[2].Add("22");
            answers[2].Add("18");
            answers.Add(new List<string>());
            answers[3].Add("Profaz I");
            answers[3].Add("Metafaz I");
            answers[3].Add("Anafaz II");
            answers[3].Add("Anafaz I");
            answers[3].Add("Profaz II");
            answers[3].Add("Telofaz I");
            answers.Add(new List<string>());
            answers[4].Add("Anafaz I");
            answers[4].Add("Metafaz I");
            answers[4].Add("Anafaz II");
            answers[4].Add("Profaz I");
            answers[4].Add("Profaz II");
            answers[4].Add("Telofaz I");
            answers.Add(new List<string>());
            answers[5].Add("Profaz I");
            answers[5].Add("Metafaz I");
            answers[5].Add("Anafaz II");
            answers[5].Add("Anafaz I");
            answers[5].Add("Profaz II");
            answers[5].Add("Telofaz I");
            answers.Add(new List<string>());
            answers[6].Add("4");
            answers[6].Add("1");
            answers[6].Add("2");
            answers[6].Add("3");
            answers[6].Add("6");
            answers[6].Add("5");
            answers.Add(new List<string>());
            answers[7].Add("Haploit");
            answers[7].Add("Diploit");
            answers[7].Add("Tetraploit");
            answers[7].Add("Monoploit");
            answers[7].Add("Poliploit");
            answers[7].Add("Aneuploit");
            answers.Add(new List<string>());
            answers[8].Add("Profaz I");
            answers[8].Add("Metafaz I");
            answers[8].Add("Telofaz I");
            answers[8].Add("Anafaz II");
            answers[8].Add("Profaz II");
            answers[8].Add("Anafaz I");
            answers.Add(new List<string>());
            answers[9].Add("Anafaz I");
            answers[9].Add("Metafaz I");
            answers[9].Add("Telofaz I");
            answers[9].Add("Profaz I");
            answers[9].Add("Profaz II");
            answers[9].Add("Anafaz II");
            answers.Add(new List<string>());
            answers[10].Add("Anafaz II");
            answers[10].Add("Metafaz I");
            answers[10].Add("Telofaz I");
            answers[10].Add("Profaz I");
            answers[10].Add("Profaz II");
            answers[10].Add("Anafaz I");
        }
        else
        {
            answers.Add(new List<string>());
            answers[0].Add("2");
            answers[0].Add("3");
            answers[0].Add("4");
            answers[0].Add("5");
            answers[0].Add("6");
            answers[0].Add("7");
            answers.Add(new List<string>());
            answers[1].Add("Somatik Hücreler");
            answers[1].Add("Hayvan Hücreleri");
            answers[1].Add("Bakteri Hücreleri");
            answers[1].Add("Mantar Hücreleri");
            answers[1].Add("Protozoa Hücreleri");
            answers[1].Add("Bitki Hücreleri");
            answers.Add(new List<string>());
            answers[2].Add("İki Kromatitli");
            answers[2].Add("Tek Kromatitli");
            answers[2].Add("Üç Kromatitli");
            answers[2].Add("Beş Kromatitli");
            answers[2].Add("Altı Kromatitli");
            answers[2].Add("Dört Kromatitli");
            answers.Add(new List<string>());
            answers[3].Add("Telofaz");
            answers[3].Add("Metafaz");
            answers[3].Add("Anafaz");
            answers[3].Add("Profaz");
            answers[3].Add("Sitokinez");
            answers[3].Add("Anafaz II");
            answers.Add(new List<string>());
            answers[4].Add("Vücut Hücreleri");
            answers[4].Add("Üreme Hücreleri");
            answers[4].Add("Sperm Hücreleri");
            answers[4].Add("Yumurta Hücreleri");
            answers[4].Add("Sentrozom");
            answers[4].Add("Embriyonik Hücreler");
            answers.Add(new List<string>());
            answers[5].Add("Sitoplazma");
            answers[5].Add("Kromozomlar");
            answers[5].Add("Sentrozomlar");
            answers[5].Add("Kinetokorlar");
            answers[5].Add("Hücre Zarı");
            answers[5].Add("Çekirdek Zarı");
        }
    }

    IEnumerator Choose()
    {
        yield return 0;
        int chosenNumber = Random.Range(0, _cardSpawner.cards.Count);
        _cardSpawner.cards[chosenNumber].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = answers[chosenQuestionIndex][0];
        _cardSpawner.cards[chosenNumber].GetComponent<CardPicker>().rightAnswer = true;
        foreach (GameObject card in _cardSpawner.cards)
        {
            if (!card.GetComponent<CardPicker>().rightAnswer)
            {
                int rn = Random.Range(1, answers[chosenQuestionIndex].Count);
                card.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = answers[chosenQuestionIndex][rn];
                answers[chosenQuestionIndex].RemoveAt(rn);
            }
        }
    }
}
