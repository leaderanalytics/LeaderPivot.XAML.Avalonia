namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia;

public class DropDownButton : ContentControl, INotifyPropertyChanged
{
    #region BindableProperties
    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly AvaloniaProperty CommandProperty =
        AvaloniaProperty.Register<DropDownButton,ICommand>(nameof(Command), null, false, BindingMode.TwoWay);


    public ICommand SelectionChangedCommand
    {
        get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
        set { SetValue(SelectionChangedCommandProperty, value); }
    }

    public static readonly AvaloniaProperty SelectionChangedCommandProperty =
        AvaloniaProperty.Register<DropDownButton,ICommand>(nameof(SelectionChangedCommand), null, false, BindingMode.TwoWay);


    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly AvaloniaProperty ItemsSourceProperty =
        AvaloniaProperty.Register<DropDownButton,IEnumerable>(nameof(ItemsSource));


    public object SelectedItem
    {
        get { return (object)GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }

    public static readonly AvaloniaProperty SelectedItemProperty =
        AvaloniaProperty.Register<DropDownButton,object>(nameof(SelectedItem), null, false, BindingMode.TwoWay);


    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }

    public static readonly AvaloniaProperty ItemTemplateProperty =
        AvaloniaProperty.Register<DropDownButton,DataTemplate>(nameof(ItemTemplate));


    public Style ButtonStyle  
    {
        get { return (Style)GetValue(ButtonStyleProperty); }
        set { SetValue(ButtonStyleProperty, value); }
    }

    public static readonly AvaloniaProperty ButtonStyleProperty =
        AvaloniaProperty.Register<DropDownButton,Style>(nameof(ButtonStyle));


    public Style ListBoxStyle
    {
        get { return (Style)GetValue(ListBoxStyleProperty); }
        set { SetValue(ListBoxStyleProperty, value); }
    }

    public static readonly AvaloniaProperty ListBoxStyleProperty =
        AvaloniaProperty.Register<DropDownButton,Style>(nameof(ListBoxStyle));



    public Style ListBoxItemStyle
    {
        get { return (Style)GetValue(ListBoxItemStyleProperty); }
        set { SetValue(ListBoxItemStyleProperty, value); }
    }

    public static readonly AvaloniaProperty ListBoxItemStyleProperty =
        AvaloniaProperty.Register<DropDownButton,Style>(nameof(ListBoxItemStyle));


    public Style PopupStyle
    {
        get { return (Style)GetValue(PopupStyleProperty); }
        set { SetValue(PopupStyleProperty, value); }
    }

    public static readonly AvaloniaProperty PopupStyleProperty =
        AvaloniaProperty.Register<DropDownButton,Style>(nameof(PopupStyle));


    public Thickness PopupPadding
    {
        get { return (Thickness)GetValue(PopupPaddingProperty); }
        set { SetValue(PopupPaddingProperty, value); }
    }

    public static readonly AvaloniaProperty PopupPaddingProperty =
        AvaloniaProperty.Register<DropDownButton,Thickness>(nameof(PopupPadding));

    public ICommand MouseLeaveCommand
    {
        get => (ICommand)GetValue(MouseLeaveCommandProperty); 
        set => SetValue(MouseLeaveCommandProperty, value);
    }

    public static readonly AvaloniaProperty MouseLeaveCommandProperty =
        AvaloniaProperty.Register<DropDownButton, ICommand>(nameof(MouseLeaveCommand));

    public bool IsDropDownOpen
    {
        get => (bool)GetValue(IsDropDownOpenProperty);
        set => SetValue(IsDropDownOpenProperty, value);
    }

    public static readonly AvaloniaProperty IsDropDownOpenProperty =
        AvaloniaProperty.Register<DropDownButton, bool>(nameof(IsDropDownOpen));


    #endregion

    //private bool _IsDropDownOpen;
    //public bool IsDropDownOpen
    //{
    //    get => _IsDropDownOpen;
    //    set => SetProp(ref _IsDropDownOpen, value);
    //}

    private ICommand _ToggleDropDownCommand;
    public ICommand ToggleDropDownCommand
    {
        get => _ToggleDropDownCommand;
        set => SetProp(ref _ToggleDropDownCommand, value);
    }

    public DropDownButton()
    {
        TemplateApplied += DropDownButton_TemplateApplied;
        ToggleDropDownCommand = ReactiveCommand.Create(() => IsDropDownOpen = !IsDropDownOpen);
        MouseLeaveCommand = ReactiveCommand.Create(() => IsDropDownOpen = false );
    }

    private void DropDownButton_TemplateApplied(object sender, TemplateAppliedEventArgs e)
    {
        TemplateApplied -= DropDownButton_TemplateApplied;
        
        ListBox lb = e.NameScope.Find<ListBox>("PART_ListBox");
        
        if(lb != null)
            lb.SelectionChanged += (s, e) => SelectionChanged(s, e);
    }

    public event EventHandler SelectionChanged;
    

    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler? PropertyChanged;
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
