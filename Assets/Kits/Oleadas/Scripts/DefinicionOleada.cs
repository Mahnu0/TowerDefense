using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DefinicionOleada", menuName = "Scriptable Objects/DefinicionOleada")]
public class DefinicionOleada : ScriptableObject
{
    [System.Serializable]
    public class BloqueEnemigo
    {
        public Enemigo tipoEnemigos;
        public int cantidad;
        public float tiempoEntreEnemigos;
    }

    public BloqueEnemigo[] bloques;
}
