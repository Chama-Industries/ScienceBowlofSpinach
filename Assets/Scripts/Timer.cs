using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countdown;
    public bool timerOn = false;
    public TextMeshProUGUI time;

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
            if(countdown > 0)
            {
                countdown -= Time.deltaTime;
                updateTimer(countdown);
            }
            else
            {
                Debug.Log("Time's Up");
                countdown = 0;
                timerOn = false;
            }
        }
    }

    void updateTimer(float countdown)
    {
        countdown = Mathf.FloorToInt(countdown);

        time.text = countdown.ToString();
    }

    public void ResetTime()
    {

    }
}
