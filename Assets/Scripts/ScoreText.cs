using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text _scoreText;
    private PlayerData playerData;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
        _scoreText = GetComponent<Text>();
        PlayerMovement.PickUpGarbage += PlayerData_ChangeScore;
        Restarter.Restart += Restarter_Restart;
        VilualizeScore();
    }

    private void Restarter_Restart(object sender, System.EventArgs e)
    {
        _scoreText.text = 0 + "" + "/" + GarbagePool.Instance.GetPickUpGarbageCount();
    }

    private void PlayerData_ChangeScore(object sender, System.EventArgs e)
    {
        VilualizeScore();
    }

    private void VilualizeScore()
    {
        _scoreText.text = playerData.currentGarbageCount + "" + "/" + GarbagePool.Instance.GetPickUpGarbageCount();
    }
}
