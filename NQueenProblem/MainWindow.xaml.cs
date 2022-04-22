using EightQueen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace NQueenProblem;

public partial class MainWindow : Window
{
    private int _boardSize;
    private List<string> _results;
    private List<Cell> _selectedCells;

    public MainWindow()
    {
        InitializeComponent();
        _boardSize = 5;
        _results = new List<string>();
        _selectedCells = new List<Cell>();
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
        DispatcherTimer timer = new ();

        myBoard.Cells
            .ToList()
            .ForEach(c => c.RemoveQueenImage());

        var cells = result.Split(';');
        _selectedCells = myBoard.Cells
            .Where(c => cells.Contains(c.CellName))
            .ToList();

        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += ChessPiecePlacement;
        timer.Start();
    }

    private void ChessPiecePlacement(object sender, EventArgs e)
    {
        if (_selectedCells.Count != 0)
        {
            resultsListBox.IsEnabled = false;
            _selectedCells[0].LoadQueenImage();
            _selectedCells[0].PlayStepSound();
            _selectedCells.RemoveAt(0);
        }
        else
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= ChessPiecePlacement;
            resultsListBox.IsEnabled = true;
        }
    }

    private void GetResults_Click(object sender, RoutedEventArgs e)
    {
        TableManagment table = new TableManagment(_boardSize);
        table.DumpQueen('A');
        _results = table.Results;
        resultsCount.Content = "Találatok száma: " + _results.Count + " db.";
        resultsListBox.ItemsSource = _results;
    }
}
