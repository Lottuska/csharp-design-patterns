using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Coding.Exercise
{
    public class Field
    {
        public string FieldName;
        public string DataType;
        public List<Field> Fields = new List<Field>();
        private const int IndentSize = 2;
    
        public Field()
        {
    
        }
        
        public Field(string fieldName, string dataType)
        {
            FieldName = fieldName;
            DataType = dataType;
        }
        
        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', IndentSize * indent);
            sb.AppendLine($"public {DataType} {FieldName}");
            sb.AppendLine("{");
            if (Fields != null)
            {
                foreach (var field in Fields)
                {
                    sb.Append(new string(' ', IndentSize * (indent + 1)));
                    sb.AppendLine($"public {field.DataType} {field.FieldName};");
                }
            }
            sb.AppendLine("}");
    
            return sb.ToString();
        }
        
        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
    
    public class CodeBuilder
    {
        private readonly string className;
        Field rootClass = new Field();
        
        private CodeBuilder()
        {
            
        }
        
        public CodeBuilder(string className)
        {
            if (className == null)
            {
                throw new ArgumentNullException(nameof(className));
            }
        
            rootClass.FieldName = className;
            rootClass.DataType = "class";
        }
        
        public CodeBuilder AddField(string fieldName, string dataType)
        {
            var field = new Field(fieldName, dataType);
            rootClass.Fields.Add(field);
            return this;
        }
        
        public override string ToString()
        {
            return rootClass.ToString();
        }

        public void clear()
        {
            rootClass = new Field { FieldName = className, DataType = "class" };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
