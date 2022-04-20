using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NQueenProblem;

/// <summary>
/// Mező osztály, ami a játéktáblán (Chessboard) jelenik meg.
/// </summary>
public partial class Cell : UserControl
{
    /// <summary>
    /// A mező háttérszíne
    /// </summary>
    private Brush _color;

    /// <summary>
    /// A mező oszlopa
    /// </summary>
    private char _column;

    /// <summary>
    /// A mező sora
    /// </summary>
    private int _row;

    /// <summary>
    /// A mező konstruktora.
    /// </summary>
    /// <param name="color">A mező háttérszíne</param>
    /// <param name="column">A mező oszlopa</param>
    /// <param name="row">A mező sora</param>
    public Cell(Brush color, char column, int row)
    {
        InitializeComponent();
        _color = color;
        _column = column;
        _row = row;

        Background = _color;
    }

    /// <summary>
    /// Összefűzi a mezőoszlopot és mezősort egy olvasható tulajdonságba.
    /// </summary>
    public string CellName { get => $"{_column}{_row}"; }

    /// <summary>
    /// A metódus megjeleníti a királynő bábut a mezőben.
    /// </summary>
    public void LoadQueenImage()
    {
        BitmapImage image = new BitmapImage();
        image.BeginInit();
        image.UriSource = new Uri("./Images/queen.png", UriKind.Relative);
        image.EndInit();
        cellImage.Source = image;
    }


    /// <summary>
    /// A metódus eltávolítja a királynő bábut a mezőről.
    /// </summary>
    public void RemoveQueenImage()
    {
        cellImage.Source = null;
    }
}
