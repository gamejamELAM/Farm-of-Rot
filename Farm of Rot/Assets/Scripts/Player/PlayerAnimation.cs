using System;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
	public class PlayerAnimation : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D _rigidBody;

		private Animator _animator;
		private SpriteRenderer _spriteRenderer;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			_spriteRenderer.flipX = _rigidBody.velocity.x < 0;
			
			if (Math.Abs(_rigidBody.velocity.x) <= 0 && Math.Abs(_rigidBody.velocity.y) <= 0)
			{
				_animator.SetTrigger("Idle");
			}
			else
			{
				_animator.SetTrigger("Run");
			}
		}
	}
}
