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
    public class ModelEquipment
    {
        public ObservableCollection<EquipmentItem> items { get; set; }

        public ModelEquipment()
        {
            try
            {
                items = new ObservableCollection<EquipmentItem>();

                string fn = "Equipment.json";

                var assembly = typeof(Equipment).GetTypeInfo().Assembly;

                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{fn}");

                var reader = new StreamReader(stream);

                var js = reader.ReadToEnd();

                stream.Close();

                items = JsonConvert.DeserializeObject<ObservableCollection<EquipmentItem>>(js);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        public void show(EquipmentItem _item)
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

        private void update(EquipmentItem item)
        {
            var index = items.IndexOf(item);

            items.Remove(item);
            items.Insert(index, item);
        }
    }
}
