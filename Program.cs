namespace ECS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PositionEntity entity1 = new PositionEntity();
            entity1.AddComponent<PositionComponent>(new PositionComponent(120, 100));
            entity1.AddComponent<PositionComponent>(new PositionComponent(120, 100)); // Won't add another PositionComponent as one already exists

            PositionComponent entityPosition = entity1.GetComponent<PositionComponent>();

            Console.WriteLine(entity1.Components.Count()); // 1
            Console.WriteLine(entity1.GetComponent<PositionComponent>().x); // 120

            entity1.GetComponent<PositionComponent>().x = 0; // Changing the component values
            Console.WriteLine(entity1.GetComponent<PositionComponent>().x); // 0

            //Creating more entities for testing
            PositionEntity entity2 = new PositionEntity();
            entity2.AddComponent<PositionComponent>(new PositionComponent(220, 50));
            PositionEntity entity3 = new PositionEntity();
            entity3.AddComponent<PositionComponent>(new PositionComponent(80, 70));

            Entities.GetEntities<PositionComponent>().ForEach(
                e => Console.WriteLine(e.GetComponent<PositionComponent>().x + ";" + e.GetComponent<PositionComponent>().y) // Go through every entity and
                                                                                                                            // printing out their PositionComponent values
            ); // 0;100
               // 220;50
               // 80;70
        }
    }


    //Creating a component for our entities
    public class PositionComponent : IComponent {
        public float x;
        public float y;

        public PositionComponent(float x, float y) {
            this.x = x;
            this.y = y;
        }
    }

    public class PositionEntity : Entity { 
        public PositionEntity() { }
    }
}
