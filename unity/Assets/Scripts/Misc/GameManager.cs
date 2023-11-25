using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public UnityAction<int> scoreChange;

    private PlayerInputActions playerInputActions;

    private int _score;
    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreChange(value);
        }
    }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Menu.Reset.performed += ResetLevel;
    }

    private void OnEnable()
    {
        playerInputActions.Menu.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Menu.Disable();
    }

    private void ResetLevel(InputAction.CallbackContext callback)
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
