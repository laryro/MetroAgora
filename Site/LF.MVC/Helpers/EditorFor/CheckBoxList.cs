using System;
using System.Collections.Generic;
using System.Linq;
using LF.Entities.Base;

namespace LF.MVC.Helpers.EditorFor
{
    public class CheckBoxList
    {
        public List<CheckBoxItem> Items { get; set; }

        public CheckBoxList()
        {
            Items = new List<CheckBoxItem>();
        }

        public CheckBoxList(IEnumerable<IListableEntity> all, IEnumerable<int> chosen)
            : this()
        {
            Items.AddRange(all.Select(e => new CheckBoxItem(e.ID.ToString(), e.Name, chosen.Contains(e.ID))));
        }

        public IEnumerable<String> GetChosen()
        {
            return Items.Where(cbi => cbi.Chosen).Select(cbi => cbi.ID);
        }



        public class CheckBoxItem
        {
            public CheckBoxItem() { }

            public CheckBoxItem(String id, String name, Boolean chosen)
                : this()
            {
                ID = id;
                Name = name;
                Chosen = chosen;
            }

            public String ID { get; set; }
            public String Name { get; set; }
            public Boolean Chosen { get; set; }
            public Boolean HasTextBox { get; set; }
            public String TextBox { get; set; }
        }


        public static CheckBoxList FromEntity<T>(T entity = null)
            where T : class
        {
            var checkBoxList = new CheckBoxList();

            var properties = typeof (T)
                .GetProperties()
                .Where(p => p.PropertyType == typeof (Boolean));

            foreach (var property in properties)
            {
                var id = property.Name;
                var name = ResourceHelper.GetValue(id);
                var chosen = entity != null
                    && (Boolean)property.GetValue(entity);

                var item = new CheckBoxItem(id, name, chosen);

                if (entity != null)
                {
                    var textProperty = typeof (T)
                        .GetProperty(id + "Which");

                    if (textProperty != null)
                    {
                        item.HasTextBox = true;
                        var value = textProperty.GetValue(entity);

                        if (value != null)
                        {
                            item.TextBox = value.ToString();
                        }
                    }
                }

                checkBoxList.Items.Add(item);
            }

            return checkBoxList;
        }


        public void SetChosen<T>(T survey)
        {
            var properties = typeof(T)
                .GetProperties()
                .Where(p => p.PropertyType == typeof(Boolean));

            foreach (var property in properties)
            {
                var id = property.Name;
                var item = Items.Single(i => i.ID.ToString() == id);

                var chosen = item.Chosen;

                property.SetValue(survey, chosen);

                var textProperty = typeof(T)
                    .GetProperty(id + "Which");

                if (textProperty != null)
                {
                    textProperty.SetValue(survey, item.TextBox);
                }
            }
        }



    }
}