# Evolution Simulator 🐦

The Evolution Simulator is a Unity project that simulates the evolution of cells in a dynamic environment. It serves as a platform to explore the behavior of different types of cells and their interactions.

Try the simulator online by visiting the URL below: 👇
https://play.unity.com/mg/other/evosimwebgl

## Features

- Two Types of Cells:
  - Normal Cells: These cells can consume food generated at random locations within the game world. They start with an initial health and have a maximum health of 50. They gradually lose health over time but can regain health by consuming food. When their health exceeds a certain threshold and they have enough reproduction energy, they can reproduce.
  - Predator Cells: These cells can consume both normal cells and food, but they derive more energy from consuming normal cells. Like normal cells, they can also reproduce based on their health and reproduction energy levels.

- Reproduction:
  - Normal Cell Reproduction: When a normal cell reproduces, there is a 50% chance of producing another normal cell and a 50% chance of spawning a predator cell.
  - Predator Cell Reproduction: Predator cells can also reproduce, generating either normal or predator cells.

- Dynamic Environment:
  - Food Generation: Food is continuously generated at random locations within the game world. Cells can consume this food to replenish their health and reproduction energy.
  - Energy and Health: Newly spawned cells start with low energy and health, requiring them to quickly consume food or other cells to survive.

## Planned Features

- Neural Network Integration: Implementing neural networks to simulate learning and decision-making processes for cells.
- Increased Cell Variety: Introducing additional types of cells with unique characteristics, behaviors, and interactions.
- Enhanced Randomness: Introducing more variability in food spawn rates and other environmental factors to create a dynamic and evolving simulation.
- User Interaction and Menus: Adding user-friendly menus for navigating the simulation and providing options to control time speed and other parameters.
- Statistical Analysis: Incorporating statistical features to analyze and visualize data gathered during the simulation.
- Improved Cell Models: Enhancing the visual representation of cells with better models, possibly providing a selection of different cell models.

## Getting Started

Follow these instructions to get a copy of the Evolution Simulator up and running on your local machine for development and testing purposes.

1. Clone the repository to your local machine.
2. Open the project in Unity.
3. Explore the existing features and scripts to understand the simulation logic and cell behaviors.
4. Make changes, add new features, or experiment with different parameters to further evolve the simulator.

## Contributing

Contributions to the Evolution Simulator are welcome! If you have ideas, bug fixes, or improvements, please submit them as pull requests. For major changes or new features, it's recommended to open an issue first to discuss and coordinate with the project maintainers.

## License

This project is licensed under the [MIT License](LICENSE), which means you are free to use, modify, and distribute the code for personal and commercial purposes.
