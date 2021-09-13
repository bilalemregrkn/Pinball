using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D leftArm;
	[SerializeField] private Rigidbody2D rightArm;

	[SerializeField] private float power;

	private bool IsPressKeyLeft => Input.GetKeyDown(KeyCode.A);
	private bool IsPressKeyRight => Input.GetKeyDown(KeyCode.D);

	private void Update()
	{
		if (IsPressKeyLeft)
			Hit(leftArm);

		if (IsPressKeyRight)
			Hit(rightArm);
	}

	private void Hit(Rigidbody2D current)
	{
		current.AddForce(Vector2.up * power);
	}
}