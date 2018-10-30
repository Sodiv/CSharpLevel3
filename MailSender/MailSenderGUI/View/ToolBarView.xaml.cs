﻿using System;
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
using System.Collections.ObjectModel;

namespace MailSenderGUI.View
{
    /// <summary>
    /// Логика взаимодействия для ToolBarView.xaml
    /// </summary>
    public partial class ToolBarView : UserControl
    {               
        public ToolBarView()
        {
            InitializeComponent();            
        }

        public string NameLabel
        {
            get { return nameTextBlock.Text; }
            set { nameTextBlock.Text = value; }
        }

        
    }
}
