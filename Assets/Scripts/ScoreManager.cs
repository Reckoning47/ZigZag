using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreMultiplier = 42;
    int scoreValue = 0;
    bool accumulating = true;
    //float scoreDivider = .04f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (accumulating)
        {
            scoreValue += Mathf.RoundToInt(scoreMultiplier * Time.deltaTime);
            scoreText.text = scoreValue.ToString();
        }
        
    }

    public void AddValue(int bonus)
    {
        scoreValue += bonus;
    }

    public void SetAccumulate(bool input)
    {
        accumulating = input;
    }

}
