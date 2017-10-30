using System;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Code.Structure
{
    public class ScoreManager : MonoBehaviour {
        private static float _pScore, _p2Score;
        private static Text _pScoreText, _p2ScoreText;
        private static RectTransform _pScoreRect, _p2ScoreRect;

        private void Start() {
            if (gameObject.name == "Player1Score") {
                _pScoreRect = GetComponent<RectTransform>();
                _pScoreText = GetComponent<Text>();
            }
            else {
                _p2ScoreRect = GetComponent<RectTransform>();
                _p2ScoreText = GetComponent<Text>();
            }
            
            RefreshScore();
        }

        public static void AddScore(string player, float score) {
            if (player == "Player") {
                _pScore += score;
            }
            else {
                _p2Score += score;
            }
            RefreshScore();
        }

        private static void RefreshScore() {
            if (_pScoreText == null | _p2ScoreText == null) {
                return;
            }
            _pScoreText.text = String.Format("\tP1: {0}", _pScore);
            _p2ScoreText.text = String.Format("P2: {0}\t", _p2Score);
        }

        private void Update() {
            var height = Screen.height;
            var width = Screen.width;
            _pScoreRect.position = new Vector3(0f, height);
            _p2ScoreRect.position = new Vector3(width, height);
            _pScoreRect.sizeDelta = new Vector2(width * .5f, 20f);
            _p2ScoreRect.sizeDelta = new Vector2(width * .5f, 20f);
        }
    }
}
