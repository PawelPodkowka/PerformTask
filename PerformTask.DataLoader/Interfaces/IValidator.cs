﻿using System.Xml.Linq;

namespace PerformTask.DataLoader.Interfaces
{
    internal interface IValidator
    {
        bool Validate(XDocument document);
    }
}
