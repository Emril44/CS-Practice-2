using System;

namespace CS_Practice_2.Navigation
{
    internal interface INavigatable<TObject> where TObject : Enum
    {
        TObject ViewType { get; }
    }
}
