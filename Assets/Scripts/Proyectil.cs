using UnityEngine;
using DG.Tweening;

public partial class Proyectil : MonoBehaviour
{
    [SerializeField] private float tiempoMovimiento = 1f;

    //[SerializeField] private float velocidad = 1f;

    [Header("TIPO DE DAÑO")]
    [SerializeField] private float danyoImpactoDirecto = 1f;
    [SerializeField] private float radioDanyoArea = 1f;
    [SerializeField] private float danyoAreaEnOrigen = 1f;
    [SerializeField] private float danyoAreaEnBorde = 0.5f;

    [Header("SUBPROYECTILES")]
    [SerializeField] private int subProyectilesAGenerar = 3;
    [SerializeField] private float radioSubProyectiles = 4f;
    [SerializeField] private float alturaSaltoSubProyectil = 5f;
    [SerializeField] private GameObject prefabSubProyectil;

    [SerializeField] private string[] tagsAfectados;

    public void Inicializar(Vector3 puntoInicial, Vector3 puntoFinal, float alturaSalto)
    {
        transform.position = puntoInicial;
        transform.DOJump(puntoFinal, alturaSalto, 1, tiempoMovimiento).
            OnComplete(() => RealizaLaDestruccion());
        //transform.DOJump(puntoFinal, alturaSalto, 1, velocidad).SetSpeedBased();
    }

    private void OnComplete()
    {
        RealizaLaDestruccion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ColliderEsAfectable(other))
        {
            other.GetComponent<IGolpeable>()?.RecibeDanyo(danyoImpactoDirecto);
            RealizaLaDestruccion();
        }
    }

    void RealizaLaDestruccion()
    {
        Destroy(gameObject);

        DanyarPorDestruccion();

        GeneraSubProyectiles();
    }

    private void GeneraSubProyectiles()
    {
        for (int i = 0; i < subProyectilesAGenerar; i++)
        {
            Vector2 posicionAleatoriaXY = Random.insideUnitCircle;
            Vector3 posicionAleatoria = new Vector3(posicionAleatoriaXY.x, 0f, posicionAleatoriaXY.y);

            posicionAleatoria *= radioSubProyectiles;
            posicionAleatoria += transform.position;

            GameObject newProyectil = Instantiate(prefabSubProyectil);
            prefabSubProyectil.GetComponent<Proyectil>().Inicializar(
                transform.position, posicionAleatoria, alturaSaltoSubProyectil);
        }
    }

    private void DanyarPorDestruccion()
    {
        Collider[] objetosCercanos = Physics.OverlapSphere(transform.position, radioDanyoArea);

        foreach (Collider c in objetosCercanos)
        {
            if (ColliderEsAfectable(c))
            {
                float distanciaAlCentro = Vector3.Distance(c.transform.position, transform.position);
                float t = distanciaAlCentro / radioDanyoArea;

                float danyo = Mathf.Lerp(danyoAreaEnOrigen, danyoAreaEnBorde, Mathf.Clamp01(t));
                c.GetComponent<IGolpeable>().RecibeDanyo(danyo);
            }
        }
    }

    private bool ColliderEsAfectable(Collider other)
    {
        bool esAfectable = false;

        foreach (string t in tagsAfectados)
        {
            if (other.CompareTag(t))
                esAfectable = true;
        }

        return esAfectable;
    }
}
