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
            new ObservablePoint(1, 1),
            new ObservablePoint(2, 2),
            new ObservablePoint(3, 5),
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
        _observableValues.Add(new(x, y));
    }
}