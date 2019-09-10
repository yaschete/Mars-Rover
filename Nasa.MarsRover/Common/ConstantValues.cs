using System.Collections.Generic;
using Nasa.MarsRover.Domain.Rover;

namespace Nasa.MarsRover.Common
{
    internal class ConstantValues
    {
        #region Regex Constraints

        //Eğer içerisinde sadece rakam geçiyorsa => PlateauSizeCommandRegex
        internal const string PlateauSizeCommandRegex = @"^\d+ \d+$";

        //Eğer içerisinde rakam ve N - S - E - W geçiyorsa => RoverCreateCommand
        internal const string RoverCreateCommandRegex = @"^\d+ \d+ [NSEW]$";

        //Eğer içerisinde L - R - M geçiyorsa => RoverDriveCommand
        internal const string RoverDriveCommandRegex = @"^[LRM]+$";
        #endregion

        #region Dictionaries
        public static Dictionary<char, Direction> GetDirectoryDictionary()
        {
            return new Dictionary<char, Direction>
            {
                {'N', Direction.North},
                {'S', Direction.South},
                {'E', Direction.East},
                {'W', Direction.West}
            };
        }
        public static Dictionary<Direction, char> GetDirectoryDictionaryReverse()
        {
            return new Dictionary<Direction, char>
            {
                { Direction.East,'E'},
                { Direction.North,'N'},
                { Direction.South,'S'},
                {Direction.West,'W' }
            };
        }
        public static Dictionary<char, Movement> GetMovementDictionary()
        {
            return new Dictionary<char, Movement>
            {
                {'L', Movement.Left},
                {'R', Movement.Right},
                {'M', Movement.Forward}
            };
        }
        #endregion
    }
}
