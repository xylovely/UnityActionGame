using UnityEngine;


namespace OldTreeStudio
{
	public class MRock : MonoBehaviour, IMRock
	{
		#region INSPECTOR FIELDS

		[Header("Components")]
		[SerializeField] private Animator				_animator;
		[SerializeField] private string                 _animatorParameterGreen;
		[SerializeField] private GameObject             _diamond;
		[SerializeField] private AudioSource            _audioSource;

		[Header("Renderers")]
		[SerializeField] private SkinnedMeshRenderer	_LOD0Renderer;
		[SerializeField] private SkinnedMeshRenderer	_LOD1Renderer;
		[SerializeField] private SkinnedMeshRenderer	_LOD2Renderer;

		[Header("Green Materials")]
		[SerializeField] private Material				_LOD0GreenMat;
		[SerializeField] private Material				_LOD1GreenMat;
		[SerializeField] private Material				_LOD2GreenMat;

		[Header("Normal Materials")]
		[SerializeField] private Material				_LOD0NormalMat;
		[SerializeField] private Material				_LOD1NormalMat;
		[SerializeField] private Material				_LOD2NormalMat;

		#endregion


		#region SOUND FX

		public void PlaySFX ()
		{
			_audioSource.Play ();
		}

		#endregion


		#region STATE MANAGEMENT

		private bool _isGreen = true;


		public void SwitchState ()
		{
			if ( _isGreen = !_isGreen )
				SetToGreenState ();
			else
				SetToNormalState ();

			_animator.SetBool ( _animatorParameterGreen, _isGreen );
		}

		private void SetToGreenState ()
		{
			_LOD0Renderer.material = _LOD0GreenMat;
			_LOD1Renderer.material = _LOD1GreenMat;
			_LOD2Renderer.material = _LOD2GreenMat;

			_diamond.SetActive ( true );
		}

		private void SetToNormalState ()
		{
			_LOD0Renderer.material = _LOD0NormalMat;
			_LOD1Renderer.material = _LOD1NormalMat;
			_LOD2Renderer.material = _LOD2NormalMat;

			_diamond.SetActive ( false );
		}

		#endregion
	}
}