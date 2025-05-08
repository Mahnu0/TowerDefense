using UnityEngine;

public class Torre : MonoBehaviour, IGolpeable
{
    [SerializeField] private float resistencia;

    private HealthBar healthBar;
    private float resistenciaMax;

    private void Start()
    {
        resistenciaMax = resistencia;

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.UpdateHealthBar(resistencia, resistenciaMax);
    }

    public void RecibeDanyo(float cantidad)
    {
        resistencia -= cantidad;
        healthBar.UpdateHealthBar(resistencia, resistenciaMax);

        if (resistencia <= 0)
            Destroy(gameObject);
    }
}
