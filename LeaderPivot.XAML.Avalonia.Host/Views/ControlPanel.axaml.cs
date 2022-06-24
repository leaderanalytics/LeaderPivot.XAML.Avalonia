using Avalonia.Markup.Xaml;

namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia.Host.Views;

public partial class ControlPanel : UserControl, INotifyPropertyChanged
{
    public bool DisplayGrandTotalOption
    {
        get { return (bool)GetValue(DisplayGrandTotalOptionProperty); }
        set { SetValue(DisplayGrandTotalOptionProperty, value); }
    }

    public static readonly AvaloniaProperty DisplayGrandTotalOptionProperty =
        AvaloniaProperty.Register<ControlPanel, bool>(nameof(DisplayGrandTotalOption), true);


    public bool DisplayDimensionButtons
    {
        get { return (bool)GetValue(DisplayDimensionButtonsProperty); }
        set { SetValue(DisplayDimensionButtonsProperty, value); }
    }

    public static readonly AvaloniaProperty DisplayDimensionButtonsProperty =
        AvaloniaProperty.Register<ControlPanel, bool>(nameof(DisplayDimensionButtons), true);


    public bool DisplayMeasureSelectors
    {
        get { return (bool)GetValue(DisplayMeasureSelectorsProperty); }
        set { SetValue(DisplayMeasureSelectorsProperty, value); }
    }

    public static readonly AvaloniaProperty DisplayMeasureSelectorsProperty =
        AvaloniaProperty.Register<ControlPanel, bool>(nameof(DisplayMeasureSelectors), true);


    public bool DisplayReloadDataButton
    {
        get { return (bool)GetValue(DisplayReloadDataButtonProperty); }
        set { SetValue(DisplayReloadDataButtonProperty, value); }
    }

    public static readonly AvaloniaProperty DisplayReloadDataButtonProperty =
        AvaloniaProperty.Register<ControlPanel, bool>(nameof(DisplayReloadDataButton), false);

    public string SelectedPivotStyle
    {
        get { return (string)GetValue(SelectedPivotStyleProperty); }
        set { SetValue(SelectedPivotStyleProperty, value); }
    }

    public static readonly AvaloniaProperty SelectedPivotStyleProperty =
        AvaloniaProperty.Register<ControlPanel,string>(nameof(SelectedPivotStyle), null);


    public bool UseDarkTheme
    {
        get { return (bool)GetValue(UseDarkThemeProperty); }
        set { SetValue(UseDarkThemeProperty, value); }
    }

    public static readonly AvaloniaProperty UseDarkThemeProperty =
        AvaloniaProperty.Register<ControlPanel, bool>(nameof(UseDarkTheme), false);


    public Thickness CellPadding
    {
        get { return (Thickness)GetValue(CellPaddingProperty); }
        set { SetValue(CellPaddingProperty, value); }
    }

    public static readonly AvaloniaProperty CellPaddingProperty =
        AvaloniaProperty.Register<ControlPanel, Thickness>(nameof(CellPadding), new Thickness(4), false, BindingMode.OneWay, null, null, (s, e) => ((ControlPanel)s).RaisePropertyChanged(nameof(CellPaddingString)));


    public int PivotControlFontSize
    {
        get { return (int)GetValue(PivotControlFontSizeProperty); }
        set { SetValue(PivotControlFontSizeProperty, value); }
    }

    public static readonly AvaloniaProperty PivotControlFontSizeProperty =
        AvaloniaProperty.Register<ControlPanel,int>(nameof(PivotControlFontSize), 11, false, BindingMode.OneWay, null, null, (s, e) => ((ControlPanel)s).RaisePropertyChanged(nameof(FontSizeString)));


    private ICommand _TogglePanelVisibilityCommand;
    public ICommand TogglePanelVisibilityCommand
    {
        get => _TogglePanelVisibilityCommand;
        set => SetProp(ref _TogglePanelVisibilityCommand, value);
    }

    private ICommand _ShowColorPickerPopupCommand;
    public ICommand ShowColorPickerPopupCommand
    {
        get => _ShowColorPickerPopupCommand;
        set => SetProp(ref _ShowColorPickerPopupCommand, value);
    }

    private ICommand _HideColorPickerPopupCommand;
    public ICommand HideColorPickerPopupCommand
    {
        get => _HideColorPickerPopupCommand;
        set => SetProp(ref _HideColorPickerPopupCommand, value);
    }

    private bool _PanelVisibility;
    public bool PanelVisibility
    {
        get => _PanelVisibility;
        set => SetProp(ref _PanelVisibility, value);
    }

    private Color _PrimaryColor;
    public Color PrimaryColor
    {
        get => _PrimaryColor;
        set => SetProp(ref _PrimaryColor, value);
    }

    private Color _SecondaryColor;
    public Color SecondaryColor
    {
        get => _SecondaryColor;
        set => SetProp(ref _SecondaryColor, value);
    }

    private bool _IsColorPickerPopupOpen;
    public bool IsColorPickerPopupOpen
    {
        get => _IsColorPickerPopupOpen;
        set => SetProp(ref _IsColorPickerPopupOpen, value);
    }

    private ICommand _SelectedThemeChangedCommand;
    public ICommand SelectedThemeChangedCommand
    {
        get => _SelectedThemeChangedCommand;
        set => SetProp(ref _SelectedThemeChangedCommand, value);
    }

    public string CellPaddingString => $"Cell Padding ({CellPadding.Left})";
    public string FontSizeString => $"Font Size ({PivotControlFontSize})";


    public ControlPanel()
    {
        InitializeComponent();
        PanelVisibility = false;
        TogglePanelVisibilityCommand = ReactiveCommand.Create(() => PanelVisibility = ! PanelVisibility );
        ShowColorPickerPopupCommand = ReactiveCommand.Create(() => IsColorPickerPopupOpen = true);
        HideColorPickerPopupCommand = ReactiveCommand.Create(() => IsColorPickerPopupOpen = false);
        SelectedThemeChangedCommand = ReactiveCommand.Create<SelectionChangedEventArgs>((x) => SelectedThemeChangedCommandHandler(x));
        SetResourceDictionary("Primary", true);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }



    private void SelectedThemeChangedCommandHandler(SelectionChangedEventArgs e)
    {
        string? remove = null;
        string? add = null;

        if (e.RemovedItems.Count > 0)
            remove = ((ComboBoxItem)e.RemovedItems[0]).Content.ToString();
        if (e.AddedItems.Count > 0)
            add = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
    }

    private void SetResourceDictionary(string themeName, bool add)
    {
        string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        Uri uri = new Uri($"avares://{assemblyName}/Themes/{themeName}.axaml");
        StyleInclude styleInclude = new StyleInclude(uri) { Source = uri };

        if (add)
            Application.Current.Styles.Add(styleInclude);
        else
            Application.Current.Styles.Remove(Application.Current.Styles.First(x => ((StyleInclude)x).Source == uri));
    }

    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler PropertyChanged;
    public void RaisePropertyChanged([CallerMemberNameAttribute] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void SetProp<T>(ref T prop, T value, [CallerMemberNameAttribute] string propertyName = "")
    {
        if (!Object.Equals(prop, value))
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }
    }
    #endregion
}
