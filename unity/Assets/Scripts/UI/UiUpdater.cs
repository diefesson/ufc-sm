using TMPro;
using UnityEngine;

public class UiUpdater : MonoBehaviour
{
    private GameManager gameManager;
    private TextMeshProUGUI scoreMesh;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        scoreMesh = transform.Find("Score").GetComponent<TextMeshProUGUI>();
        gameManager.scoreChange += (score) => scoreMesh.text = score.ToString();
    }
}
