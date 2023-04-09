using CS_Practice_2.ViewModels;
using System;

namespace CS_Practice_2.Navigation
{
    internal interface INavigatable
    {
        NavigationTypes ViewType
        {
            get;
        }
    }
}
