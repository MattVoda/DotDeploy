// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Checks whether the VRTK pointer is currently active or not.")]

	public class  getPointerStatus : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_Pointer))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("This bool is true when the pointer is active")]
		public FsmBool pointerActive;

		public FsmBool everyFrame;

		VRTK.VRTK_Pointer theScript;

		public override void Reset()
		{

			pointerActive = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_Pointer>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			pointerActive.Value = theScript.IsPointerActive ();
				
		}

	}
}