﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscaCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnderecoPorCidade : ContentPage
    {
        public EnderecoPorCidade()
        {
            InitializeComponent();
            lst_cidade.ItemsSource = lst_cidade;
        }

        

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}