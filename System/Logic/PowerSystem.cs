using System;
using Game.System.Data;
using Game.Component;
using Game.AttributeExtension;

namespace Game.System.Logic
{
    /// <summary>
    /// 基础属性系统:
    /// 力量 
    /// 敏捷 
    /// 智力
    /// </summary>
    /// 
    [RequireSystem(typeof(NameSystem))]
    [RequireSystem(typeof(NamedEntityFloatCollectionSystem))]
    public partial class PowerSystem : ISystem
    {
        public const string INTELLIGENCE = "Intelligence";
        public const string STRENGTH = "Strength";
        public const string AGILITY = "Agility";
        public PowerSystem():base() {
            OnRegisted += (sender, info ) => {
                var world = World.World.GameWorld;
                var nefc = world.GetSystem<NamedEntityFloatCollectionSystem>();
                if (!nefc.IsContainsSystem(INTELLIGENCE)) 
                { 
                    nefc.RegistEntity(world.CreateEntity(), INTELLIGENCE);
                }
                if (!nefc.IsContainsSystem(STRENGTH))
                {
                    nefc.RegistEntity(world.CreateEntity(), STRENGTH);
                }
                if (!nefc.IsContainsSystem(AGILITY))
                {
                    nefc.RegistEntity(world.CreateEntity(), AGILITY);
                }
                
                nefc.SetValue(INTELLIGENCE, info.entity, Convert.ToSingle(info.args[0]));
                nefc.SetValue(STRENGTH, info.entity, Convert.ToSingle(info.args[1]));
                nefc.SetValue(AGILITY, info.entity, Convert.ToSingle(info.args[2]));
            };

            OnUnRegisted += (sender,entity) => {
                var world = World.World.GameWorld;
                var nefc = world.GetSystem<NamedEntityFloatCollectionSystem>();
                nefc.Remove(INTELLIGENCE, entity);
                nefc.Remove(STRENGTH, entity);
                nefc.Remove(AGILITY, entity);
            };
        }

        public override IComponent CreateComponent(Entity entity, params object[] args)
        {
            return new Component.BaseComponent();
        }

        public float GetIntelligence(Entity entity) {
            IfNotFoundThrowException(entity);
            return entity.GetSystem<NamedEntityFloatCollectionSystem>().GetValue(INTELLIGENCE,entity);
        }

        public float GetStrength(Entity entity) {
            IfNotFoundThrowException(entity);
            return entity.GetSystem<NamedEntityFloatCollectionSystem>().GetValue(STRENGTH, entity);
        }

        public float GetAgility(Entity entity) {
            IfNotFoundThrowException(entity);
            return entity.GetSystem<NamedEntityFloatCollectionSystem>().GetValue(AGILITY, entity);
        }

        public void SetIntelligence(Entity entity,float intelligence) {
            IfNotFoundThrowException(entity);
            entity.GetSystem<NamedEntityFloatCollectionSystem>().SetValue(INTELLIGENCE, entity,intelligence);
        }

        public void SetStrength(Entity entity, float strength) {
            IfNotFoundThrowException(entity);
            entity.GetSystem<NamedEntityFloatCollectionSystem>().SetValue(STRENGTH, entity,strength);
        }

        public void SetAgility(Entity entity, float agility) {
            IfNotFoundThrowException(entity);
            entity.GetSystem<NamedEntityFloatCollectionSystem>().SetValue(AGILITY, entity, agility);
        }
      
    }
}
