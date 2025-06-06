using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Result result;
    private float DeadLineYpos = -2.35f;

    public void ResultSetManager(Result resultManager)
    {
        this.result = resultManager;
    }

    private void Update()
    {
        OnGameOver();
    }
    void OnGameOver()
    {
        if (transform.position.y <= DeadLineYpos + 0.75f)
        {
            result.opend = true;
        }
    }
}
