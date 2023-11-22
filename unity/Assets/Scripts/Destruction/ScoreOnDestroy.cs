using UnityEngine;

public class ScoreModifier : MonoBehaviour
{

    public int change = 100;

    void OnDestroy()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.score += change;
    }
}
