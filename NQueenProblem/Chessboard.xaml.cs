using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NQueenProblem;

/// <summary>
/// Sakktábla osztály, eltárolja a megjelenítéshez a tábla mezőit.
/// </summary>
public partial class Chessboard : UserControl
{
    /// <summary>
    /// A tábla mezőinek listája.
    /// </summary>
    private List<Cell> _cells;

    public Chessboard()
    {
        InitializeComponent();
        _cells = new List<Cell>();
    }

    /// <summary>
    /// A tábla aktuális mezői.
    /// </summary>
    public List<Cell> Cells { get => _cells; }

    /// <summary>
    /// A megadott táblaméret alapján létrehozza a mezőket.
    /// </summary>
    /// <param name="boardSize">Tábla mérete</param>
    public void CreateBoard(int boardSize)
    {
        _cells.Clear();
        boardGrid.Children.Clear();
        boardGrid.ColumnDefinitions.Clear();
        boardGrid.RowDefinitions.Clear();
        
        char columnName = 'A';
        for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
        {
            ColumnDefinition colDef = new ColumnDefinition();
            colDef.Width = new GridLength(1, GridUnitType.Star);
            boardGrid.ColumnDefinitions.Add(colDef);

            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = new GridLength(1, GridUnitType.Star);
            boardGrid.RowDefinitions.Add(rowDef);

            for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)
            {
                Brush color;

                if ((columnIndex + rowIndex) % 2 == 0)
                {
                    color = Brushes.Black;
                }
                else
                {
                    color = Brushes.White;
                }

                Cell cell = new Cell(color, columnName, rowIndex + 1);
                _cells.Add(cell);
                boardGrid.Children.Add(cell);
                Grid.SetColumn(cell, columnIndex);
                Grid.SetRow(cell, rowIndex);
            }

            columnName++;
        }
    }
}
