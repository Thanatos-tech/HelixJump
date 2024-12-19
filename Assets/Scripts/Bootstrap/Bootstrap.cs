using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string _mainSceneName;

    private void Start()
    {
        SceneManager.LoadScene(_mainSceneName);
    }
}
