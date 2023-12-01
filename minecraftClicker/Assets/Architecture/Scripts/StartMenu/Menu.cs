using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private const string _hideAnimation = "hide";
    private const string _appearancesAnimation = "appearances";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Cliker")
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