namespace Battleships.Board.TrackingBoard
{
    public class TrackingBoard : ITrackingBoard
    {
        public byte VerticalSize { get; }
        public byte HorizontalSize { get; }

        public byte DestroyedShipsCount { get; private set; }
        
        public TrackingFieldState[,] Fields { get; }

        public TrackingBoard(byte verticalSize, byte horizontalSize)
        {
            VerticalSize = verticalSize;
            HorizontalSize = horizontalSize;

            DestroyedShipsCount = 0;
            
            // Initialize all fields with empty state
            Fields = new TrackingFieldState[VerticalSize, HorizontalSize];
            for (int i = 0; i < VerticalSize; i++)
            {
                for (int j = 0; j < HorizontalSize; j++)
                {
                    Fields[i, j] = TrackingFieldState.Empty;
                }
            }
        }

        public void SetFieldState(Coordinates coordinates, TrackingFieldState fieldState)
        {
            Fields[coordinates.Horizontal, coordinates.Vertical] = fieldState;

            if (fieldState == TrackingFieldState.DestroyedShip)
            {
                DestroyedShipsCount++;
            }
        }
    }
}