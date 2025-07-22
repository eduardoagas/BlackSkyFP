using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;
    public GameObject miniGamePanel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartKillTheBirdMiniGame()
    {
        miniGamePanel.SetActive(true);
        // Pode inicializar lógica interna do minigame aqui
    }

    public void EndMiniGame()
    {
        miniGamePanel.SetActive(false);
    }
}
