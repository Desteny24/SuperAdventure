using System.Collections.Generic;

namespace Engine.Models
{
    public class World
    {
        private readonly List<Location> _locations = new();

        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            _locations.Add(new Location(xCoordinate, yCoordinate, name, description,
                $"/Engine;component/Images/Locations/{imageName}"));
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (var location in _locations)
            {
                if (location.XCoordinate == xCoordinate && location.YCoordinate == yCoordinate)
                {
                    return location;
                }
            }

            return null;
        }
    }
}