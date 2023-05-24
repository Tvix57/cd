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
    private readonly ObservableCollection<ObservableValue> _observableValues;
    public ObservableCollection<ISeries> Series { get; set; }

    public ChartViewModel() {
        _observableValues = new ObservableCollection<ObservableValue>
        {
            new ObservableValue(2),
            new(5),
            new(4) 
        };
        Series = new ObservableCollection<ISeries>
        {
            new LineSeries<ObservableValue>
            {
                Values = _observableValues,
                Fill = null
            }
        };
    }
    public void ClearAll() {
        _observableValues.Clear();
    }
    public void AddValue(double value) {
        _observableValues.Add(new(value));
    }
}