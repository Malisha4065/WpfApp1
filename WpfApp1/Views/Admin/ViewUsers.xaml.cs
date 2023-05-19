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
using WpfApp1.Models;
using WpfApp1.ViewModels.Admin;

namespace WpfApp1.Views.Admin
{
    /// <summary>
    /// Interaction logic for ViewUsers.xaml
    /// </summary>
    public partial class ViewUsers : UserControl
    {
        public ViewUsers()
        {
            DataContext = new ViewUsersVM();
            InitializeComponent();
        }

        /*private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
                if (this.DataContext != null)
                {
                    ((dynamic)this.DataContext).originalUser = (User)((DataGrid)sender).SelectedItem;
                }
        }*/
    }
}
