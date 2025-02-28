using UnityEngine;
using UnityEngine.UI;

public class PlayersSetup : MonoBehaviour
{
    [HideInInspector] public int p1Health;
    [HideInInspector] public int p2Health;
    public int p1MaxHealth = 20;
    public int p2MaxHealth = 20;
    public Slider p1HealthSlider;
    public Slider p2HealthSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1Health = p1MaxHealth;
        p1HealthSlider.maxValue = p1MaxHealth;
        p1HealthSlider.value = p1Health;

        p2Health = p2MaxHealth;
        p2HealthSlider.maxValue = p2MaxHealth;
        p2HealthSlider.value = p2Health;
    }
}
