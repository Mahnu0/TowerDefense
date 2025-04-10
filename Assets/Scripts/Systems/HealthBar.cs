using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image sliderFill;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    Color orange;
    Camera camera;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;

        float percentageValue = currentValue / maxValue * 100;

        ChangeColor(percentageValue);
    }

    private void Start()
    {
        // Crear el color naranja para la barra de vida
        // Color32(r, g, b, a) permite usar valores RGB de 0 a 255
        orange = new Color32(255, 128, 13, 255);
        camera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }

    private void ChangeColor(float percentageOfHitPoints)
    {
        if (percentageOfHitPoints >= 50)
            sliderFill.color = Color.green;
        else if (percentageOfHitPoints >= 25)
            sliderFill.color = orange;
        else
            sliderFill.color = Color.red;
    }
}