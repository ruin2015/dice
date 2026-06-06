using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int Hp = 80;
    public bool isPlayerTurn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
