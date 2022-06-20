namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia;

public class DimensionButton : DropDownButton
{
    public ICommand CheckboxCheckedCommand
    {
        get { return (ICommand)GetValue(CheckboxCheckedCommandProperty); }
        set { SetValue(CheckboxCheckedCommandProperty, value); }
    }

    public static readonly AvaloniaProperty CheckboxCheckedCommandProperty =
        AvaloniaProperty.Register<DimensionButton,ICommand>(nameof(CheckboxCheckedCommand));


    public object CommandParameter
    {
        get { return (object)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public static readonly AvaloniaProperty CommandParameterProperty =
        AvaloniaProperty.Register<DimensionButton,object>(nameof(CommandParameter));


    public IInputElement CommandTarget
    {
        get { return (IInputElement)GetValue(CommandTargetProperty); }
        set { SetValue(CommandTargetProperty, value); }
    }

    public static readonly AvaloniaProperty CommandTargetProperty =
        AvaloniaProperty.Register<DimensionButton,IInputElement>(nameof(CommandTarget));


    public Dimension Dimension
    {
        get { return (Dimension)GetValue(DimensionProperty); }
        set { SetValue(DimensionProperty, value); }
    }

    public static readonly AvaloniaProperty DimensionProperty =
        AvaloniaProperty.Register<DimensionButton,Dimension>(nameof(Dimension));


    public DimensionButton() => CheckboxCheckedCommand = ReactiveCommand.Create<DimensionAction>(x => SelectedItem = x);
}
