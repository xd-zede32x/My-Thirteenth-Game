using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _hideAnimation = "hide";
    private const string _appearancesAnimation = "appearances";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
            _animator.SetTrigger(_hideAnimation);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        _animator.SetTrigger(_appearancesAnimation);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}