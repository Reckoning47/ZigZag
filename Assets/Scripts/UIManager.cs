using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreMultiplier = 42;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject restartButton;


    int scoreValue = 0;
    bool accumulating = true;
    bool buttonsEnabled = false;
    float startx = 5;
    GameObject player;


    //float scoreDivider = .04f;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(buttonsEnabled);
        restartButton.SetActive(buttonsEnabled);
        scoreText.text = "0";
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (accumulating && player.transform.position.x > startx)
        {
            scoreValue += Mathf.RoundToInt(scoreMultiplier * Time.deltaTime);
            scoreText.text = scoreValue.ToString();
        }

        //Debug.Log("gameOverText.enabled  is " + gameOverText.enabled);
        gameOverText.SetActive(buttonsEnabled);
        restartButton.SetActive(buttonsEnabled);

    }

    public void AddValue(int bonus)
    {
        scoreValue += bonus;
    }

    public void SetAccumulate(bool input)
    {
        accumulating = input;
    }

    public void ResetScore()
    {
        scoreValue = 0;
    }

    public void EnableButtons(bool onOff)
    {
        //Debug.Log("buttonsEnabled is " + buttonsEnabled);
        buttonsEnabled = onOff;
    }
}
