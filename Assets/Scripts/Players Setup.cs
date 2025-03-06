using UnityEngine;
using UnityEngine.UI;

public class PlayersSetup : MonoBehaviour
{
    [HideInInspector] public int p1SPMeter = 0;
    public int p1MaxSPMeter = 10;
    public Slider p1SPSlider;

    [HideInInspector] public int p2SPMeter = 0;
    public int p2MaxSPMeter = 10;
    public Slider p2SPSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1SPSlider.maxValue = p1MaxSPMeter;
        p1SPSlider.value = p1SPMeter;

        p2SPSlider.maxValue = p2MaxSPMeter;
        p2SPSlider.value = p2SPMeter;
    }
}
