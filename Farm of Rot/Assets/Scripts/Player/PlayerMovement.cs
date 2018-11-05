using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _movementSpeed;

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

			if (Mathf.Abs(_rigidBody.velocity.x) + Mathf.Abs(_rigidBody.velocity.y) <= _maxSpeed)
			{
				var newForce = new Vector3(horizontal, vertical, 0).normalized * _movementSpeed;
				_rigidBody.AddForce(newForce);
			}
		}
	}
}
