using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace QuanLyGiaiBongDa.Common
{
    class WindowEventManager
    {
        readonly Window Window;
        IEnumerable<TextBox> _textBoxes;

        IEnumerable<TextBox> TextBoxes
        {
            get { return _textBoxes ?? (_textBoxes = DependencyObjects<TextBox>()); }
        }

        IEnumerable<ListView> _listViews;

        IEnumerable<ListView> ListViews
        {
            get { return _listViews ?? (_listViews = DependencyObjects<ListView>()); }
        }

        IEnumerable<T> DependencyObjects<T>() where T : DependencyObject
        {
            Func<DependencyObject, IEnumerable<T>> f = null;
            f = d =>
            {
                if (d is T) { return new[] { (T)d }; }
                return Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(d)).Select(i => f(VisualTreeHelper.GetChild(d, i))).SelectMany(a => a);
            };
            return f(Window);
        }
        internal WindowEventManager(Window window)
        {
            Window = window;
        }

        internal void SetEventHandlers()
        {
            //Window.Loaded += AddEventHandlers;
            //Window.Unloaded += RemoveEventHandlers;
            //Window.Loaded += SetFocusToFirstItem;
            //Window.Unloaded += ClearDataContext;
        }

        //void AddEventHandlers(object sender, RoutedEventArgs e)
        //{
        //    Window.Loaded -= AddEventHandlers;
        //    Window.KeyDown += MoveFocusWhenPressEnterKey;
        //    AddTextBoxEventHandlers();
        //    foreach (ListView listView in ListViews)
        //    {
        //        listView.TargetUpdated += ResizeListViewColumns;
        //    }
        //}
        
        //void RemoveEventHandlers(object sender, RoutedEventArgs e)
        //{
        //    Window.Unloaded -= RemoveEventHandlers;
        //    Window.KeyDown -= MoveFocusWhenPressEnterKey;
        //    RemoveTextBoxEventHandlers();
        //    foreach (ListView listView in ListViews)
        //    {
        //        listView.TargetUpdated -= ResizeListViewColumns;
        //    }
        //}

        //static void MoveFocusWhenPressEnterKey(object sender, KeyEventArgs e)
        //{
        //    if (e.Key != Key.Enter) return;
        //    var direction = Keyboard.Modifiers == ModifierKeys.Shift ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next;
        //    var element = FocusManager.GetFocusedElement(sender as Window) as FrameworkElement;
        //    if (element != null) element.MoveFocus(new TraversalRequest(direction));
        //}

        //IList<TextBoxEventManager> TextBoxEventManagers = new List<TextBoxEventManager>();
        
        //void AddTextBoxEventHandlers()
        //{
        //    foreach (TextBox textBox in TextBoxes)
        //    {
        //        var manager = TextBoxEventManager.CreateInstance(textBox);
        //        manager.AddEventHandlers();
        //        TextBoxEventManagers.Add(manager);
        //    }
        //}
        //void RemoveTextBoxEventHandlers()
        //{
        //    foreach (TextBoxEventManager manager in TextBoxEventManagers)
        //    {
        //        manager.RemoveEventHandlers();
        //    }
        //}
        //static void ResizeListViewColumns(object sender, DataTransferEventArgs e)
        //{
        //    foreach (GridViewColumn column in ((sender as ListView).View as GridView).Columns)
        //    {
        //        column.Width = 0;
        //        column.Width = double.NaN;
        //    }
        //}
        //static void SetFocusToFirstItem(object sender, RoutedEventArgs e)
        //{
        //    var window = sender as Window;
        //    window.Loaded -= SetFocusToFirstItem;
        //    var focusedElement = FocusManager.GetFocusedElement(window);
        //    if (focusedElement == null && window.MoveFocus(new TraversalRequest(FocusNavigationDirection.First)))
        //        focusedElement = FocusManager.GetFocusedElement(window);
        //    if (focusedElement is TextBox) (focusedElement as TextBox).SelectAll();
        //}

        //static void ClearDataContext(object sender, RoutedEventArgs e)
        //{
        //    var window = sender as Window;
        //    window.Unloaded -= ClearDataContext;
        //    window.DataContext = null;
        //}
    }
}
