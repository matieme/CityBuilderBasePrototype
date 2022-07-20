public class GridCellData
{
    public string Id;
    public Point Position;
    public CellType Type;

    public GridCellData(string id, Point position, CellType type)
    {
        Id = id;
        Position = position;
        Type = type;
    }
}
