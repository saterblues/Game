using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Component
{
    /// <summary>
    /// 经常会出现给Entity赋予一个数值的情况，如：
    /// 给Entity添加了一个年龄属性
    /// 给Entity添加了魅力值属性
    /// 给Entity添加了邪恶度属性
    /// 给Entity添加了.....
    /// 
    /// 为每个对应的 xx 属性，添加一个对应的System属于重复操作
    /// 将此现象作为一个抽象的结构，成为了此构造体：NamedKVCollectionComponet
    /// name: 属性名
    /// K: 一般为 Entity
    /// V : 值 一般为Float
    /// 建议V不要使用复合类型，容易出现理解困难
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public struct NamedKVCollectionComponent<K,V> : IComponent
    {
        public NamedKVCollectionComponent(string name, Dictionary<K, V> kv)
        {
            Name = name;
            KV = kv;
        }
        public string Name;
        public Dictionary<K, V> KV;
    }
}
