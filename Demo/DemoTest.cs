﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.System.Data;
using Game.System.Logic;
using Game.Component;
using Game.Util;

namespace Game.Demo
{
    public class DemoTest
    {
        public void Test() {
            World.World world = World.World.GameWorld;
            world.RegistSystem<NameSystem>()
                .RegistSystem<NameSystem>()
                .RegistSystem<PowerSystem>()
                .RegistSystem<EntityGroupSystem>()
                .RegistSystem<CardSystem>()
                .RegistSystem<HealthSystem>()
                .RegistSystem<ManaSystem>()
                .RegistSystem<PlayerSystem>()
                .RegistSystem<PowerSystem>()
                .RegistSystem<UISystem>()
                .RegistSystem<NamedEntityFloatCollectionSystem>();
             

            Entity e1 = world.CreateEntity();
            Entity e2 = world.CreateEntity();

            Entity bag = world.CreateEntity();
            Entity thing0 = world.CreateEntity();
            Entity thing1 = world.CreateEntity();
            Entity thing2 = world.CreateEntity();
            Entity thing3 = world.CreateEntity();

            thing0.RegistToSystem<NameSystem>("卡牌一");
            thing1.RegistToSystem<NameSystem>("卡牌二");
            thing2.RegistToSystem<NameSystem>("卡牌三");
            thing3.RegistToSystem<NameSystem>("卡牌四");

            bag.RegistToSystem<EntityGroupSystem>(thing0,thing1,thing2,thing3);

            bag.GetSystem<EntityGroupSystem>().PopFirst(bag);
            var entities = bag.GetSystem<EntityGroupSystem>().PopLastRange(bag,2);

            e1.RegistToSystem<PlayerSystem>()
                .RegistToSystem<NameSystem>("壹号玩家")
                .RegistToSystem<PowerSystem>(10, 1, 5);

            e2.RegistToSystem<NameSystem>("贰号玩家")
                .RegistToSystem<PlayerSystem>();

            world.Update();

            e1.GetSystem<PowerSystem>().SetAgility(e1, 888);
            world.Update();

            e2.Destroy();
            e1.UnRegistFromSystem<PowerSystem>();
            world.Update();

        }
    }
}
