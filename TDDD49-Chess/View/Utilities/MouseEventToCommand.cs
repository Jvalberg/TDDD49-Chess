using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TDDD49_Chess.View.Utilities
{
    public class MouseEventToCommand : DependencyObject
    {
        public static readonly DependencyProperty MouseDownCommandProperty =
            DependencyProperty.RegisterAttached("MouseDownCommand", typeof(ICommand), typeof(MouseEventToCommand),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseDownCommandAdded)));

        public static void SetMouseDownCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(MouseDownCommandProperty, c);
        }

        public static ICommand GetMouseDownCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(MouseDownCommandProperty);
        }

        private static void MouseDownCommandAdded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            SetMouseDownCommand(d, (ICommand)e.NewValue);
            element.PreviewMouseDown += element_PreviewMouseDown;
        }

        static void element_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = GetMouseDownCommand((DependencyObject)sender);
            var viewModel = GetChessSquareViewModel((DependencyObject)sender);
            if (command.CanExecute(viewModel))
            {
                command.Execute(viewModel);
                e.Handled = true;
            }
        }

        public static readonly DependencyProperty MouseUpCommandProperty =
            DependencyProperty.RegisterAttached("MouseUpCommand", typeof(ICommand), typeof(MouseEventToCommand),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseUpCommandAdded)));

        public static void SetMouseUpCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(MouseUpCommandProperty, c);
        }

        public static ICommand GetMouseUpCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(MouseUpCommandProperty);
        }

        private static void MouseUpCommandAdded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            SetMouseUpCommand(d, (ICommand)e.NewValue);
            element.PreviewMouseUp += element_PreviewMouseUp;
        }

        static void element_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = GetMouseUpCommand((DependencyObject)sender);
            var viewModel = GetChessSquareViewModel((DependencyObject)sender);
            if (command.CanExecute(viewModel))
            {
                command.Execute(viewModel);
                e.Handled = true;
            }
        }

        public static readonly DependencyProperty ChessSquareViewModelProperty =
            DependencyProperty.RegisterAttached("ChessSquareViewModel", typeof(ChessSquareViewModel), typeof(MouseEventToCommand));

        public static void SetChessSquareViewModel(DependencyObject d, ChessSquareViewModel c)
        {
            d.SetValue(ChessSquareViewModelProperty, c);
        }

        public static ChessSquareViewModel GetChessSquareViewModel(DependencyObject d)
        {
            return (ChessSquareViewModel)d.GetValue(ChessSquareViewModelProperty);
        }

    }
}
