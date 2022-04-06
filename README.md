# Unity Package: Helvest Backbone Framework

Helvest's backbone framework for Unity, contains the necessary to easily implement the following Design Patterns: 
- [Service Locator](https://github.com/Helvest/Unity-Package-Service-Locator.git)
- [Mediator](https://github.com/Helvest/Unity-Package-Service-Locator.git)
- [Finite-State Machine](https://github.com/Helvest/Unity-Package-Stype-Machine.git)
- [State Pattern](https://github.com/Helvest/Unity-Package-Stype-Machine.git)


> The purpose of the Backbone framework is to allow you to better organize your project, its main components are :

> The MonoTypeMachine component allows you to easily define, organize and instantiate the different states of a game.
> The MonoServiceLocator component allows you to reference and find any instance of a class as if it were a singleton, but with the possibility to restrict its reference frame to have several instances, each in a different ServiceLocator.

> The abstrac Backbone component is a mediator and it is the only script you should reference to get access to everything else, but it is still optional.
> The Backbone class is abstrac because its purpose is to also serve as a state, and therefore requires that you give it a unique name by inheriting it.

> Any class can be used as a state and/or be referenced in a ServiceLocator, but this framework works best if all classes inherit from Monobehaviour.
