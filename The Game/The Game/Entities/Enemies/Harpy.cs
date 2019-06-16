﻿using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Menu.MenuImpl;
using Confusing_Hobo_Unleashed.UI.Windows;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class Harpy : Updateable
    {
        private Updateable _entity;
        
        private static readonly int maxHp =5;
        private static readonly int maxMana=300;
        private static readonly int startMana = 50;
        private static readonly Pixel design = new Pixel(BaseColor.White, BaseColor.Black, 'F');
        private static readonly string weapon = "Fist";//TODO Weapons

        private static readonly ShapedImage shape = new ShapedImage(
            AbstractUIFactory.getInstance().buildImage(new[,] {{design}}),
            new RegularRectangle(new Position(0, 0), 1, 1)); //TODO Fix this position problem!

        public Harpy(Difficulty difficulty)
        {
            _entity = new FlyingController(new DamageController(new SpellController(startMana,maxMana, new Entity(maxHp, shape))));
        }

        public void Update()
        {
            _entity.Update();
        }
    }
}