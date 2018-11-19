using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _movementSpeed;
		[SerializeField, Range(0, 1)] private float _stopSpeed;

		private Rigidbody2D _rigidBody;
		private CapsuleCollider2D _capsuleCollider;

		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			var horizontal = Input.GetAxisRaw("Horizontal");
			var vertical = Input.GetAxisRaw("Vertical");

			var totalVelocity = Mathf.Abs(_rigidBody.velocity.x) + Mathf.Abs(_rigidBody.velocity.y);
			var totalInput = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

			print(totalInput);

			// Move the player.
			if (totalInput >= 0 && totalVelocity <= _maxSpeed)
			{
				var newForce = new Vector3(horizontal, vertical, 0).normalized * _movementSpeed;
				_rigidBody.AddForce(newForce);
			}
			// Slow the player down, if he isn't moving.
			else if (totalInput <= 0)
			{
				_rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, Vector2.zero, _stopSpeed);
			}
		}
	}
}
