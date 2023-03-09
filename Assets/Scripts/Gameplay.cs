using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Gameplay : MonoBehaviour
{
    public GameObject AIRock;
    public GameObject AIPaper;
    public GameObject AIScissors;
    public GameObject PlayerRock;
    public GameObject PlayerPaper;
    public GameObject PlayerScissors;

    public AudioSource audioSource;

    public AudioClip clickSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip tieSound;

    public Button winButton;
    public Button loseButton;
    public Button tieButton;

    private string playerCurrent = "paper";
    private string aiCurrent = "paper";

    public TextMeshProUGUI mainText;

    public int aiChoice;

    private bool gameStarted = false;
    private bool hasWon = false;
    private bool hasLost = false;
    private bool hasDrawn = false; 
    

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
                hasDrawn = true;
            }
            else if (PlayerPaper.activeInHierarchy == true && AIPaper.activeInHierarchy == true)
            {
                mainText.text = "Tied! Play again?";
                hasDrawn = true;
            }
            else if (PlayerScissors.activeInHierarchy == true && AIScissors.activeInHierarchy == true)
            {
                mainText.text = "Tied! Play again?";
                hasDrawn = true;
            }
            else
            {
                Debug.Log("Something happened we did not expect!!!!!!");
            }


            //Player Wins
            if (PlayerRock.activeInHierarchy == true && AIScissors.activeInHierarchy == true)
            {
                mainText.text = "You Win! Play Again?";
                hasWon = true;
            }
            else if (PlayerPaper.activeInHierarchy == true && AIRock.activeInHierarchy == true)
            {
                mainText.text = "You Win! Play Again?";
                hasWon = true;
            }
            else if (PlayerScissors.activeInHierarchy == true && AIPaper.activeInHierarchy == true)
            {
                mainText.text = "You Win! Play Again?";
                hasWon = true;
            }
            else
            {
                Debug.Log("Something happened we did not expect!!!!!!");
            }


            //AI Wins
            if (AIRock.activeInHierarchy == true && PlayerScissors.activeInHierarchy == true)
            {
                mainText.text = "You Lose! Play Again?";
                hasLost = true;
            }
            else if (AIPaper.activeInHierarchy == true && PlayerRock.activeInHierarchy == true)
            {
                mainText.text = "You Lose! Play Again?";
                hasLost = true;
            }
            else if (AIScissors.activeInHierarchy == true && PlayerPaper.activeInHierarchy == true)
            {
                mainText.text = "You Lose! Play Again?";
                hasLost = true;
            }
            else
            {
                Debug.Log("Something happened we did not expect!!!!!!");
            }

            //handle sounds seperately based on bool conditions 
            if (hasWon == true)
            {
                SimulateClickWin();
                hasWon = false;
            }

            if (hasLost == true)
            {
                SimulateClickWin();
                hasLost = false;
            }

            if (hasDrawn == true)
            {
                SimulateClickWin();
                hasDrawn = false;
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

    public void playClick()
    {
        audioSource.PlayOneShot(clickSound, 1.0F);
    }

    public void playWin()
    {
        audioSource.PlayOneShot(winSound, 1.0F);
    }

    public void playLose()
    {
        audioSource.PlayOneShot(loseSound, 1.0F);
    }

    public void playTie()
    {
        audioSource.PlayOneShot(tieSound, 1.0F);
    }

    private void SimulateClickWin()
    {
        if (winButton != null)
        {
            ExecuteEvents.Execute(winButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
    }

    private void SimulateClickLoss()
    {
        if (loseButton != null)
        {
            ExecuteEvents.Execute(loseButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
    }

    private void SimulateClickTie()
    {
        if (tieButton != null)
        {
            ExecuteEvents.Execute(tieButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
    }

}
