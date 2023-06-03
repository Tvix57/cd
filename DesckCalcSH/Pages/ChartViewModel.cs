using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore.Defaults;

namespace DesckCalcSH.Pages;

public partial class ChartViewModel : ObservableObject
{
    private readonly ObservableCollection<ObservablePoint> _observableValues;
    public ObservableCollection<ISeries> Series { get; set; }

    public ChartViewModel() {
        _observableValues = new ObservableCollection<ObservablePoint>
        {
            new ObservablePoint(1d, 1d),
            new ObservablePoint(2d, 2d),
            new ObservablePoint(3d, 5d),
        };
        Series = new ObservableCollection<ISeries>
        {
            new LineSeries<ObservablePoint>
            {
                Values = _observableValues,
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            }
        };
    }
    public void ClearAll() {
        _observableValues.Clear();
    }
    public void AddValue(double x, double y) {
        if (!double.IsNaN(x) && !double.IsNaN(y) && 
            !double.IsInfinity(x) && !double.IsInfinity(y) &&
            !double.IsNegativeInfinity(x) && !double.IsNegativeInfinity(y)) {
            _observableValues.Add(new(x, y));
        }   
    }
}