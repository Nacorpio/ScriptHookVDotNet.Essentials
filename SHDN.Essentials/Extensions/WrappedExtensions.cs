using System;
using GTA;
using GTA.Math;
using SHDN.Essentials.Collections;
using SHDN.Essentials.Wrapped;

namespace SHDN.Essentials.Extensions
{
    public static class WrappedExtensions
    {
        /// <summary>
        /// Spawns a <see cref="Vehicle"/>, wraps it and adds it to a specific <see cref="WList{TEntity}"/>.
        /// </summary>
        /// <param name="list">The wrapped list.</param>
        /// <param name="modelHash">The model hash.</param>
        /// <param name="position">The position.</param>
        /// <param name="heading">The heading of the vehcle.</param>
        /// <returns></returns>
        public static WVehicle CreateVehicle(this WList<WVehicle> list, VehicleHash modelHash, Vector3 position,
            float heading = 0f)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (position == null)
                throw new ArgumentNullException(nameof(position));

            var vehicle = new WVehicle(list.CallbackManager, World.CreateVehicle(modelHash, position, heading));    
            list.Add(vehicle);

            return vehicle;
        }

        /// <summary>
        /// Spawns a random <see cref="Vehicle"/>, wraps it and adds it to a specific <see cref="WList{TEntity}"/>.
        /// </summary>
        /// <param name="list">The wrapped list.</param>
        /// <param name="position">The position.</param>
        /// <param name="heading">The heading of the vehicle.</param>
        /// <returns></returns>
        public static WVehicle CreateRandomVehicle(this WList<WVehicle> list, Vector3 position, float heading = 0f)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (position == null)
                throw new ArgumentNullException(nameof(position));

            var vehicle = new WVehicle(list.CallbackManager, World.CreateRandomVehicle(position, heading));
            list.Add(vehicle);

            return vehicle;
        }

        /// <summary>
        /// Spawns a <see cref="Prop"/>, wraps it and adds it to a specific <see cref="WList{TEntity}"/>.
        /// </summary>
        /// <param name="list">The wrapped list.</param>
        /// <param name="model">The world model.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="dynamic">Whether the prop should be dynamic.</param>
        /// <param name="placeOnGround">Whether to place the prop on the ground.</param>
        /// <returns></returns>
        public static WProp CreateProp(this WList<WProp> list, Model model, Vector3 position, Vector3 rotation = default(Vector3), bool dynamic = true,
            bool placeOnGround = true)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (position == null)
                throw new ArgumentNullException(nameof(position));

            if (rotation == null)
                throw new ArgumentNullException(nameof(rotation));

            var prop = new WProp(list.CallbackManager, World.CreateProp(model, position, rotation, dynamic, placeOnGround));
            list.Add(prop);

            return prop;
        }

        /// <summary>
        /// Spawns a <see cref="Ped"/>, wraps it and adds it to a specific <see cref="WList{TEntity}"/>.
        /// </summary>
        /// <param name="list">The wrapped list.</param>
        /// <param name="modelHash">The world model.</param>
        /// <param name="position">The position.</param>
        /// <param name="heading">The heading of the ped.</param>
        /// <returns></returns>
        public static WPed CreatePed(this WList<WPed> list, PedHash modelHash, Vector3 position, float heading = 0f)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (position == null)
                throw new ArgumentNullException(nameof(position));

            var ped = new WPed(list.CallbackManager, World.CreatePed(modelHash, position, heading));
            list.Add(ped);

            return ped;
        }

        /// <summary>
        /// Spawns a random <see cref="Ped"/>, wraps it and adds it to a specific <see cref="WList{TEntity}"/>.
        /// </summary>
        /// <param name="list">The wrapped list.</param>
        /// <param name="position">The position.</param>
        /// <param name="heading">The heading of the ped.</param>
        /// <returns></returns>
        public static WPed CreateRandomPed(this WList<WPed> list, Vector3 position, float heading = 0f)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (position == null)
                throw new ArgumentNullException(nameof(position));

            var ped = new WPed(list.CallbackManager, World.CreateRandomVehicle(position, heading));
            list.Add(ped);

            return ped;
        }
    }
}
