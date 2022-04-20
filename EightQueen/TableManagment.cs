using System;
using System.Collections.Generic;

namespace EightQueen;

public class TableManagment
{
    private Stack<Queen> _queens;
    private ChessTable _table;
    private Queen _lastQueenPosiition;
    private List<string> _results;

    public TableManagment(int number)
    {
        _queens = new Stack<Queen>();
        _lastQueenPosiition = null;
        _table = new ChessTable(number);
        _table.CreateTable();
        _results = new List<string>();
    }

    public List<string> Results { get => _results; }

    public int getResultsCount() => _results.Count;

    private void StepBack(char rowIndex)
    {
        _table.Table.Clear();
        _table.CreateTable();
        if (_queens.Count > 0)
        {
            _lastQueenPosiition = _queens.Pop();
        }

        foreach (var item in _queens)
        {
            _table.RemoveQueenRange(item);
        }

        DumpQueen(--rowIndex);
    }

    private void StepForward(char rowIndex, int column)
    {
        _lastQueenPosiition = new Queen(rowIndex, column);
        _queens.Push(_lastQueenPosiition);
        _table.RemoveQueenRange(_lastQueenPosiition);
        DumpQueen(++rowIndex);
    }


    public void DumpQueen(char rowIndex)
    {
        if(_queens.Count == _table.NumberOfQueens)
        {
            AddResult();

            StepBack(rowIndex);
        }
        else
        {
            if (_table.Table.ContainsKey(rowIndex))
            {
                if (_table.GetCountOfRowFreeCell(rowIndex) > 0)
                {
                    int biggerColumn;
                    bool isBiggerColumn = false;

                    if(_lastQueenPosiition != null && _lastQueenPosiition.Row == rowIndex)
                    {
                        biggerColumn = _lastQueenPosiition.Column;
                    }
                    else
                    {
                        biggerColumn = 0;
                    }

                    foreach (var cell in _table.Table[rowIndex])
                    {
                        if (cell > biggerColumn)
                        {
                            biggerColumn = cell;
                            isBiggerColumn = true;
                            break;
                        }
                    }

                    if (isBiggerColumn)
                    {
                        StepForward(rowIndex, biggerColumn);
                    }
                    else
                    {
                        StepBack(rowIndex);
                    }
                }
                else
                {
                    StepBack(rowIndex);
                }

            }

        }
    }

    private void AddResult()
    {
        _results.Add(String.Join(';', _queens));
    }
}

