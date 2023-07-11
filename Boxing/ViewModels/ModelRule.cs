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
    public class ModelRule
    {
        public ObservableCollection<RuleItem> items { get; set; }

        public ModelRule()
        {
            try
            {
                items = new ObservableCollection<RuleItem>();

                string fn = "Rule.json";

                var assembly = typeof(Rule).GetTypeInfo().Assembly;

                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{fn}");

                var reader = new StreamReader(stream);

                var js = reader.ReadToEnd();

                stream.Close();

                items = JsonConvert.DeserializeObject<ObservableCollection<RuleItem>>(js);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

    }

    public class RuleItem
    {
        public string Key { get; set; }
    }
}
