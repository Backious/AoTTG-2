﻿using System;
using UnityEngine;

namespace Assets.Scripts.Characters.Humans.Skills
{
    public class ErenSkill : Skill
    {
        public override bool Use()
        {
            Hero.Transform();
            return true;
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
