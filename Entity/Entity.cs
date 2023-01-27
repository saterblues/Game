using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.System.Data;

namespace Game
{
    public class Entity
    {
        public Entity() {
            _guid = Guid.NewGuid();
        }

        public Entity(Guid guid) {
            _guid = guid;
        }
        private Guid _guid;
        public Guid Uid
        {
            private set {
                _guid = value;
            }
            get {
                return _guid;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) { return false; }
            Entity entity = (Entity)obj;
            return entity._guid.Equals(this._guid);
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        public override string ToString()
        {
            if (this.IsInSystem<NameSystem>()) {
                return this.GetSystem<NameSystem>().GetName(this);
            }
            return base.ToString();
        }
    }
}
