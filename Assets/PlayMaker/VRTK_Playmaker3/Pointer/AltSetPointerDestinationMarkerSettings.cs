// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Set Pointer Destination Marker Settings.")]

	public class  AltSetPointerDestinationMarkerSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_Pointer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Enable Teleport")]
		public FsmBool enTeleport;

		[Tooltip("Reset when exiting this state.")]
		public FsmBool resetOnExit;

		public FsmBool everyFrame;

		private VRTK.VRTK_Pointer _teleport;
		bool _originalBool;

		VRTK.VRTK_Pointer theScript;

		public override void Reset()
		{

			gameObject = null;
			enTeleport = true;
			everyFrame = false;
			resetOnExit = null;
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

			if (resetOnExit.Value)
			{
				_originalBool = _teleport.enableTeleport;
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

			theScript.enableTeleport = enTeleport.Value;
		}


		public override void OnExit()
		{
			if (theScript==null)
			{
				return;
			}

			if (resetOnExit.Value)
			{
				_teleport.enableTeleport = _originalBool;
			}
		}



	}
}