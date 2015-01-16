namespace Java2csharp.Filters
{
    public class FinalToReadOnly : IFilter
    {
        public string Apply(string code)
        {
            return code.ConvertKeyword("final", "readonly");
        }
    }
}