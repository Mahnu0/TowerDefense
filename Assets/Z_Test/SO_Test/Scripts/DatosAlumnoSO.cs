using UnityEngine;

[CreateAssetMenu(fileName = "DatosAlumnoSO", menuName = "Scriptable Objects/DatosAlumnoSO")]
public class DatosAlumnoSO : ScriptableObject
{
    public string nombre = "<Nombre>";
    public string primerApellido = "<Primer Apellido>";
    public string segundoApellido = "<Segundo Apellido>";

    [Range(0 ,10)] public float notaRedes = 10f;
    [Range(0, 10)] public float notaProyectos = 10f;
    [Range(0, 10)] public float notaMobiles = 10f;

    public void DebugAlumno()
    {
        Debug.Log(
            $"Nombre: {nombre}\n" +
            $"Primer Apellido: {primerApellido}\n" +
            $"Segundo Apellido: {segundoApellido}");
    }
}
