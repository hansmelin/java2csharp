namespace Java2csharp.Filters
{
    public class PrimitiveTypes : IFilter
    {
        public string Apply(string code)
        {
            code = code.ConvertClassName("boolean", "bool");
            code = code.ConvertClassName("String", "string");

            return code;
        }
    }
}