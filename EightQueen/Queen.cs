namespace EightQueen;

internal class Queen
{
    private char _row;
    private int _column;

    public Queen(char key, int position)
    {
        _row = key;
        _column = position;
    }

    public char Row
    {
        get { return _row; }
        set { _row = value; }
    }

    public int Column
    {
        get { return _column; }
        set { _column = value; }
    }

    public override string ToString()
    {
        return (_row.ToString() + _column);
    }
}
