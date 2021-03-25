using UnityEngine;
using TMPro;

namespace Galaxy
{
    //Script located on Score_TMPro_Obj
    public class ScoreUpdateScript : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scoreText;
        //Type of Component in Inspector which should be dragged here

        private static int currentScore = 0;
        private int newScoreValue = 1;


        private void Start()
        {
            //No init!!!
            //scoreText = GetComponent<TMP_Text>();

            UpdateScore();
        }


        public void AddScore()
        {
            currentScore += newScoreValue;
            UpdateScore();
        }


        private void UpdateScore()
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}