using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            }
        }


        public static readonly DependencyProperty PlayerMouseDownCommandProperty =
            DependencyProperty.RegisterAttached("PlayerMouseDownCommand", typeof(ICommand), typeof(MouseEventToCommand),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(PlayerMouseDownCommandAdded)));

        public static void SetPlayerMouseDownCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(PlayerMouseDownCommandProperty, c);
        }

        public static ICommand GetPlayerMouseDownCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(PlayerMouseDownCommandProperty);
        }

        private static void PlayerMouseDownCommandAdded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            SetPlayerMouseDownCommand(d, (ICommand)e.NewValue);
            element.PreviewMouseDown += elementPlayer_PreviewMouseDown;
        }

        static void elementPlayer_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = GetPlayerMouseDownCommand((DependencyObject)sender);
            var viewModel = GetChessSquareViewModel((DependencyObject)sender);
            if (command.CanExecute(viewModel))
            {
                command.Execute(viewModel);
            }
        }

        public static readonly DependencyProperty SecondPlayerMouseDownCommandProperty =
            DependencyProperty.RegisterAttached("SecondPlayerMouseDownCommand", typeof(ICommand), typeof(MouseEventToCommand),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(SecondPlayerMouseDownCommandAdded)));

        public static void SetSecondPlayerMouseDownCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(SecondPlayerMouseDownCommandProperty, c);
        }

        public static ICommand GetSecondPlayerMouseDownCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(SecondPlayerMouseDownCommandProperty);
        }

        private static void SecondPlayerMouseDownCommandAdded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            SetSecondPlayerMouseDownCommand(d, (ICommand)e.NewValue);
            element.PreviewMouseDown += elementSecondPlayer_PreviewMouseDown;
        }

        static void elementSecondPlayer_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = GetSecondPlayerMouseDownCommand((DependencyObject)sender);
            var viewModel = GetChessSquareViewModel((DependencyObject)sender);
            if (command.CanExecute(viewModel))
            {
                command.Execute(viewModel);
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
            }
        }


        public static readonly DependencyProperty PlayerMouseUpCommandProperty =
            DependencyProperty.RegisterAttached("PlayerMouseUpCommand", typeof(ICommand), typeof(MouseEventToCommand),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(PlayerMouseUpCommandAdded)));

        public static void SetPlayerMouseUpCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(PlayerMouseUpCommandProperty, c);
        }

        public static ICommand GetPlayerMouseUpCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(PlayerMouseUpCommandProperty);
        }

        private static void PlayerMouseUpCommandAdded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            SetPlayerMouseUpCommand(d, (ICommand)e.NewValue);
            element.PreviewMouseUp += elementPlayer_PreviewMouseUp;
        }

        static void elementPlayer_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = GetPlayerMouseUpCommand((DependencyObject)sender);
            var viewModel = GetChessSquareViewModel((DependencyObject)sender);
            if (command.CanExecute(viewModel))
            {
                command.Execute(viewModel);
            }
        }

        public static readonly DependencyProperty SecondPlayerMouseUpCommandProperty =
            DependencyProperty.RegisterAttached("SecondPlayerMouseUpCommand", typeof(ICommand), typeof(MouseEventToCommand),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(SecondPlayerMouseUpCommandAdded)));

        public static void SetSecondPlayerMouseUpCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(SecondPlayerMouseUpCommandProperty, c);
        }

        public static ICommand GetSecondPlayerMouseUpCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(SecondPlayerMouseUpCommandProperty);
        }

        private static void SecondPlayerMouseUpCommandAdded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            SetSecondPlayerMouseUpCommand(d, (ICommand)e.NewValue);
            element.PreviewMouseUp += elementSecondPlayer_PreviewMouseUp;
        }

        static void elementSecondPlayer_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = GetSecondPlayerMouseUpCommand((DependencyObject)sender);
            var viewModel = GetChessSquareViewModel((DependencyObject)sender);
            if (command.CanExecute(viewModel))
            {
                command.Execute(viewModel);
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
