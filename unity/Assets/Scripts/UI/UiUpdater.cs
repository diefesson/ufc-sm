using TMPro;
using UnityEngine;

public class UiUpdater : MonoBehaviour
{
    public GameObject gameOverObject;
    public TextMeshProUGUI scoreMesh;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.scoreChange += (score) => scoreMesh.text = score.ToString();
    }

    private void Update()
    {
        gameOverObject.SetActive(Player.Players.Count == 0);
    }
}
