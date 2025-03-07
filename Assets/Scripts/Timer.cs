using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalCountdown;
    public bool timerOn = false;
    public TextMeshProUGUI time;
    public Animator timerAnimator;

    private float countdown;
    private SetupQuestions setupQuestions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setupQuestions = FindAnyObjectByType<SetupQuestions>();
        countdown = totalCountdown;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn) 
        {
            if (countdown > 1)
            {
                countdown -= Time.deltaTime;
                updateTimer(countdown);
            }
            else
            {
                Debug.Log("Time's Up");
                countdown = 1;
                timerOn = false;

                if (setupQuestions.p1Turn)
                {
                    setupQuestions.p1Turn = false;
                    setupQuestions.p2Turn = true;
                }
                else if (setupQuestions.p2Turn)
                {
                    setupQuestions.p2Turn = false;
                    setupQuestions.p1Turn = true;
                }

                setupQuestions.LoadNewQuestion();
            }
        }
    }

    public void updateTimer(float countdown)
    {
        countdown = Mathf.FloorToInt(countdown);
        time.text = countdown.ToString();
    }

    public void ResetTime()
    {
        countdown = totalCountdown + 1;
        timerOn = true;

        if (timerAnimator != null)
        {
            timerAnimator.Play("Timer Animation", -1, 0f);
        }
    }
}
