﻿using LocalizationOnMAUI.Resources.Languages;
using Microsoft.Maui.Platform;
using System;
using System.ComponentModel;
using System.Globalization;

namespace LocalicationOnMAUI
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        public LocalizationResourceManager()
        {
            AppResources.Culture = CultureInfo.CurrentCulture;
        }

        public static LocalizationResourceManager Instance { get; } = new();

        public object this[string resourceKey]
            => AppResources.ResourceManager.GetObject(resourceKey, AppResources.Culture) ?? Array.Empty<byte>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetCulture(CultureInfo culture)
        {
            AppResources.Culture = culture;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

    }
}

