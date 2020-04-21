using UnityEngine;


namespace OldTreeStudio.Example
{
	public class SwitchStateOnClick : MonoBehaviour
	{
		public GameObject _magicalRockGO;


		private IMRock _mRock;			//It's better to use rock simplified interface


		private void Start ()
		{
			//Accessing the interface of MRock
			_mRock = _magicalRockGO.GetComponent<IMRock> ();
		}

		private void Update ()
		{
			//Simple switch state on a screen click event
			if ( Input.GetMouseButtonDown ( 0 ) )
				_mRock.SwitchState ();
		}
	}
}