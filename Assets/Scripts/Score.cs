using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Score : MonoBehaviour
{
    private Text _scoreText;
    private int _score;
    void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    public void ScoreAdd()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
