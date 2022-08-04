using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Component;

namespace Game.System.Data
{
    public class NamedEntityFloatCollectionSystem : ISystem
    {
        public override Component.IComponent CreateComponent(Entity entity, params object[] args)
        {
            NamedKVCollectionComponent<Entity, float> com =
                new NamedKVCollectionComponent<Entity, float>(args[0].ToString(), new Dictionary<Entity, float>());
            return com;
        }

        private Dictionary<Entity, float> FindKV(string KVSystemName)
        {
            var values = _components.Values;
            foreach (var item in values)
            {
                var KVComponent = (NamedKVCollectionComponent<Entity, float>)item;
                if (KVComponent.Name.Equals(KVSystemName, StringComparison.OrdinalIgnoreCase))
                {
                    return KVComponent.KV;
                }
            }
            throw new KeyNotFoundException(KVSystemName);
        }

        public string GetKVSystemName(Entity systemid)
        {
            return GetComponent<NamedKVCollectionComponent<Entity,float>>(systemid).Name;
        }

        public float GetValue(Entity systemid, Entity entity)
        {
            return GetComponent<NamedKVCollectionComponent<Entity, float>>(systemid).KV[entity];
        }

        public void SetValue(Entity systemid, Entity entity, float value)
        {
            GetComponent<NamedKVCollectionComponent<Entity, float>>(systemid).KV[entity] = value;
        }

        public float GetValue(string KVSystemName, Entity entity)
        {
            var kv = FindKV(KVSystemName);
            return kv[entity];
        }

        public void SetValue(string KVSystemName, Entity entity, float value) {
            var kv = FindKV(KVSystemName);
            kv[entity] = value;
        }

        public bool IsContains(string KVSystemName, Entity entity) {
            try
            {
                return FindKV(KVSystemName).ContainsKey(entity);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsContains(Entity systemid, Entity entity) {
           return  GetComponent<NamedKVCollectionComponent<Entity, float>>(systemid).KV.ContainsKey(entity);
        }

        public bool IsContainsSystem(string KVSystemName) {
            try
            {
                return FindKV(KVSystemName) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Remove(string KVSystemName, Entity entity)
        {
            if (!IsContains(KVSystemName, entity)) { return; }
            FindKV(KVSystemName).Remove(entity);
        }
        public void Remove(Entity systemid, Entity entity)
        {
            if (!IsContains(systemid, entity)) { return; }
            GetComponent<NamedKVCollectionComponent<Entity, float>>(systemid).KV.Remove(entity);
        }
    }
}
