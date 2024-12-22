using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string _mainSceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(_mainSceneName);
    }
}
