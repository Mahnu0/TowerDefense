using UnityEngine;

public class DebugDatosAlumnos : MonoBehaviour
{
    [SerializeField] private DatosAlumnoSO[] datosAlumnos;

    private void Start()
    {
        foreach (DatosAlumnoSO dat in datosAlumnos)
        {
            DatosAlumnoSO instanciaDAT = Instantiate(dat);
            instanciaDAT.DebugAlumno();
            instanciaDAT.nombre = "Enrique";
            instanciaDAT.DebugAlumno();
        }
    }
}
