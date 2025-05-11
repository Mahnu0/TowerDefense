using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image sliderFill;
    [SerializeField]private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    Color orange;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;

        float percentageValue = currentValue / maxValue * 100;

        ChangeColor(percentageValue);
    }

    private void Start()
    {
        slider = GetComponent<Slider>();

        orange = new Color32(255, 128, 13, 255);
    }

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
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