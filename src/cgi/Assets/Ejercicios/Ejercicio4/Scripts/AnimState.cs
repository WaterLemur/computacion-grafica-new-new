using UnityEngine;

namespace Ejercicio4_Spells
{
    public class AnimState : StateMachineBehaviour
    {
        public State state;


        public override void OnStateEnter(
            Animator animator,
            AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            Wizard.W.CuteState = state;
        }
    }
}
