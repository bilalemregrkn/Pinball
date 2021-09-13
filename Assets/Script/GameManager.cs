using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public int Score
	{
		get => _score;
		set
		{
			_score = value;
			textScore.text = _score.ToString();
			textAnimator.Play(0);

			if (value == 0)
				textScore.text = "";
		}
	}

	private int _score;

	[SerializeField] private TextMeshPro textScore;

	[SerializeField] private Canvas canvasMenu;
	[SerializeField] private TextMeshProUGUI textStart;
	[SerializeField] private TextMeshProUGUI textTry;
	[SerializeField] private Animator textAnimator;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		canvasMenu.enabled = true;
		textStart.enabled = true;
		textTry.enabled = false;
	}

	public void OnGameStart()
	{
		Score = 0;
		canvasMenu.enabled = false;

		BallController.Instance.ResetBall();
	}

	public void OnGameOver()
	{
		canvasMenu.enabled = true;
		textStart.enabled = false;
		textTry.enabled = true;

		BallController.Instance.gameObject.SetActive(false);

		AudioManager.Instance.Play(SoundType.GameOver);
	}
}