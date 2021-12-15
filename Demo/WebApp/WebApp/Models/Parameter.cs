using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Parameter
    {
        //trừu tượng do không biết đc kiểu dữ liệu của nó
        public object Value { get; set; }
        public string Name { get; set; }
        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public IDataParameter DataParameter { get; set; }
        public T Get<T>()
        {
            return (T)DataParameter.Value;
        }
    }
}
