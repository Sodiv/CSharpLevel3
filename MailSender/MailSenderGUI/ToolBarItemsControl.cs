using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpamLib;

namespace MailSenderGUI
{    
    public class ToolBarItemsControl : Control
    {
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(ICollection),
                typeof(ToolBarItemsControl),
                new PropertyMetadata(default(ICollection)));

        public ICollection ItemSource
        {
            get => (ICollection)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }

        public static readonly DependencyProperty PanelNameProperty =
            DependencyProperty.Register(
                nameof(PanelName),
                typeof(string),
                typeof(ToolBarItemsControl),
                new PropertyMetadata(default(string)));

        public string PanelName
        {
            get => (string)GetValue(PanelNameProperty);
            set => SetValue(PanelNameProperty, value);
        }
        static ToolBarItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarItemsControl), new FrameworkPropertyMetadata(typeof(ToolBarItemsControl)));
        }
    }
}
