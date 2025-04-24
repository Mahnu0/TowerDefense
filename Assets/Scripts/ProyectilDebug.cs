using UnityEngine;

public partial class Proyectil : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] bool debugDisparo;
    [SerializeField] Transform debugPuntoInicial;
    [SerializeField] Transform debugPuntoFinal;
    [SerializeField] float debugAlturaSalto;

    private void OnValidate()
    {
        if (debugDisparo)
        {
            debugDisparo = false;
            Inicializar(debugPuntoInicial.transform.position,
                debugPuntoFinal.transform.position,
                debugAlturaSalto);
        }
    }
}
