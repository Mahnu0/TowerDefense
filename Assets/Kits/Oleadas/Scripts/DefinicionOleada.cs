using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DefinicionOleada", menuName = "Scriptable Objects/DefinicionOleada")]
public class DefinicionOleada : ScriptableObject
{
    [System.Serializable]
    public class BloqueEnemigo
    {
        [SerializeField] public GameObject tipoEnemigos;
        [SerializeField] public int cantidad;
        [SerializeField] public float enemigosPorSegundo;
    }

    public BloqueEnemigo[] bloques;
}
