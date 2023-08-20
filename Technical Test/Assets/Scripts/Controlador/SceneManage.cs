using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    //Poder usar el load en boton
    public void ButtonLoad(int sceneIndex)
    {
        SceneName sceneName = (SceneName)sceneIndex;
        LoadScene(sceneName);
    }
    //Para cargar escenas
    public void LoadScene(SceneName sceneName) => SceneManager.LoadScene(sceneName.ToString());
    //Cerrar Juego
    public void Salir() => Application.Quit();
}
