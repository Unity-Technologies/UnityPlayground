# Playground Project

![playground.png](https://dl.dropboxusercontent.com/u/6116499/Images/playground.png)

##Description##

A collection of simple scripts to create 2D physics game, intended for giving workshops to an audience and quickly enable them to make games in Unity.

##Documentation

**Objective**

This project is intended to be as flexible as possible, not enforcing a specific game genre apart from the obvious constraints of being 2D and physics-powered. It contains a lot of scripts tha perform _atomic_ tasks, that is they do mostly only one thing, so you can combine them to create _any kind_ of gameplay.

That said, the audience should already have an idea of how Unity works, the Editor interface, the concept of GameObjects, Components, the Scene View, Play Mode, and so forth. It might be useful to guide them through these concepts before letting them play with this project.

**Usage instructions**

The `/Assets` folder contains a readme file called `ScriptsExplanations.rtf` that explains what each scripts does in a one-liner. This file is intended as a quick-reference, to give the audience a quick outlook of the possibities at their disposal.

The `/Sprites` and `/Particles` folders contain graphic assets which could be used to compose the scene, but the game makers are free to import new ones if they so desire.

Scripts are in the `/Scripts` folder, organised by category. Most of them should work out of the box, although some require objects to be tagged in a specific way to work. For instance, `/Gameplay/PlayerHealth.cs` requires the object to be tagged as "Player" in order to work, or "Player2" in the case of a 2-P game. Similarly, `/Destruction/KillEnemy.cs` will require the enemies to be tagged "Enemy".

[HowTo Video](https://drive.google.com/open?id=0B1E6a0_U02JjdWh0R1d1LWJKa2M)

**User interface**

The `/Prefabs` folder contains a prefab for the UI, which can be simply dragged and dropped in the scene. The scripts that communicate with the UI to show points or health will do it transparently and will still work if the UI is not present, but the UI needs to be setup so that it knows whether to show 1P or 2P UI.

**Graphic assets**
This project contains graphic assets taken from [Kenney.nl](http://www.kenney.nl). Nevertheless, it can work with any kind of 2D graphic assets so feel free to swap them with your resources. Just make sure to provide variety to allow many types of game genres.

**Code conventions**

The following coding conventions have been used throughout the project to facilitate the usage of the script components:
- Use RequireComponent to make sure they have added the right ones
- Duplicate collision code to work with colliders (OnCollisionEnter2D) but also triggers (OnTriggerEnter2D), to accomodate any collider setup
- Check if the UI is present, to allow the components to work even in games without UI

Or the editing of the code itself:
- Loads of comments
- Leave plenty of whitespace in order to minimise deletetion of curly brackets by mistake
- Not too much caching in order to minimise code (at the expense of performance)
- Use verbose variable and method names to clearly state what they do

**Software Requirements**

Required: Any Unity 5.x series

**Hardware Requirements**

Required: Laptop

**Owner and Responsible Devs**

Owner: Ciro Continisio

**Change Log**

- 11 Jul - Project created
- 12 Jul - Added graphic assets
- 15 Jul - (Mike G) Updated project structure
- 29 Jul - Example games, Editor scripts to customise the appearance of the components
- 07 Aug - HowTo video
- 15 Aug - Added Resource system, Action scripts
