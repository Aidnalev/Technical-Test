using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    //Para cargar escenas por index
    public void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
    //Cerrar Juego
    public void Salir() => Application.Quit();
}
