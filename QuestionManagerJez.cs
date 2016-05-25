using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
public class QuestionManagerJez : MonoBehaviour
{

    public GameObject questionMenu;
    public GameObject deathMenu;
    public GameObject solutionMenu;
    public Text solutionText;
    public GameManager gameManager;
    private List<Question> questions;
    public TextAsset file;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    private bool wasCorrect;

    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    private List<Text> answers = new List<Text>(4);
    private int answerIndex;

    // Use this for initialization
    void Start()
    {
        if (questions == null)
        {
            file = Resources.Load("PitanjaJez") as TextAsset;
            answers.Add(answer1);
            answers.Add(answer2);
            answers.Add(answer3);
            answers.Add(answer4);
            LoadQuestions();
        }
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions;
        }
    }

    public void ShowQuestion()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions;
        }
        GetRandomQuestion();
        deathMenu.SetActive(false);
        questionMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        unansweredQuestions.RemoveAt(randomQuestionIndex);
        question.text = currentQuestion.question;
        int[] indexes = permutatate();
        answerIndex = indexes[0];
        answers[indexes[0]].text = currentQuestion.answer;
        answers[indexes[1]].text = currentQuestion.wrongAnswer1;
        answers[indexes[2]].text = currentQuestion.wrongAnswer2;
        answers[indexes[3]].text = currentQuestion.wrongAnswer3;
    }

    void LoadQuestions() {
        questions = new List<Question>();
        string text = file.text;
        string[] lines = Regex.Split ( text, "\n" );
        Question question = new Question();
        for ( int i=0; i < lines.Length;i+=5) {
            question = new Question();
            question.question = lines[i];
            question.answer = lines[i+1];
            question.wrongAnswer1 = lines[i+2];
            question.wrongAnswer2 = lines[i+3];
            question.wrongAnswer3 = lines[i+4];
            questions.Add(question);        
        }
    }

    public void pressButton(int index)
    {
        questionMenu.SetActive(false);
        solutionMenu.SetActive(true);
        wasCorrect = answerIndex == index;
        if (wasCorrect)
        {
            solutionText.text = "Congratulations! You can now continue the game.";
        }
        else
        {
            solutionText.text = "Unfortunately the correct answer is: " + currentQuestion.answer + ".\n"
                + "The question was: " + currentQuestion.question;
        }
    }

    public void pressButtonOK()
    {
        solutionMenu.SetActive(false);
        if (wasCorrect)
        {
            gameManager.Continue();
        }
        else
        {
            FindObjectOfType<GameManager>().Reset();
        }
    }



    public void pressButton1()
    {
        pressButton(0);
    }

    public void pressButton2()
    {
        pressButton(1);
    }

    public void pressButton3()
    {

        pressButton(2);
    }

    public void pressButton4()
    {
        pressButton(3);
    }


    public int[] permutatate()
    {
        List<int> indeksiList = new List<int>(4);
        int indeks;
        int count = 0;
        while (count < 4)
        {
            indeks = Random.Range(0, 4);
            if (!indeksiList.Contains(indeks))
            {
                indeksiList.Add(indeks);
                count++;
            }
        }
        return indeksiList.ToArray();
    }
}
