
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreViewer;
    [SerializeField] private Text _highViewer;
    private int _currentScore = 0;
    private int _highScore = 0;

    public void UpScore()
    {
        _currentScore += 1;
        _highScore = Mathf.Max(_highScore, _currentScore);
        _scoreViewer.text = "Score : " + _currentScore;
        _highViewer.text = "High score : " + _highScore;
    }

    public void Reset()
    {
        _currentScore = -1;
        UpScore();
    }
}
