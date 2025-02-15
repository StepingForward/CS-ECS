using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public interface IComponent { }

    public static class Entities {
        public static List<Entity> entities = new List<Entity>();

        public static List<Entity> GetEntities<T>() where T : IComponent {
            return entities.Where(e => e.Components.OfType<T>().Any()).ToList();
        }
    }

    public class Entity {
        public List<IComponent> Components { get; } = new List<IComponent>();

        public Entity() {
            Entities.entities.Add(this);
        }

        public void AddComponent<T>(T instance) where T : IComponent {
            if (!Components.Any(c => c.GetType() == typeof(T))) {
                Components.Add(instance);
            }
        }

        public T GetComponent<T>() where T : IComponent {
            var component = Components.FirstOrDefault(c => c is T);
            return (T)(component != null ? component : throw new InvalidOperationException("No such component found in the entity!"));
        }
    }
}
