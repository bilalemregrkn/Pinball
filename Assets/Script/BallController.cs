using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
	public static BallController Instance { get; private set; }

	private Rigidbody2D _rigidbody2D;
	private SpriteRenderer _spriteRenderer;
	[SerializeField] private TrailRenderer trailRenderer;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		gameObject.SetActive(false);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Hit");
		var point = other.transform.GetComponent<PointCenterController>();
		if (point != null)
		{
			Debug.Log("Point Hit");
			point.OnHit();
		}

		if (other.transform.CompareTag("DeadCollider"))
		{
			GameManager.Instance.OnGameOver();
		}
	}

	public void ResetBall()
	{
		var color = ColorManager.Instance.GetCurrentColor();

		_spriteRenderer.color = color;
		trailRenderer.startColor = color;
		trailRenderer.Clear();

		gameObject.SetActive(true);
		_rigidbody2D.velocity = Vector2.zero;
		transform.position = Vector3.zero;

		var direction = Random.Range(.1f, .6f);
		direction = Random.value < 0.5f ? direction : -direction;
		_rigidbody2D.AddForce(new Vector2(direction, 1) * 100);
	}
}