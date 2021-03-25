using Assets.Scripts.Characters.Humans.Constants;
using UnityEngine;

namespace Assets.Scripts.Characters.Humans.States
{
    public class HumanLandState : BaseHumanState
    {
        public override void OnUpdate()
        {
            if (!Hero.TitanForm && !Hero.IsCannon)
                if (Hero.Animation.IsPlaying(HeroAnim.DASH_LAND) && (Hero.Animation[HeroAnim.DASH_LAND].normalizedTime >= 1f))
                    Hero.SetState<HumanIdleState>();
        }

        public override void OnFixedUpdate()
        {
            if (Hero.IsGrounded)
                Hero.Zero = (Hero.Rigidbody.velocity * 0.96f);
        }
    }
}
