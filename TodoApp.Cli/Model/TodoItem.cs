using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Cli.Model
{
    public class TodoItem
    {
        public TodoItemType ItemType { get; set; }

        public DateTime InsertedAt { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }

        public IList<TodoItem> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var isDone = Completed ? "x" : " ";
            var result = "";

            if (this.ItemType == TodoItemType.List)
            {
                var countDone = 0;

                foreach (TodoItem td in Items)
                {
                    sb.Append("\n -- " + td.ToString());
                    if (td.Completed) countDone++;
                }

                isDone = countDone + "/" + Items.Count;
                result = "[" + isDone + "] " + this.Title + sb.ToString();
            }
            else
            {
                result = "[" + isDone + "] " + this.Title;
            }

            return result;
        }
    }
}