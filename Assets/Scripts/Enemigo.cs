using UnityEngine;
using UnityEngine.Splines;

public class Enemigo : MonoBehaviour, IGolpeable
{
    public SplineContainer ruta;
    [SerializeField] private float velocidad = 4f;
    [SerializeField] private float vida, vidaMaxima = 2f;
    public HealthBar healthBar;

    [SerializeField] private float umbralLlegada = 1f;

    float distanciaEntrePuntos = 5f;

    Vector3[] pathPointsCache;
    Vector3 posicionSiguiente;
    int indiceSiguientePosicion = 1;

    public void EstablecerRuta(SplineContainer r)
    {
        ruta = r;
    }

    private void Start()
    {
        float longitudRuta = ruta.CalculateLength();
        int cantidadPuntos = Mathf.CeilToInt(longitudRuta / distanciaEntrePuntos) + 1;

        pathPointsCache = new Vector3[cantidadPuntos];
        for (int i = 0; i < cantidadPuntos; i++)
        {
            float t = (float)i / (float)cantidadPuntos;
            pathPointsCache[i] = ruta.EvaluatePosition(t);
        }

        transform.position = pathPointsCache[0];
        posicionSiguiente = pathPointsCache[indiceSiguientePosicion];

        vida = vidaMaxima;

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.UpdateHealthBar(vida, vidaMaxima);
    }

    private void Update()
    {
        Vector3 direccion= posicionSiguiente - transform.position;
        Vector3 velocidadMovimiento = direccion.normalized * velocidad;
        transform.position += velocidadMovimiento * Time.deltaTime;

        if (Vector3.Distance(posicionSiguiente, transform.position) < umbralLlegada)
        {
            indiceSiguientePosicion++;

            if (indiceSiguientePosicion == pathPointsCache.Length)
                Destroy(gameObject);
            else
                posicionSiguiente = pathPointsCache[indiceSiguientePosicion];
        }
    }

    public void RecibeDanyo(float cantidad)
    {
        vida -= cantidad;

        if (vida > 0)
            healthBar.UpdateHealthBar(vida, vidaMaxima);
        else
            Destroy(this.gameObject);
    }
}
