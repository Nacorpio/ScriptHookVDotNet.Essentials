using System;
using System.Windows.Forms;
using GTA;
using SHDN.Essentials.Collections;
using SHDN.Essentials.Extensions;
using SHDN.Essentials.Wrapped;

namespace SHDN.Essentials
{
    public sealed class ExampleScript : Script
    {
        public static WList<WVehicle> Vehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleScript"/> class.
        /// </summary>
        public ExampleScript()
        {
            Vehicles = new WList<WVehicle>();

            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        private static void OnTick(object sender, EventArgs eventArgs)
        {
            Vehicles.OnTick(sender, eventArgs);
        }

        public void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Vehicles.OnKeyDown(sender, keyEventArgs);

            switch (keyEventArgs.KeyCode)
            {
                case Keys.F10:
                {
                    // Create a vehicle using the Vehicles instance we declared earlier.
                    WVehicle vehicle = Vehicles.CreateVehicle(VehicleHash.Adder, Game.PlayerPed.Position.Around(2f));

                    // Subscribe to a property called "Health" inside "vehicle.Entity".
                    vehicle.Subscribe(vehicle.Entity, "Health", OnHealthChanged);

                    break;
                }
            }
        }

        private void OnHealthChanged(object o, object newValue, object oldValue)
        {
            throw new NotImplementedException();
        }

        public void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            Vehicles.OnKeyUp(sender, keyEventArgs);
        }
    }
}
