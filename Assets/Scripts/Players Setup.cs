using UnityEngine;
using UnityEngine.UI;

public class PlayersSetup : MonoBehaviour
{
    [HideInInspector] public int p1Health;
    [HideInInspector] public int p1SPMeter;
    public int p1MaxHealth = 100;
    public int p1MaxSPMeter = 10;
    public Slider p1HealthSlider;
    public Slider p1SPSlider;

    [HideInInspector] public int p2Health;
    [HideInInspector] public int p2SPMeter;
    public int p2MaxHealth = 100;
    public int p2MaxSPMeter = 10;
    public Slider p2HealthSlider;
    public Slider p2SPSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1Health = p1MaxHealth;
        p1HealthSlider.maxValue = p1MaxHealth;
        p1HealthSlider.value = p1Health;
        p1SPSlider.value = p1SPMeter;

        p2Health = p2MaxHealth;
        p2HealthSlider.maxValue = p2MaxHealth;
        p2HealthSlider.value = p2Health;
        p2SPSlider.value = p2SPMeter;
    }
}
