# CS-ECS
This is a project I made which implements a simple version of the Entity Component System.

You create components by creating new classes which inherit from IComponent.
```cs
//Creating a component for our entities
public class PositionComponent : IComponent {
    public float x;
    public float y;

    public PositionComponent(float x, float y) {
        this.x = x;
        this.y = y;
    }
}
```
Then you can just make an empty TestEntity(PositionEntity in the example): 
  - Use AddComponents to add IComponents
```cs
PositionEntity entity1 = new PositionEntity();
entity1.AddComponent<PositionComponent>(new PositionComponent(120, 100));
```
  - Use GetComponent to get the ICompoent
```cs
PositionComponent entityPosition = entity1.GetComponent<PositionComponent>();
```
  - Use GetComponent to access the variables and change them in the component
```cs
entity1.GetComponent<PositionComponent>().x = 0; // Changing the component values
```
  - Loop throught the entities in the static Entities class to go through each entity with a specified Component, then doing anything you want with those entities
```cs
Entities.GetEntities<PositionComponent>().ForEach(
    e => Console.WriteLine(e.GetComponent<PositionComponent>().x + ";" + e.GetComponent<PositionComponent>().y)
); 
```

This code is free to use and was made with learning in mind! 

***Have a great day! :)***
