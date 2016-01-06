using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using algebra_test.Resources;
using algebra_library;

namespace algebra_test
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Algebra alg = new Algebra();
            double number1 = 100;
            double number2 = 50;
            double result = alg.Addition(number1, number2);
            hasil.Text = result.ToString("0.000000");
        }

    }
}