using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    public GameObject AIRock;
    public GameObject AIPaper;
    public GameObject AIScissors;
    public GameObject PlayerRock;
    public GameObject PlayerPaper;
    public GameObject PlayerScissors;

    private string playerCurrent = "paper";
    private string aiCurrent = "paper";

    public TextMeshProUGUI mainText;

    public int aiChoice;

    private bool gameStarted = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == true)
        {
            //Ties
            if (PlayerRock.activeInHierarchy == true && AIRock.activeInHierarchy == true)
            {
                mainText.text = "Tied! Play again?";
            }
            else if (PlayerPaper.activeInHierarchy == true && AIPaper.activeInHierarchy == true)
            {
                mainText.text = "Tied! Play again?";
            }
            else if (PlayerScissors.activeInHierarchy == true && AIScissors.activeInHierarchy == true)
            {
                mainText.text = "Tied! Play again?";
            }
            else
            {
                Debug.Log("Something happened we did not expect!!!!!!");
            }


            //Player Wins
            if (PlayerRock.activeInHierarchy == true && AIScissors.activeInHierarchy == true)
            {
                mainText.text = "You Win! Play Again?";
            }
            else if (PlayerPaper.activeInHierarchy == true && AIRock.activeInHierarchy == true)
            {
                mainText.text = "You Win! Play Again?";
            }
            else if (PlayerScissors.activeInHierarchy == true && AIPaper.activeInHierarchy == true)
            {
                mainText.text = "You Win! Play Again?";
            }
            else
            {
                Debug.Log("Something happened we did not expect!!!!!!");
            }


            //AI Wins
            if (AIRock.activeInHierarchy == true && PlayerScissors.activeInHierarchy == true)
            {
                mainText.text = "You Lose! Play Again?";
            }
            else if (AIPaper.activeInHierarchy == true && PlayerRock.activeInHierarchy == true)
            {
                mainText.text = "You Lose! Play Again?";
            }
            else if (AIScissors.activeInHierarchy == true && PlayerPaper.activeInHierarchy == true)
            {
                mainText.text = "You Lose! Play Again?";
            }
            else
            {
                Debug.Log("Something happened we did not expect!!!!!!");
            }
        }
    }    
        


    public void OnRock()
    {
        
        PlayerRock.SetActive(true);
        PlayerPaper.SetActive(false);
        PlayerScissors.SetActive(false);

        AIChoice();
        gameStarted = true;
    }

    public void OnPaper()
    {

        PlayerRock.SetActive(false);
        PlayerPaper.SetActive(true);
        PlayerScissors.SetActive(false);

        AIChoice();
        gameStarted = true;
    }

    public void OnScissors()
    {

        PlayerRock.SetActive(false);
        PlayerPaper.SetActive(false);
        PlayerScissors.SetActive(true);

        AIChoice();
        gameStarted = true;
    }

    public void AIChoice()
    {
        aiChoice = Random.Range(1, 3);

        if (aiChoice == 1)
        {
            AIRock.SetActive(true);
            AIPaper.SetActive(false);
            AIScissors.SetActive(false);
        }
        else if (aiChoice == 2)
        {
            AIRock.SetActive(false);
            AIPaper.SetActive(true);
            AIScissors.SetActive(false);
        }
        else if (aiChoice == 3)
        {
            AIRock.SetActive(false);
            AIPaper.SetActive(false);
            AIScissors.SetActive(true);
        }
    }
}
