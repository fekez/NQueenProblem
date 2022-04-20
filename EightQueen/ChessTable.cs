using System.Collections.Generic;
using System.Text;

namespace EightQueen;

internal class ChessTable
{
    private Dictionary<char, List<int>> _table;
    private int _numberOfQueens = 8;

    public ChessTable(int number)
    {
        _numberOfQueens = number;
        _table = new Dictionary<char, List<int>>();
    }

    public int NumberOfQueens
    {
        get { return _numberOfQueens; }
        set { _numberOfQueens = value; }
    }

    public Dictionary<char, List<int>> Table
    {
        get { return _table; }
        set { _table = value; }
    }

    public bool CreateTable()
    {
        for (char i = 'A'; i < 'A' + _numberOfQueens; i++)
        {
            _table.Add(i, new List<int>());
            for (int j = 1; j <= _numberOfQueens; j++)
            {
                _table[i].Add(j);
            }
        }
        return true;
    }

    public int GetCountOfRowFreeCell(char row) => _table[row].Count;

    public int GetCountOfTableFreeCell()
    {
        int sum = 0;

        foreach (var item in _table)
        {
            sum += item.Value.Count;
        }

        return sum;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Clear();
        stringBuilder.Append("   ");

        for (int i = 1; i <= _numberOfQueens; i++)
        {
            stringBuilder.Append("  " + i + " ");
        }

        stringBuilder.Append('\n');

        foreach (var item in _table)
        {
            stringBuilder.Append(item.Key + "| ");
            for (int i = 1;i <= _numberOfQueens;i++)
            {
                if (item.Value.Contains(i))
                {
                    stringBuilder.Append(" " + item.Key + i + " ");
                }
                else
                {
                    stringBuilder.Append("  X ");
                }
            }
            stringBuilder.Append('\n');
        }
        stringBuilder.Append('\n');

        return stringBuilder.ToString();
    }

    public bool RemoveQueenRange(Queen queen)
    {
        int i = 1;
        char row = queen.Row;
        int column = queen.Column;

        while (_table.ContainsKey((char)(i + row)))
        {
            _table[(char)(i + row)].Remove(column + i);
            i++;
        }

        i = 1;
        while (_table.ContainsKey((char)(i - row)))
        {
            _table[(char)(i - row)].Remove(column - i);
            i++;
        }

        i = 1;
        while (_table.ContainsKey((char)(i + row)))
        {
            _table[(char)(i + row)].Remove(column - i);
            i++;
        }

        i = 1;
        while (_table.ContainsKey((char)(i - row)))
        {
            _table[(char)(i - row)].Remove(column + i);
            i++;
        }

        foreach (var item in _table)
        {
            item.Value.Remove(column);
        }

        _table[row].Clear();

        return true;
    }
}
