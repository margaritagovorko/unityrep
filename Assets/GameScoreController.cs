using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreController : MonoBehaviour
{
 [SerializeField] private TextMeshProUGUI _leftPlayerText;
 [SerializeField] private TextMeshProUGUI _rightPlayerText;
 private void Start()
 {
    _leftPlayerText.text = GameManager.leftPlayerScore.ToString();
    _rightPlayerText.text = GameManager.rightPlayerScore.ToString();
    GmeManager.ScoreUpdated += ScoreUpdated;
 }

 private void ScoreUpdated(object sender, EventArgs e)
 {
    _leftPlayerText.text = GameManager.leftPlayerScore.ToString();
    _rightPlayerText.text = GameManager.rightPlayerScore.ToString();
 }
}