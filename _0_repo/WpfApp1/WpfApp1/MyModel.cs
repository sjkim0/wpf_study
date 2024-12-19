using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Count {  get; set; }

        public MyModel(int id)
        {
            Id = id;
            Name = string.Empty;
            Description = string.Empty;
            Type = string.Empty;
        }
    }
}
