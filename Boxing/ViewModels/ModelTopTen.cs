using Boxing.Models;
using Boxing.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Boxing.ViewModels
{
    public class ModelTopTen
    {
        public ObservableCollection<TopTenItem> items { get; set; }

        public ModelTopTen()
        {
            try
            {
                items = new ObservableCollection<TopTenItem>();

                string fn = "TopTen.json";

                var assembly = typeof(TopTen).GetTypeInfo().Assembly;

                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{fn}");

                var reader = new StreamReader(stream);

                var js = reader.ReadToEnd();

                stream.Close();

                items = JsonConvert.DeserializeObject<ObservableCollection<TopTenItem>>(js);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        public void show(TopTenItem _item)
        {

            if (_item.IsVisible)
            {
                _item.IsVisible = false;
            }
            else
            {
                _item.IsVisible = true;
            }

            update(_item);
        }

        private void update(TopTenItem item)
        {
            var index = items.IndexOf(item);

            items.Remove(item);
            items.Insert(index, item);
        }
    }
}
