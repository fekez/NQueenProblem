using EightQueen;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace NQueenProblem;

public partial class MainWindow : Window
{
    private int _boardSize;
    private List<string> _results;

    public MainWindow()
    {
        InitializeComponent();
        _boardSize = 5;
        _results = new List<string>();
    }

    private void BoardSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _boardSize = (int) boardSizeSlider.Value;
    }

    private void GenerateBoardButton_Click(object sender, RoutedEventArgs e)
    {
        myBoard.CreateBoard(_boardSize);
        _results = new List<string>();
        resultsListBox.ItemsSource = _results;
    }

    private void ResultsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (resultsListBox.SelectedItem == null)
        {
            return;
        }

        ShowSelectedResultOnBoard(resultsListBox.SelectedItem.ToString());
    }

    private void ShowSelectedResultOnBoard(string result)
    {
        myBoard.Cells
            .ToList()
            .ForEach(c => c.RemoveQueenImage());

        var cells = result.Split(';');
        myBoard.Cells
            .Where(c => cells.Contains(c.CellName))
            .ToList()
            .ForEach(c => c.LoadQueenImage());
    }

    private void GetResults_Click(object sender, RoutedEventArgs e)
    {
        TableManagment table = new TableManagment(_boardSize);
        table.DumpQueen('A');
        _results = table.Results;
        resultsListBox.ItemsSource = _results;
    }
}
