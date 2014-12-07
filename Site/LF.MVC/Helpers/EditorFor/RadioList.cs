using System;
using System.Collections.Generic;
using System.Linq;
using LF.Entities.Base;
using LF.MVC.Helpers.Extensions;

namespace LF.MVC.Helpers.EditorFor
{
    public class RadioList
    {
        public List<RadioItem> Items { get; set; }
        public Int32? Chosen { get; set; }

        public RadioList()
        {
            Items = new List<RadioItem>();
        }



        public static RadioList FromListable(IEnumerable<IListableEntity> all, Int32 chosen)
        {
            var items = all.Select(e => new RadioItem(e.ID, e.Name));

            return new RadioList
            {
                Items = items.ToList(),
                Chosen = chosen
            };
        }



        public static RadioList FromEnum<TEnum>()
            where TEnum : struct
        {
            var radioList = new RadioList();
            var values = Enum.GetValues(typeof(TEnum)).Cast<Enum>();

            foreach (var value in values)
            {
                var item = new RadioItem(
                    Convert.ToInt32(value),
                    value.GetName()
                );

                radioList.Items.Add(item);
            }

            return radioList;
        }

        public static RadioList FromEnum<TEnum>(TEnum chosen)
            where TEnum : struct
        {
            var radioList = FromEnum<TEnum>();
            radioList.Chosen = Convert.ToInt32(chosen);
            return radioList;
        }



        public void SetTextBox<TEnum>(TEnum value, String textBox)
            where TEnum : struct
        {
            var item = Items.Single(i => i.ID == Convert.ToInt32(value));

            item.HasTextBox = true;
            item.TextBox = textBox;
        }



        public String GetTextBox<TEnum>(TEnum value)
            where TEnum : struct
        {
            var item = Items.Single(i => i.ID == Convert.ToInt32(value));

            return item.TextBox;
        }



        public class RadioItem
        {
            public RadioItem() { }

            public RadioItem(Int32 id, String name)
                : this()
            {
                ID = id;
                Name = name;


            }

            public Int32 ID { get; set; }
            public String Name { get; set; }
            public Boolean HasTextBox { get; set; }
            public String TextBox { get; set; }
        }



    }
}