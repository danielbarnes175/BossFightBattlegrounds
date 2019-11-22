﻿using System;
using BFB.Engine.Entity;
using BFB.Engine.Simulation.SimulationComponents;

namespace BFB.Engine.Simulation.SpellComponents.Physics
{
    class SpellEffects1PhysicsComponent : EntityComponent
    {
        private readonly Random _random;

        public SpellEffects1PhysicsComponent() : base(false)
        {
            _random = new Random();
        }
        public override void Update(SimulationEntity simulationEntity, Simulation simulation)
        {
            //Creates the new velocity
            simulationEntity.Velocity.X = _random.Next(1, 10);
            simulationEntity.Velocity.Y = _random.Next(1, 10);

            //Updates the position
            simulationEntity.Position.Add(simulationEntity.Velocity);
        }
    }
}
