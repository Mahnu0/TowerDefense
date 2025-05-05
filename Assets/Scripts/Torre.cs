using UnityEngine;

public class Torre : MonoBehaviour, IGolpeable
{
    [SerializeField] private float resistencia;

    public void RecibeDanyo(float cantidad)
    {
        resistencia -= cantidad;

        if (resistencia <= 0)
            Destroy(gameObject);
    }
}
