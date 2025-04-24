using UnityEngine;

public class Proyectil : MonoBehaviour, IGolpeable
{
    [Header("TIPO DE DAÑO")]
    [SerializeField] private float danyoImpactoDirecto = 1f;
    [SerializeField] private float danyoImpactoArea = 1f;
    [SerializeField] private float danyoImpactoAreaEnOrigen = 1f;
    [SerializeField] private float danyoImpactoAreaEnBorde = 0.5f;

    [Header("SUBPROYECTILES")]
    [SerializeField] private int subProyectilesAGenerar = 3;
    [SerializeField] private float radioSubProyectiles = 4f;
    [SerializeField] private GameObject prefabSubProyectil;

    [SerializeField] private string[] tagsAfectados;

    private void Inicializar(float puntoInicial, float puntoFinal, float alturaSalto)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el tag del objetivo es golpeable
        bool golpeable = false;
        int i = 0;
        while (!golpeable)
        {
            if (other.CompareTag(tagsAfectados[i]))
            {
                golpeable = true;
            }
        }
        // Compruba que el enemigo se pueda golpear, si se puede, destruye el proyectil
        if (golpeable)
        {
            try
            {
                IGolpeable enemigo = other.GetComponent<IGolpeable>();
                enemigo.RecibeDanyo(danyoImpactoDirecto);
            }
            catch { return; }
        }
        else if (danyoImpactoArea > 0) // Si se choca con otra cosa como el terreno && el proyetil hace daño en area, calcula los enemigos afectados
        {
            Collider[] enemigos = Physics.OverlapSphere(transform.position, danyoImpactoArea);

            for (int j = 0; j < enemigos.Length; j++)
            {
                try
                {
                    // Calcula la distancia entre el proyectil y enemigo (para calcular el danyo)
                    IGolpeable enemigo = enemigos[j].GetComponent<IGolpeable>();
                    float distancia = Vector3.Distance(transform.position, enemigos[j].transform.position);
                    enemigo.RecibeDanyo(Mathf.Lerp(danyoImpactoAreaEnOrigen, danyoImpactoAreaEnBorde, distancia));
                }
                catch { continue; }
            }
        }
        Destroy(this.gameObject);
    }

    public void RecibeDanyo(float cantidad)
    {
        throw new System.NotImplementedException();
    }
}
