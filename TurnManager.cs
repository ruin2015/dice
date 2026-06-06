using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public bool isPlayerTurn = true;
    public bool isEnemyTurn = false;
    
    // 턴 전환 이벤트 (옵션: 다른 오브젝트에서 구독 가능)
    public delegate void TurnChangeDelegate();
    public event TurnChangeDelegate OnPlayerTurnStart;
    public event TurnChangeDelegate OnEnemyTurnStart;
    
    // 턴 끝내기 버튼 참조
    public Button endTurnButton;
    private Text buttonText;

    void Start()
    {
        // 버튼 컴포넌트 가져오기
        if (endTurnButton != null)
        {
            buttonText = endTurnButton.GetComponentInChildren<Text>();
            endTurnButton.onClick.AddListener(EndPlayerTurn);
        }
        
        // 게임 시작 시 플레이어 턴 시작
        StartPlayerTurn();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 플레이어 턴 시작
    /// </summary>
    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        isEnemyTurn = false;
        
        // 버튼 활성화
        if (endTurnButton != null)
        {
            endTurnButton.interactable = true;
            if (buttonText != null)
            {
                buttonText.text = "End Turn";
            }
        }
        
        OnPlayerTurnStart?.Invoke();
        Debug.Log("플레이어 턴 시작");
    }

    /// <summary>
    /// 플레이어 턴 종료 (버튼 클릭 시 호출)
    /// </summary>
    public void EndPlayerTurn()
    {
        if (!isPlayerTurn) return; // 플레이어 턴이 아니면 무시
        
        isPlayerTurn = false;
        Debug.Log("플레이어 턴 종료");
        
        // 적 턴 시작
        StartEnemyTurn();
    }

    /// <summary>
    /// 적 턴 시작
    /// </summary>
    public void StartEnemyTurn()
    {
        isEnemyTurn = true;
        
        // 버튼 비활성화
        if (endTurnButton != null)
        {
            endTurnButton.interactable = false;
            if (buttonText != null)
            {
                buttonText.text = "Enemy Turn";
            }
        }
        
        OnEnemyTurnStart?.Invoke();
        Debug.Log("적 턴 시작");
        
        // 적의 AI 로직 실행 (예: 2초 후 자동으로 턴 종료)
        Invoke("EndEnemyTurn", 2f);
    }

    /// <summary>
    /// 적 턴 종료
    /// </summary>
    public void EndEnemyTurn()
    {
        if (!isEnemyTurn) return;
        
        isEnemyTurn = false;
        Debug.Log("적 턴 종료");
        
        // 다시 플레이어 턴으로
        StartPlayerTurn();
    }
}
