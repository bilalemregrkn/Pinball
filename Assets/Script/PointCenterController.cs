using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointCenterController : MonoBehaviour
{
	[SerializeField] private int score;


	private Animator _myAnimator;
	private List<SpriteRenderer> _listSpriteRenderer = new List<SpriteRenderer>();


	private void Start()
	{
		_myAnimator = GetComponent<Animator>();
		_listSpriteRenderer = GetComponentsInChildren<SpriteRenderer>().ToList();
	}

	public void OnHit()
	{
		if (_myAnimator.enabled)
			_myAnimator.Play(0);
		else
			_myAnimator.enabled = true;

		StopAllCoroutines();

		IEnumerator Do()
		{
			yield return ColorAnimation(.3f, ColorManager.Instance.GetCurrentColor());
			yield return ColorAnimation(.3f, Color.white);
		}

		StopAllCoroutines();
		StartCoroutine(Do());

		GameManager.Instance.Score += score;
		
		AudioManager.Instance.Play(SoundType.Hit);
	}

	private IEnumerator ColorAnimation(float time, Color target)
	{
		float passed = 0;
		var init = _listSpriteRenderer[0].color;
		while (passed < time)
		{
			passed += Time.deltaTime;
			var current = Color.Lerp(init, target, passed / time);
			foreach (var item in _listSpriteRenderer)
				item.color = current;

			yield return null;
		}
	}
}