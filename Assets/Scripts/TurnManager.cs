using UnityEngine;
using UnityEngine.UI;
public class TurnManager : MonoBehaviour
{
    public bool isPlayerTurn = true;
    public bool isEnemyTurn = false;

    public Button endTurnButton;
    public delegate void TurnChangeDelegate();
    public event TurnChangeDelegate OnPlayerTurnStart;
    public event TurnChangeDelegate OnEnemyTurnStart;
    void Start()
    {
        if (endTurnButton != null)
        {
            endTurnButton.onClick.AddListener(EndPlayerTurn);
        }

        // 게임 시작 시 플레이어 턴 시작
        StartPlayerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        isEnemyTurn = false;
        OnPlayerTurnStart?.Invoke();
        Debug.Log("플레이어 턴 시작");
    }

    public void EndPlayerTurn()
    {
        if (!isPlayerTurn) return; // 플레이어 턴이 아니면 무시

        isPlayerTurn = false;
        Debug.Log("플레이어 턴 종료");

        // 적 턴 시작
        StartEnemyTurn();
    }
    public void StartEnemyTurn()
    {
        isEnemyTurn = true;
        OnEnemyTurnStart?.Invoke();
        Debug.Log("적 턴 시작");

        // 적의 AI 로직 실행 (예: 2초 후 자동으로 턴 종료)
        Invoke("EndEnemyTurn", 2f);
    }

    public void EndEnemyTurn()
    {
        if (!isEnemyTurn) return;

        isEnemyTurn = false;
        Debug.Log("적 턴 종료");

        // 다시 플레이어 턴으로
        StartPlayerTurn();
    }

}
