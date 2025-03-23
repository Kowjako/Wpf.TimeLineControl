using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TimeControl.CustomControl
{
    // Przykladowa struktura wezla
    public class Node
    {
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public partial class TimeLine : UserControl
    {
        // Rejestracja Dep. prop.
        public static readonly DependencyProperty NodesDepProp =
            DependencyProperty.Register(
                nameof(Nodes),
                typeof(List<Node>),
                typeof(TimeLine),
                new PropertyMetadata(null));

        // Udostepnienie binding'u
        public List<Node> Nodes
        {
            get { return (List<Node>)GetValue(NodesDepProp); }
            set { SetValue(NodesDepProp, value); }
        }

        private int _counter = 0;

        public Visibility ShowHead => _counter++ == 0 ? Visibility.Hidden : Visibility.Visible;

        public Visibility ShowTail => _counter++ == Nodes.Count * 2 - 1 ? Visibility.Hidden : Visibility.Visible;

        public TimeLine()
        {
            InitializeComponent();
            container.DataContext = this; // ViewModel jako ta klasa
        }
    }
}
