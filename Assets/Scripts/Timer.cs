using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countdown;
    public bool timerOn = false;
    public TextMeshProUGUI time;
    public Animator timerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        countdown = 31;
        timerOn = true;

        if (timerAnimator != null)
        {
            timerAnimator.Play("Timer Animation", -1, 0f);
        }
    }
}
