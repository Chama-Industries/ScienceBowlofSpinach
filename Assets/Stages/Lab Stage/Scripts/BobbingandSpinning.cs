using UnityEngine;

public class BobbingAndSpinning : MonoBehaviour
{
    public float bobbingSpeed = 2f; // Speed of the up and down motion
    public float bobbingHeight = 0.5f; // Height of the bobbing motion
    public float rotationSpeed = 100f; // Base rotation speed
    public float randomRotationFactor = 30f; // How much random variation in rotation

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Bobbing motion
        float newY = startPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Unstable spinning rotation
        float randomX = Mathf.Sin(Time.time * bobbingSpeed) * randomRotationFactor;
        float randomY = Mathf.Cos(Time.time * bobbingSpeed * 1.5f) * randomRotationFactor;
        float randomZ = Mathf.Sin(Time.time * bobbingSpeed * 2f) * randomRotationFactor;

        transform.Rotate(new Vector3(rotationSpeed + randomX, rotationSpeed + randomY, rotationSpeed + randomZ) * Time.deltaTime);
    }
}